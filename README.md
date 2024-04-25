# Food Delivery API

## Setting the connection string to secret manager
```powershell 
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:FoodDeliveryContext" "Server=localhost; Database=FoodDelivery; User Id=sa; Password= $sa_password; TrustServerCertificate=True"
```