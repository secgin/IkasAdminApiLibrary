# Ikas Admin API v2 Degisiklikleri

Bu dokuman, kutuphanenin `v1` branch'inden `v2` branch'ine gecisinde yapilan teknik degisiklikleri ve kullanim farklarini aciklar.

Kaynak API dokumani: https://documenter.getpostman.com/view/17621802/2sAYJ7eyUq

## Ozet

v2 sadece endpoint degisikligi degildir. Urun yazma modeli, varyant degeri gonderme sekli, webhook mutation adi, token endpoint'i ve response null davranisi v1'e gore farklidir. Ayrica v2 ile siparis, musteri, merchant, timeline ve storefront modulleri kutuphaneye eklenmistir.

## Branch Yapisi

- `v1`: Eski Ikas Admin API v1 uyumlu kod.
- `v2`: Ikas Admin API v2 uyumlu kod.

Test console projesinde iki ornek sinifi bulunur:

- `V1Examples`
- `V2Examples`

## Endpoint Degisiklikleri

| Alan | v1 | v2 |
| --- | --- | --- |
| GraphQL | `https://api.myikas.com/api/v1/admin/graphql` | `https://api.myikas.com/api/v2/admin/graphql` |
| OAuth token | `https://{storeName}.myikas.com/api/admin/oauth/token` | `https://api.myikas.com/api/admin/oauth/token` |
| Product image upload | `https://api.myikas.com/api/v1/admin/product/upload/image` | `https://api.myikas.com/api/v2/admin/upload/image` |

Bu degisiklikler `Config` icinde yapildi.

## GraphQL Servis Degisiklikleri

v1'de sorgular agirlikli olarak `GraphQL.Query.Builder` ile uretiliyordu. v2 dokumanindaki input ve selection set'ler daha genis oldugu icin `GraphQLService` icine raw GraphQL query destegi eklendi:

```csharp
Task<IResult<T>> QueryAsync<T>(string query, object? variables, string path);
Task<IResult<T>> MutationQueryAsync<T>(string query, object? variables, string path);
```

Request variables serilestirilirken:

- Property isimleri camelCase olarak gonderilir.
- Enum degerleri string olarak gonderilir.
- Null variable alanlari GraphQL input'a dahil edilmez.

Response deserialize edilirken date alanlari Unix millisecond timestamp olarak parse edilir.

## Auth Degisiklikleri

`AuthenticationManager` v2 token endpoint'ini kullanir.

Ek olarak refresh token akisi icin metot eklendi:

```csharp
Task<Token?> RefreshAccessToken(string refreshToken);
```

`Token` modeline `RefreshToken` alani eklendi. Token storage refresh token'i de saklar.

## Yeni Manager'lar

v2 branch'inde `IIkasClient` uzerinden su manager'lara erisilebilir:

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

Not: `StockLcationManager` property adindaki eski yazim korunmustur. Public API kirilmamasi icin isim degistirilmedi.

## Urun API Degisiklikleri

v1'de urun kaydetme akisi agirlikli olarak `saveProduct` uzerinden ilerliyordu. v2 dokumaninda urun operasyonlari ayrildi:

- `listProduct`
- `createProduct`
- `updateProduct`
- `addVariantToProduct`
- `updateVariantPrices`
- `saveVariantStocks`
- `updateProductSalesChannelStatus`

Kutuphanede bunlar su metotlarla temsil edilir:

```csharp
Task<IResult<Pagination<Product>>> List(ListProductInput? input = null);
Task<IResult<Product>> Create(CreateProductInput input);
Task<IResult<Product>> Update(UpdateProductInput input);
Task<IResult<Product>> AddVariant(AddVariantToProductInput input);
Task<IResult<UpdateVariantPricesResult>> UpdateVariantPrices(UpdateVariantPricesInput input);
Task<IResult<SaveVariantStocksResult>> SaveVariantStocks(SaveVariantStocksInputV2 input);
Task<IResult<UpdateSalesChannelStatusResult>> UpdateSalesChannelStatus(UpdateSalesChannelStatusInput input);
```

### Varyant Degeri Farki

v1'de varyant degeri yazarken ID tabanli alanlar kullaniliyordu:

```csharp
new VariantValueRelationInput("variant-type-id", "variant-value-id")
```

v2'de `createProduct` ve `addVariantToProduct` input'lari ID alanlarini kabul etmez. v2 input tipi isim tabanlidir:

```csharp
new CreateVariantValueInput
{
    VariantTypeName = "Renk",
    VariantValueName = "Siyah"
}
```

Hatalı v2 payload ornegi:

```json
{
  "variantTypeId": null,
  "variantTypeName": "Renk",
  "variantValueId": null,
  "variantValueName": "Siyah"
}
```

Bu payload v2 tarafinda hata verir. Bu nedenle `CreateVariantValueInput` modelinden `VariantTypeId` ve `VariantValueId` alanlari kaldirildi.

