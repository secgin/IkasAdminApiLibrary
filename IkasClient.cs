using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Authentication;
using IkasAdminApiLibrary.Api.Authentication.Abstracts;
using IkasAdminApiLibrary.Api.Categories;
using IkasAdminApiLibrary.Api.Categories.Abstracts;
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
using IkasAdminApiLibrary.Api.SalesChannels;
using IkasAdminApiLibrary.Api.SalesChannels.Abstracts;
using IkasAdminApiLibrary.Api.StockLocations;
using IkasAdminApiLibrary.Api.StockLocations.Abstracts;
using IkasAdminApiLibrary.Api.VariantTypes;
using IkasAdminApiLibrary.Api.VariantTypes.Abstracts;
using IkasAdminApiLibrary.Api.Vendors;
using IkasAdminApiLibrary.Api.Vendors.Abstracts;
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
        private readonly Lazy<IPriceListsManager> priceListsManager;
        private readonly Lazy<IVendorService> vendorManager;

        public IkasClient(IConfig config)
        {
            this.config = config;
            httpRequest = new HttpRequest();
            tokenStorageManager = new TokenStorageManager();
            authenticationManager = new AuthenticationManager(this.config, tokenStorageManager, httpRequest);

            productBrandManager = new Lazy<IProductBrandManager>(() => new ProductBrandManager(graphQLService));
            categoryManager = new Lazy<ICategoryManager>(() => new CategoryManager(graphQLService));
            productManager = new Lazy<IProductManager>(() => new ProductManager(graphQLService));
            salesChannelsManager = new Lazy<ISalesChannelsManager>(() => new SalesChannelsManager(graphQLService));
            stockLocationManager = new Lazy<IStockLocationManager>(() => new StockLocationManager(graphQLService));
            variantTypeManager = new Lazy<IVariantTypeManager>(() => new VariantTypeManager(graphQLService));
            productImageManager = new Lazy<IProductImageManager>(() => new ProductImageManager(this.config, httpRequest, authenticationManager));
            productAttributeManager = new Lazy<IProductAttributeManager>(() => new ProductAttributeManager(graphQLService));
            priceListsManager = new Lazy<IPriceListsManager>(() => new PriceListsManager(graphQLService));
            vendorManager = new Lazy<IVendorService>(() => new VendorManager(graphQLService));
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
        public IPriceListsManager PriceListsManager => priceListsManager.Value;
        public IVendorService VendorManager => vendorManager.Value;
    }
}
