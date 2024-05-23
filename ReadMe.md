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
    - addItems to cart
    - select tender => confirm
    - send yêu cầu thanh toán 
    - xử lý thanh toán
    
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


Migration cmd:
dotnet ef --startup-project src/POS.Api/POS.Api.csproj migrations add create-database --context POSDbContext --output-dir DAL/Migrations --project src/POS.Infrastructure/POS.Infrastructure.csproj

dotnet ef --startup-project src/POS.Api database update


css config:
npx tailwindcss -i .\Styles\tailwind.css -o .\wwwroot\css\tailwind.css --watch

debugging:
https://stackoverflow.com/questions/73564523/blazor-hot-reload-debugging-using-vscode

-- add QR code feature
-- TODO
    + show category: done 
    + show product by category
    + add item to cart
    + payment 
    + select menu => show category
    + 

authorize/shift

=> đăng nhập => shift 
    1 shift => n users

    khi sign => join to shift
=> 

làm màn hình đăng nhập
=> implement chức năng đăng nhập
=> save thông tin claim user vào front end
=> sử dụng để call api add item to card 
=> 

Để hosting ứng dụng ASP.NET Core API backend và Blazor WebAssembly frontend, bạn có thể sử dụng Docker để container hóa ứng dụng và sau đó deploy lên một dịch vụ hosting phù hợp. Dưới đây là các bước cơ bản:

1. Tạo Dockerfile cho ASP.NET Core API và Blazor WebAssembly
Dockerfile cho Backend (ASP.NET Core API):

FROM mcr.microsoft.com/dotnet/aspnet:latest AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /src
COPY ["MyApi/MyApi.csproj", "MyApi/"]
RUN dotnet restore "MyApi/MyApi.csproj"
COPY . .
WORKDIR "/src/MyApi"
RUN dotnet build "MyApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyApi.dll"]
Dockerfile cho Frontend (Blazor WebAssembly):
Copy
Insert
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /source

# Copy csproj and restore as distinct layers
COPY ["MyBlazorApp/MyBlazorApp.csproj", "MyBlazorApp/"]
RUN dotnet restore "MyBlazorApp/MyBlazorApp.csproj"

# Copy everything else and build
COPY . .
WORKDIR "/source/MyBlazorApp"
RUN dotnet publish -c Release -o /app --no-restore

# Final stage/image
FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build /app .
COPY nginx.conf /etc/nginx/nginx.conf
2. Build và Push Docker Images lên Docker Registry
Build image cho backend:
Copy
Insert
docker build -t myapi:latest -f Dockerfile.api .
docker tag myapi:latest mydockerhubusername/myapi:latest
docker push mydockerhubusername/myapi:latest
Build image cho frontend:
docker build -t myblazorapp:latest -f Dockerfile.blazor .
docker tag myblazorapp:latest mydockerhubusername/myblazorapp:latest
docker push mydockerhubusername/myblazorapp:latest
3. Deploy lên Cloud Service hoặc Server
Bạn có thể deploy lên các dịch vụ như AWS, Azure, Google Cloud, hoặc một VPS.

4. Cấu hình Domain và Hosting
Mua domain từ nhà cung cấp domain.
Cấu hình DNS để trỏ domain về địa chỉ IP của server hoặc dịch vụ cloud.
Cấu hình SSL/TLS nếu cần cho kết nối an toàn.
5. Sử dụng Docker Compose hoặc Kubernetes
Nếu bạn muốn quản lý cả backend và frontend trên cùng một hệ thống, bạn có thể sử dụng docker-compose hoặc Kubernetes để orchestrate containers.

6. Cập nhật và Quản lý phiên bản
Định kỳ update images và containers.
Quản lý phiên bản dự án của bạn thông qua tags trên Docker images.
Lưu ý:
Đảm bảo bạn kiểm tra cấu hình bảo mật cho ứng dụng và containers.
Đối với Blazor WebAssembly, bạn có thể cần cấu hình reverse proxy để phục vụ các file tĩnh một cách hiệu quả.
Nhớ cấu hình CORS trên ASP.NET Core backend để cho phép truy cập từ Blazor frontend nếu chúng được host trên domain khác nhau.
Deploy ứng dụng lên môi trường production đôi khi có thể phức tạp, vì vậy đây chỉ là hướng dẫn cơ bản. Bạn có thể cần tìm hiểu thêm hoặc nhờ sự giúp đỡ từ cộng đồng hoặc các chuyên



task: blazor sate management
- blazor wasm
- ProductsComponent: hiển thị danh sách sản phẩm (product_name, product_id,.. quantity, price)
- ItemCartInputComponent: là child component của productsComponent, hiển thị số lượng sản phẩm
đang được thêm vào cartComponent, ItemCartInputComponent có 2 button IncreaseCartItemQuantity  và deIncreaseCartItemQuantity
và 1 thẻ input để hiển thị số lượng cartItem 
- CartComponent: hiển thị danh sách cartItem được thêm vào sau khi chọn tăng hoặc giảm số lượng ở  ItemCartInputComponent

dựa vào description ở trên hãy giúp tôi implement tính năng thêm sản phẩm vào giỏ hàng
sản phẩm sau khi được thêm vào cart sẽ lưu ở localstorage trong cartComponent
lưu lý khi thêm thì sẽ dùng IncreaseCartItemQuantity để thêm sản phẩm
nên cần đồng bộ số lượng của mỗi cartItem ở ItemCartInputComponent ở thẻ input và item quantity trong CartComponent




-config lai database
=> khóa chính tự tăng . ef core
=> item => categories như cũ

=> DTO vs query 
=> apply bussiness  payment process.

=> lược bớt phần workstation, => quản lý theo user đăng nhập


=> add CartItem to Cart
    => LookupItem
        include { Tax, Discount }
    => Call CalculatePaymentTransaction to calculate CartInfo
        get SaleTransaction update ui
    khi calculate trả về cờ IsCompletedTransaction thì call payment 
    or khi user chọn placer Order thì complete transaction
    => 

    // khi ứng dụng lần đầu chạy call api để get config, tax, club langulage  vv

    khi giỏ hàng có item thì cập nhật tạo transaction
    => khi process payment xong thì xóa transaction nếu có trong localstorage
    

    => làm thế nào để chọn 1 item trong cart?
    => chọn lấy model ứng với item đó
    => mở popup model 
    => load discounts on popup model by itemid
    => selected discounts => add discount to cart item
    => calculate cart
    => submit sale transaciton.