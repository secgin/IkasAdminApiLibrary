# IkasAdminApiLibrary

[![NuGet](https://img.shields.io/nuget/v/IkasAdminApiLibrary.svg)](https://www.nuget.org/packages/IkasAdminApiLibrary)

.NET ile [Ikas Admin API](https://ikas.com) üzerinden ürünlerinizi listeleyip yönetmenizi saðlayan basit bir istemci kütüphanedir.

## Kurulum

```bash
dotnet add package IkasAdminApiLibrary
```

## Ürün Listeleme Örneði
```csharp
var config = new Config([ClientId],[ClientSecret],[StoreName]);
var ikasClient = new IkasClient(config);

async Task<Pagination<Product>> GetProducts()
{
    var result = await ikasClient.ProductManager.List(new ListProductInput()
    {
        Name = StringFilterInput.Equal("ÜRÜN ADI"),
        Pagination = new PaginationInput(1, 1)
    });

    if (result.IsFail())
        throw new Exception($"Error fetching products: {result.GetMessage()}({result.GetCode()})");


    return result.Data;
}


var products = await GetProducts();
foreach (var product in products.Items)
{
    Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}");
}
```
