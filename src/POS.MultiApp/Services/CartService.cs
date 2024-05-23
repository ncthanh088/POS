using System.Text.Json;
using POS.MultiApp.Enums;
using POS.MultiApp.LocalStorage;
using POS.MultiApp.Models;
using POS.MultiApp.Services.Abstractions;

namespace POS.MultiApp.Services;

public class CartService : ICartService
{
    public event Action OnChange;
    private readonly ILocalStorage _localStorage;
    private readonly IItemService _itemService;
    private readonly IAuthService _authService;

    private readonly IPaymentService _paymentService;
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    private readonly AppState _appState;

    private CartInfo _cartInfo { get; set; }

    public CartService(HttpClient client,
        IItemService productService, IPaymentService paymentService, IAuthService authService,
        AppState appState, ILocalStorage localStorage)
    {
        _itemService = productService;
        _httpClient = client;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _paymentService = paymentService;
        _authService = authService;
        _appState = appState;
        _localStorage = localStorage;
    }

    public async Task AddItemToCartAsync(CartItem cartItem)
    {
        var item = await _itemService.GetItemAsync(cartItem.ItemId);
        cartItem.Tax = item.Tax;
        cartItem.ItemId = item.Id;
        cartItem.RegularUnitPrice = item.Price;
        cartItem.ActualUnitPrice = item.Price;
        _cartInfo = await _localStorage.GetValueAsync<CartInfo>(Constants.Constant.CART_INFO_KEY);

        if (_cartInfo == null)
        {
            _cartInfo = new CartInfo();
        }

        var itemInCart = _cartInfo.CartItems?.FirstOrDefault(x => x.ItemId == cartItem.ItemId);
        if (itemInCart == null)
        {
            _cartInfo.CartItems?.Add(cartItem);
        }
        else
        {
            itemInCart.Quantity += 1;
        }
        await UpdateCartAsync(_cartInfo);
    }

    public async Task RemoveCartItemAsync(CartItem item)
    {
        _cartInfo = await _localStorage.GetValueAsync<CartInfo>(Constants.Constant.CART_INFO_KEY);

        var cartItem = _cartInfo.CartItems?.FirstOrDefault(x => x.ItemId == item.ItemId);
        if (cartItem != null && cartItem.Quantity == 1)
        {
            _cartInfo.CartItems.Remove(cartItem);
        }
        else
        {
            cartItem.Quantity -= 1;
        }
        await UpdateCartAsync(_cartInfo);
    }

    private async Task UpdateCartAsync(CartInfo cart)
    {
        if (cart != null)
        {
            _cartInfo = cart;
        }
        await _localStorage.SetValueAsync(Constants.Constant.CART_INFO_KEY, _cartInfo);
        await PrepareCartInfoAsync();
        OnChange.Invoke();
    }

    public async Task<CartInfo> GetCartInfoAsync()
    {
        _cartInfo = await _localStorage.GetValueAsync<CartInfo>(Constants.Constant.CART_INFO_KEY);
        return _cartInfo;
    }

    public Task EmptyCart()
    {
        _localStorage.RemoveValue<CartInfo>(Constants.Constant.CART_INFO_KEY);
        OnChange.Invoke();
        return Task.CompletedTask;
    }

    public async Task PrepareCartInfoDataAsync()
    {
        await PrepareCartInfoAsync();
    }


    private async Task PrepareCartInfoAsync()
    {
        // Step1. Get or create a new sale transaction.
        var userInfo = await _authService.GetOrCreateUserInfoAsync();
        var newTransaction = new AddSaleTransaction
        {
            UserId = userInfo.Id,
            MemberId = null,
            User = userInfo,
        };
        var transaction = await _paymentService.GetOrCreateSaleTransactionAsync(newTransaction);

        // Step2. Recalculate the cart
        _cartInfo = await GetCartInfoAsync();
        if (_cartInfo?.CartItems == null)
        {
            return;
        }

        var transactionItems = _cartInfo.CartItems.Select(x => new TransactionItem
        {
            ItemId = x.ItemId,
            Name = x.Name,
            UnitPrice = x.UnitPrice,
            TransactionId = transaction.TransactionId,
            RegularUnitPrice = x.RegularUnitPrice,
            ActualPriceExcludingTax = x.ActualPriceExcludingTax,
            ActualUnitPrice = x.ActualUnitPrice,
            BeforeDiscountPriceExcludingTax = x.ActualPriceExcludingTax,
            BeforeDiscountUnitPrice = x.BeforeDiscountUnitPrice,
            Discount = x.Discount,
            Tax = x.Tax,
            ExtendedDiscountAmount = x.ExtendedDiscountAmount,
            ExtendedPriceExcludingDiscount = x.ExtendedPriceExcludingDiscount,
            Quantity = x.Quantity,
            SequenceNumber = x.SequenceNumber,
        });

        var saleTransaction = new CalculateSaleTransaction
        {
            UserId = userInfo.Id,
            CustomerId = null,
            TransactionId = transaction.TransactionId,
            SerialNumber = transaction.SerialNumber,
            Items = transactionItems.ToList(),
            Tenders = _cartInfo.Tenders,
            Taxes = _cartInfo.Taxes,
            ChangeAmount = _cartInfo.Tenders == null ? 0 : _cartInfo.Tenders.Sum(x => x.Amount), // Tenders has default value is Zero.
            CreatedAt = DateTime.UtcNow,
            Description = string.Empty,
            IsVoided = false,
            IsCancelled = false,
            IsComplete = false,
            OpenCashDrawer = _cartInfo.Tenders.Where(x => x.Type == TenderType.Cash).Count() > 0,
            RoundedAmount = 0,
            RoundingAmount = 0,

        };
        saleTransaction = await _paymentService.CalculateSaleTransactionAsync(saleTransaction);

        // Step3. Update cart items.
        _cartInfo.CartItems = saleTransaction.Items.Select(x => new CartItem
        {
            Id = x.ItemId,
            TaxAmount = x.TotalTax,
            TaxOnGrossAmount = x.TaxOnGrossAmount,
            Name = x.Name,
            ItemId = x.ItemId,
            TransactionId = transaction.TransactionId,
            RegularUnitPrice = x.RegularUnitPrice,
            ActualPriceExcludingTax = x.ActualPriceExcludingTax,
            ActualUnitPrice = x.ActualUnitPrice,
            BeforeDiscountPriceExcludingTax = x.ActualPriceExcludingTax,
            BeforeDiscountUnitPrice = x.BeforeDiscountUnitPrice,
            Discount = x.Discount,
            Tax = x.Tax,
            TotalTax = x.TotalTax,
            ExtendedDiscountAmount = x.ExtendedDiscountAmount,
            ExtendedPriceExcludingDiscount = x.ExtendedPriceExcludingDiscount,
            Quantity = x.Quantity,
            SequenceNumber = x.SequenceNumber,
        }).ToList();
        _cartInfo.Taxes = saleTransaction.Taxes.Select(x => new TransactionTax
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Amount = x.Amount,
            TaxableAmount = x.TaxableAmount,
            Percentage = x.Percentage,
            TransactionId = x.TransactionId,
        }).ToList();

