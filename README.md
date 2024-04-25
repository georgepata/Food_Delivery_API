# Food Delivery API

## Setting the connection string to secret manager
```powershell 
$sa_password = "[SA PASSWORD HERE]"
dotnet user-secrets set "ConnectionStrings:FoodDeliveryContext" "Server=localhost; Database=FoodDelivery; User Id=sa; Password= $sa_password; TrustServerCertificate=True"
```

<img width="1057" alt="Screenshot 2024-04-25 at 17 51 54" src="https://github.com/georgepata/Food_Delivery_API/assets/108401719/3b18b2f5-20a0-4689-914d-da6ba79f39e4">
