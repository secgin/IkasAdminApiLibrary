# IkasAdminApiLibrary

[![NuGet](https://img.shields.io/nuget/v/IkasAdminApiLibrary.svg)](https://www.nuget.org/packages/IkasAdminApiLibrary)

.NET ile ikas Admin API v2 uzerinden urun, siparis, musteri, merchant, satis kanali, stok lokasyonu, fiyat listesi, webhook ve storefront islemleri icin istemci kutuphanesi.

v1 kodu `v1` branch'inde korunur. Bu branch ikas Admin API v2 endpoint'lerini kullanir.

## Dokumantasyon

- [v2 migration ve degisiklik notlari](docs/V2_MIGRATION.md)
- Ikas Admin API v2 Postman dokumani: https://documenter.getpostman.com/view/17621802/2sAYJ7eyUq

## Kurulum

```bash
dotnet add package IkasAdminApiLibrary
```

## NuGet Versiyonlama

GitHub Actions, `v*` veya `V*` tag push edildiginde NuGet paketi yayinlar. Tag adindaki `v` kaldirilir ve kalan kisim NuGet paket surumu olarak kullanilir.

Beta paket yayinlamak icin:

```bash
git tag v2.0.0-beta.1
git push origin v2.0.0-beta.1
```

Stable paket yayinlamak icin:

```bash
git tag v2.0.0
git push origin v2.0.0
```

Tag, 3 parcali SemVer formatinda olmalidir: `v2.0.0`, `v2.0.1`, `v2.0.0-beta.1`. `v2.0.0.0-beta` gibi 4 parcali surum kullanilmaz.

Lokal paket almak icin:

```bash
dotnet pack IkasAdminApiLibrary/IkasAdminApiLibrary.csproj -c Release /p:PackageVersion=2.0.0-beta.1 /p:Version=2.0.0-beta.1
```

## Client Olusturma

```csharp
using IkasAdminApiLibrary;
using IkasAdminApiLibrary.Abstracts;

IConfig config = new Config(
    clientId: "client-id",
    clientSecret: "client-secret",
    storeName: "store-name",
    tokenStoragePath: "token.json");

IIkasClient client = new IkasClient(config);
```

## Urun Listeleme

```csharp
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Products.Models.Inputs;

var result = await client.ProductManager.List(new ListProductInput
{
    Pagination = new PaginationInput(20, 1)
});

if (result.IsFail())
    throw new Exception($"{result.GetMessage()} ({result.GetCode()})");

foreach (var product in result.Data.Data)
    Console.WriteLine($"{product.Id} - {product.Name}");
```

## v2 Varyant Ekleme

v2'de varyant degeri yazarken ID yerine isim kullanilir:

```csharp
var result = await client.ProductManager.AddVariant(new AddVariantToProductInput
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
```

## v2 Manager'lar

- `ProductManager`
- `OrderManager`
- `CustomerManager`
- `MerchantManager`
- `SalesChannelsManager`
- `StockLcationManager`
- `PriceListsManager`
- `WebhookManager`
- `TimelineManager`
- `StorefrontManager`

## Test Console

Test console projesinde v1 ve v2 ornekleri ayri siniflarda tutulur:

- `V1Examples`
- `V2Examples`
