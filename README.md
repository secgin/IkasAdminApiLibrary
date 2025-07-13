# IkasAdminApiLibrary

[![NuGet](https://img.shields.io/nuget/v/IkasAdminApiLibrary.svg)](https://www.nuget.org/packages/IkasAdminApiLibrary)

.NET ile [Ikas Admin API](https://ikas.com) �zerinden �r�nlerinizi listeleyip y�netmenizi sa�layan basit bir istemci k�t�phanedir.

## Kurulum

```bash
dotnet add package IkasAdminApiLibrary
```

## �r�n Listeleme �rne�i
```csharp
var config = new Config([ClientId],[ClientSecret],[StoreName]);
var ikasClient = new IkasClient(config);

async Task<Pagination<Product>> GetProducts()
{
    var result = await ikasClient.ProductManager.List(new ListProductInput()
    {
        Name = StringFilterInput.Equal("�R�N ADI"),
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
