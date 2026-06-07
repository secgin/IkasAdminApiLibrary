using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Authentication;
using IkasAdminApiLibrary.Api.Authentication.Abstracts;
using IkasAdminApiLibrary.Api.Categories;
using IkasAdminApiLibrary.Api.Categories.Abstracts;
using IkasAdminApiLibrary.Api.Customers;
using IkasAdminApiLibrary.Api.Customers.Abstracts;
using IkasAdminApiLibrary.Api.Merchants;
using IkasAdminApiLibrary.Api.Merchants.Abstracts;
using IkasAdminApiLibrary.Api.Orders;
using IkasAdminApiLibrary.Api.Orders.Abstracts;
using IkasAdminApiLibrary.Api.PriceLists;
using IkasAdminApiLibrary.Api.PriceLists.Abstracts;
using IkasAdminApiLibrary.Api.ProductAttributes;
using IkasAdminApiLibrary.Api.ProductAttributes.Abstracts;
using IkasAdminApiLibrary.Api.ProductBrands;
using IkasAdminApiLibrary.Api.ProductBrands.Abstracts;
using IkasAdminApiLibrary.Api.ProductImages;
using IkasAdminApiLibrary.Api.ProductImages.Abstracts;
using IkasAdminApiLibrary.Api.Products;
using IkasAdminApiLibrary.Api.Products.Abstracts;
using IkasAdminApiLibrary.Api.ProductTags;
using IkasAdminApiLibrary.Api.ProductTags.Abstracts;
using IkasAdminApiLibrary.Api.SalesChannels;
using IkasAdminApiLibrary.Api.SalesChannels.Abstracts;
using IkasAdminApiLibrary.Api.StockLocations;
using IkasAdminApiLibrary.Api.StockLocations.Abstracts;
using IkasAdminApiLibrary.Api.Storefronts;
using IkasAdminApiLibrary.Api.Storefronts.Abstracts;
using IkasAdminApiLibrary.Api.Timeline;
using IkasAdminApiLibrary.Api.Timeline.Abstracts;
using IkasAdminApiLibrary.Api.VariantTypes;
using IkasAdminApiLibrary.Api.VariantTypes.Abstracts;
using IkasAdminApiLibrary.Api.Vendors;
using IkasAdminApiLibrary.Api.Vendors.Abstracts;
using IkasAdminApiLibrary.Api.Webhooks;
using IkasAdminApiLibrary.Api.Webhooks.Abstracts;
using IkasAdminApiLibrary.Library.HttpRequest;
using IkasAdminApiLibrary.Library.HttpRequest.Interfaces;

namespace IkasAdminApiLibrary
{
    public class IkasClient : IIkasClient
    {
        private readonly IConfig config;
        private readonly IHttpRequest httpRequest;
        private readonly ITokenStorageManager tokenStorageManager;
        private readonly IAuthenticationManager authenticationManager;
        private readonly Lazy<IProductBrandManager> productBrandManager;
        private readonly Lazy<ICategoryManager> categoryManager;
        private readonly Lazy<IProductManager> productManager;
        private readonly Lazy<ISalesChannelsManager> salesChannelsManager;
        private readonly Lazy<IStockLocationManager> stockLocationManager;
        private readonly Lazy<IVariantTypeManager> variantTypeManager;
        private readonly Lazy<IProductImageManager> productImageManager;
        private readonly Lazy<IProductAttributeManager> productAttributeManager;
        private readonly Lazy<IProductTagManager> productTagManager;
        private readonly Lazy<IPriceListsManager> priceListsManager;
        private readonly Lazy<IVendorService> vendorManager;
        private readonly Lazy<IWebhookManager> webhookManager;
        private readonly Lazy<IOrderManager> orderManager;
        private readonly Lazy<ICustomerManager> customerManager;
        private readonly Lazy<IMerchantManager> merchantManager;
        private readonly Lazy<ITimelineManager> timelineManager;
        private readonly Lazy<IStorefrontManager> storefrontManager;

        public IkasClient(IConfig config)
        {
            this.config = config;
            httpRequest = new HttpRequest();
            tokenStorageManager = new TokenStorageManager(this.config);
            authenticationManager = new AuthenticationManager(this.config, tokenStorageManager, httpRequest);

            productBrandManager = new Lazy<IProductBrandManager>(() => new ProductBrandManager(graphQLService));
            categoryManager = new Lazy<ICategoryManager>(() => new CategoryManager(graphQLService));
            productManager = new Lazy<IProductManager>(() => new ProductManager(graphQLService));
            salesChannelsManager = new Lazy<ISalesChannelsManager>(() => new SalesChannelsManager(graphQLService));
            stockLocationManager = new Lazy<IStockLocationManager>(() => new StockLocationManager(graphQLService));
            variantTypeManager = new Lazy<IVariantTypeManager>(() => new VariantTypeManager(graphQLService));
            productImageManager = new Lazy<IProductImageManager>(() => new ProductImageManager(this.config, httpRequest, authenticationManager));
            productAttributeManager = new Lazy<IProductAttributeManager>(() => new ProductAttributeManager(graphQLService));
            productTagManager = new Lazy<IProductTagManager>(() => new ProductTagManager(graphQLService));
            priceListsManager = new Lazy<IPriceListsManager>(() => new PriceListsManager(graphQLService));
            vendorManager = new Lazy<IVendorService>(() => new VendorManager(graphQLService));
            webhookManager = new Lazy<IWebhookManager>(() => new WebhookManager(graphQLService));
            orderManager = new Lazy<IOrderManager>(() => new OrderManager(graphQLService));
            customerManager = new Lazy<ICustomerManager>(() => new CustomerManager(graphQLService));
            merchantManager = new Lazy<IMerchantManager>(() => new MerchantManager(graphQLService));
            timelineManager = new Lazy<ITimelineManager>(() => new TimelineManager(graphQLService));
            storefrontManager = new Lazy<IStorefrontManager>(() => new StorefrontManager(graphQLService));
        }

        private IGraphQLService graphQLService => new GraphQLService(this.config, httpRequest, authenticationManager);

        public IProductBrandManager ProductBrandManager => productBrandManager.Value;
        public ICategoryManager CategoryManager => categoryManager.Value;
        public IProductManager ProductManager => productManager.Value;
        public ISalesChannelsManager SalesChannelsManager => salesChannelsManager.Value;
        public IStockLocationManager StockLcationManager => stockLocationManager.Value;
        public IVariantTypeManager VariantTypeManager => variantTypeManager.Value;
        public IProductImageManager ProductImageManager => productImageManager.Value;
        public IProductAttributeManager ProductAttributeManager => productAttributeManager.Value;
        public IProductTagManager ProductTagManager => productTagManager.Value;
        public IPriceListsManager PriceListsManager => priceListsManager.Value;
        public IVendorService VendorManager => vendorManager.Value;
        public IWebhookManager WebhookManager => webhookManager.Value;
        public IOrderManager OrderManager => orderManager.Value;
        public ICustomerManager CustomerManager => customerManager.Value;
        public IMerchantManager MerchantManager => merchantManager.Value;
        public ITimelineManager TimelineManager => timelineManager.Value;
        public IStorefrontManager StorefrontManager => storefrontManager.Value;
    }
}
