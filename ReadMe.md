# Document

### Use Cases:


### Product
1. Create product
2. Update product
3. Delete product

### User
1. Sign in/ Sign up
2. Authorize the payment request.


## Payment process
1. Search item by item name
2. Add item to cart
2.1 include Tax/Discount/Promotion
3. Checkout 
    => call api Create order
    => wating to aprove
    => aproved or cancel
    => ...

4. Payment: Tender (Cash/Visa/Momo)
    
5. Shipping 

-- Why we need using the Dependency Injection on my project?

-- Tại sao để security ở application mà ko phải domain như là repository hay policy or time etc.


### Blazor zone
1. Layout
2. Navigation/Route
3. Authorization
4. 
    
### Funtional

- Get product detail
1. Get productid
2. call api GetProductById
3. send product-detail to Productdetail pages
4.

- Add Item to cart
1. SignUp => create Cart for user
2. call api add item to cart
3. remove item from cart


- Authentication (client-size)
1. handle navigate to other page show/hide html
2. handle store token, get token using token when call api  must using authorization.
3. read and undestanding the flow of authentication.

- jwt bao gồm những thành phần nào?
- jwt là gì
- sử dụng ở phía server như thế nào
- sử dụng ở phía client ra làm sao

- SOLID =>  liệt kê và đọc hiểu +  ví dụ


- css flex
- css grid
- css BEM
- css practice

- html 

- blazor lifecycle 
- blazor layout/component
- blaozr fundamental


=> Application  use-case/features
=> Domain => core of app
=> Infrasture => implementation.

=> save the link of task for the next day do the coder coder

https://www.youtube.com/watch?v=sHuuo9L3e5c&t=5701s
https://www.youtube.com/watch?v=uaqwuXvQf2Y
https://codemurals.blogspot.com/2021/06/local-storage-in-blazor-using-blazored.html
https://theplanbrand.com/account/login?return_url=%2Faccount


Migration:
- dotnet ef migrations add Initial --context EsportshubApi.Models.ApplicationDbContext -o YourFolderPath
dotnet ef  migrations add Initial --context  MyShopDbContext -o MyShop.Infrastructure/DAL/Migrations


dotnet ef migrations add Initial --project MyShop.Infrastructure --startup-project MyShop.Api --output-dir MyShop.Infrastructure\DAL\Migrations


dotnet ef --startup-project ./POS.Api/POS.Api.csproj migrations add initDatabase --context MyShopDbContext --output-dir ./POS.Infrastructure/DAL/Migrations --project ../POS.Infrastructure/POS.Infrastructure.csproj
