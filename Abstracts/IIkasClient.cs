using IkasAdminApiLibrary.Api.Categories.Abstracts;
using IkasAdminApiLibrary.Api.PriceLists.Abstracts;
using IkasAdminApiLibrary.Api.ProductAttributes.Abstracts;
using IkasAdminApiLibrary.Api.ProductBrands.Abstracts;
using IkasAdminApiLibrary.Api.ProductImages.Abstracts;
using IkasAdminApiLibrary.Api.Products.Abstracts;
using IkasAdminApiLibrary.Api.SalesChannels.Abstracts;
using IkasAdminApiLibrary.Api.StockLocations.Abstracts;
using IkasAdminApiLibrary.Api.VariantTypes.Abstracts;
using IkasAdminApiLibrary.Api.Vendors.Abstracts;

namespace IkasAdminApiLibrary.Abstracts
{
    public interface IIkasClient
    {
        public IProductManager ProductManager { get; }    

        public IProductBrandManager ProductBrandManager { get; }

        public ICategoryManager CategoryManager { get; }    

        public ISalesChannelsManager SalesChannelsManager { get; }

        public IStockLocationManager StockLcationManager { get; }

        public IVariantTypeManager VariantTypeManager { get; }

        public IProductImageManager ProductImageManager { get; }

        public IProductAttributeManager ProductAttributeManager { get; }

        public IPriceListsManager PriceListsManager { get; }

        public IVendorService VendorManager { get; }
    }
}