Response tarafinda ise `variantValues` icinde ID alanlari hala doner:

```json
{
  "variantTypeId": "...",
  "variantTypeName": "Renk",
  "variantValueId": "...",
  "variantValueName": "Siyah"
}
```

Yani v2'de yazarken isim, okurken hem ID hem isim kullanilir.

### Eski ProductInput Uyumlulugu

`Save(ProductInput)` metodu kaynak uyumlulugu icin korunmustur. Ancak `ProductInput.Variants[].VariantValueIds` doluysa v2 API'ye hatali request gonderilmez; kutuphane su hata koduyla doner:

```text
UNSUPPORTED_VARIANT_VALUE_ID_INPUT
```

v2 varyantli urun veya varyant ekleme icin `CreateProductInput` ve `AddVariantToProductInput` kullanilmalidir.

### Varyant Ekleme Ornegi

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

### Iliski Input'lari

v1'de urun input'unda sikca ID listeleri kullaniliyordu:

- `BrandId`
- `CategoryIds`
- `TagIds`
- `VendorId`
- `SalesChannelIds`

v2 create/update input'larinda bu alanlar nesne olarak temsil edilir:

```csharp
Brand = new ProductRelationInput
{
    Name = "Marka"
};

Categories =
[
    new ProductCategoryRelationInput
    {
        Name = "Kategori",
        Path = "Ust Kategori > Alt Kategori"
    }
];
```

## Fiyat, Stok ve Satis Kanali Guncelleme

v2'de fiyat, stok ve satis kanali guncelleme operasyonlari bulk result doner. Result icinde `Errors` listesi vardir.

Ornek:

```csharp
var result = await client.ProductManager.UpdateVariantPrices(new UpdateVariantPricesInput
{
    VariantPriceInputs =
    [
        new VariantPriceUpdateInput
        {
            ProductId = "product-id",
            VariantId = "variant-id",
            Price = new VariantPriceValueInput
            {
                SellPrice = 100
            }
        }
    ]
});

if (result.IsSuccess() && result.Data.Errors.Count == 0)
{
    // Basarili
}
```

## Product Image Upload

v2 image upload endpoint'i degisti. `UploadProductImageInput` su alanlari destekler:

- `ProductId`
- `VariantIds`
- `Url`
- `Base64`
- `Order`
- `IsMain`

## Webhook Degisikligi

v1'de mutation adi `saveWebhook` idi. v2 dokumaninda mutation adi `saveWebhooks` olarak geciyor.

Kutuphanede `WebhookManager.SaveAsync(WebhookInput input)` imzasi korundu; iceride v2 `saveWebhooks` mutation'i kullanilir.

## Yeni Moduller

### Orders

`OrderManager` ile eklenen operasyonlar:

- `List`
- `ListTransactions`
- `Fulfill`
- `UpdatePackageStatus`
- `ListTags`
- `CreateTag`
- `AddTag`
- `AddInvoice`
- `CancelFulfillment`

### Customers

`CustomerManager.List` ile musteri listeleme ve arama desteklenir.

### Merchant

`MerchantManager` ile:

- `Get`
- `ListSettings`

### Timeline

`TimelineManager.AddOrderTimelineEntry` ile siparis zaman cizelgesine mesaj eklenir.

### Storefront

`StorefrontManager` ile:

- `List`
- `CreateJSScript`
- `UpdateJSScript`

## Null Response Davranisi

v2 response'larinda bazi alanlar dokumanda bool veya number gibi gorunse bile `null` donebilir. Ornek:

```json
{
  "isVideo": null,
  "sellIfOutOfStock": null,
  "weight": null
}
```

Bu nedenle response modellerindeki value type alanlar nullable yapildi:

- `bool?`
- `int?`
- `float?`
- `double?`
- enum alanlarinda `EnumType?`
- tarih alanlarinda `DateTime?`

Input modellerinde ise zorunlu alanlar non-nullable tutuldu.

## Test Console

Test console artik ornekleri iki sinifta tutar:

```csharp
var v1Examples = new V1Examples(client);
var v2Examples = new V2Examples(client);
```

`Program.cs` icinde calistirilmak istenen ornek yorum satirindan cikarilir.

## Gecis Kontrol Listesi

v1 kullanan bir kodu v2'ye tasirken su alanlari kontrol edin:

- `Config` v2 endpoint'lerini kullaniyor mu?
- `ProductManager.Save(ProductInput)` yerine native v2 metotlari kullaniliyor mu?
- Varyant degeri yazarken ID yerine isim kullaniliyor mu?
- Fiyat/stok/satis kanali update sonucunda `Errors` listesi kontrol ediliyor mu?
- Response alanlari nullable kabul ediliyor mu?
- Webhook kaydinda `saveWebhooks` davranisi bekleniyor mu?
- Test console'da v1 ve v2 ornekleri karistirilmiyor mu?
