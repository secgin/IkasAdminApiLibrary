using IkasAdminApiLibrary.Api.Categories.Abstracts;
using IkasAdminApiLibrary.Api.Customers.Abstracts;
using IkasAdminApiLibrary.Api.Merchants.Abstracts;
using IkasAdminApiLibrary.Api.Orders.Abstracts;
using IkasAdminApiLibrary.Api.PriceLists.Abstracts;
using IkasAdminApiLibrary.Api.ProductAttributes.Abstracts;
using IkasAdminApiLibrary.Api.ProductBrands.Abstracts;
using IkasAdminApiLibrary.Api.ProductImages.Abstracts;
using IkasAdminApiLibrary.Api.Products.Abstracts;
using IkasAdminApiLibrary.Api.ProductTags.Abstracts;
using IkasAdminApiLibrary.Api.SalesChannels.Abstracts;
using IkasAdminApiLibrary.Api.StockLocations.Abstracts;
using IkasAdminApiLibrary.Api.Storefronts.Abstracts;
using IkasAdminApiLibrary.Api.Timeline.Abstracts;
using IkasAdminApiLibrary.Api.VariantTypes.Abstracts;
using IkasAdminApiLibrary.Api.Vendors.Abstracts;
using IkasAdminApiLibrary.Api.Webhooks.Abstracts;

namespace IkasAdminApiLibrary.Abstracts
{
    public interface IIkasClient
    {
        IProductManager ProductManager { get; }    

        IProductBrandManager ProductBrandManager { get; }

        ICategoryManager CategoryManager { get; }    

        ISalesChannelsManager SalesChannelsManager { get; }

        IStockLocationManager StockLcationManager { get; }

        IVariantTypeManager VariantTypeManager { get; }

        IProductImageManager ProductImageManager { get; }

        IProductAttributeManager ProductAttributeManager { get; }

        IProductTagManager ProductTagManager { get; }

        IPriceListsManager PriceListsManager { get; }

        IVendorService VendorManager { get; }

        IWebhookManager WebhookManager { get; }

        IOrderManager OrderManager { get; }

        ICustomerManager CustomerManager { get; }

        IMerchantManager MerchantManager { get; }

        ITimelineManager TimelineManager { get; }

        IStorefrontManager StorefrontManager { get; }
    }
}