        await _localStorage.SetValueAsync<CartInfo>(Constants.Constant.CART_INFO_KEY, _cartInfo);
    }

    public async Task ProcessPaymentAsync()
    {
        var userInfo = await _authService.GetOrCreateUserInfoAsync();
        var newTransaction = new AddSaleTransaction
        {
            UserId = userInfo.Id,
            MemberId = null,
            User = userInfo,
        };
        var transaction = await _paymentService.GetOrCreateSaleTransactionAsync(newTransaction);

        var tenders = _cartInfo.Tenders.Select(x => new TransactionTender
        {
            TransactionId = transaction.TransactionId,
            SequenceNumber = x.SequenceNumber,
            Amount = x.Amount,
            Description = x.Description,
            Type = x.Type,
        });

        var transactionItems = _cartInfo.CartItems.Select(x => new TransactionItem
        {
            ItemId = x.ItemId,
            Name = x.Name,
            UnitPrice = x.UnitPrice,
            TransactionId = transaction.TransactionId,
            RegularUnitPrice = x.RegularUnitPrice,
            ActualPriceExcludingTax = x.ActualPriceExcludingTax,
            ActualUnitPrice = x.ActualUnitPrice,
            BeforeDiscountPriceExcludingTax = x.ActualPriceExcludingTax,
            BeforeDiscountUnitPrice = x.BeforeDiscountUnitPrice,
            Discount = x.Discount,
            Tax = x.Tax,
            ExtendedDiscountAmount = x.ExtendedDiscountAmount,
            ExtendedPriceExcludingDiscount = x.ExtendedPriceExcludingDiscount,
            Quantity = x.Quantity,
            SequenceNumber = x.SequenceNumber,
        });

        var request = new ProcessSaleTransaction
        {
            UserId = userInfo.Id,
            CustomerId = null,
            TransactionId = transaction.TransactionId,
            SerialNumber = transaction.SerialNumber,
            ChangeAmount = _cartInfo.Tenders == null ? 0 : _cartInfo.Tenders.Sum(x => x.Amount),
            CreatedAt = DateTime.UtcNow,
            Description = string.Empty,
            IsVoided = false,
            IsCancelled = false,
            IsComplete = false,
            OpenCashDrawer = _cartInfo.Tenders.Where(x => x.Type == TenderType.Cash).Count() > 0,
            RoundedAmount = 0,
            RoundingAmount = 0,
            Type = 0,
            Taxes = _cartInfo.Taxes,
            Items = transactionItems.ToList(),
            Tenders = tenders,
        };

        var response = await _paymentService.ProcessSaleTransactionAsync(request);
        if (response.IsComplete)
        {
            Console.WriteLine("Payment success.");
            _localStorage.RemoveValue<BaseSaleTransaction>(Constants.Constant.SALE_TRANSACTION_KEY);
            await EmptyCart();
            OnChange.Invoke();
            // new receipt
            // replace cart component by  receipt component.
            // change place order to print receipt.

            _appState.Receipt = new Receipt
            {
                StoreName = "Point Of Sale",
                CreateAt = response.CreateDate,
                CustomerName = "Thanh Nguyen",
                TotalTax = response.TaxTotal,
            };
        }
    }

    public async Task UpdateCartInforAsync(CartInfo cartInfo)
    {
        await UpdateCartAsync(cartInfo);
    }
}
