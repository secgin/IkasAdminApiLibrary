# IkasAdminApiLibrary

[![NuGet](https://img.shields.io/nuget/v/IkasAdminApiLibrary.svg)](https://www.nuget.org/packages/IkasAdminApiLibrary)

.NET ile [Ikas Admin API](https://ikas.com) üzerinden ürünlerinizi listeleyip yönetmenizi sağlayan basit bir istemci kütüphanedir.

## Kurulum

```bash
dotnet add package IkasAdminApiLibrary
```

## Ürün Listeleme Örneği
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

## V1 Akisinda Varyant Ekleme

Mevcut v1 endpoint'leri aynen kullanilmaya devam eder. Sadece mevcut urune varyant ekleme islemi icin `AddVariant` metodu Ikas'in v2 `addVariantToProduct` mutation'ini cagirir.

```csharp
var result = await ikasClient.ProductManager.AddVariant(new AddVariantToProductInput
{
    ProductId = "product-id",
    Variant = new CreateProductVariantInput
    {
        IsActive = true,
        Sku = "SKU-SIYAH",
        Prices =
        [
            new ProductPriceInput(100)
        ],
        VariantValues =
        [
            new CreateVariantValueInput
            {
                VariantTypeName = "Renk",
                VariantValueName = "Siyah"
            }
        ]
    }
});

if (result.IsFail())
    throw new Exception($"{result.GetMessage()} ({result.GetCode()})");

Console.WriteLine($"Updated Product ID: {result.Data.Id}");
```
