using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Products.Abstracts;
using IkasAdminApiLibrary.Api.Products.Models;
using IkasAdminApiLibrary.Api.Products.Models.Inputs;
using IkasAdminApiLibrary.Api.Products.Models.Response;

namespace IkasAdminApiLibrary.Api.Products
{
    internal class ProductManager : IProductManager
    {
        private const string ProductFields = """
            attributes {
              imageIds
              productAttributeId
              productAttributeOptionId
              value
            }
            baseUnit {
              baseAmount
              type
              unitId
            }
            brand {
              id
              name
            }
            categories {
              id
              name
            }
            createdAt
            deleted
            description
            dynamicPriceListIds
            googleTaxonomyId
            id
            maxQuantityPerCart
            metaData {
              id
              slug
            }
            name
            productOptionSetId
            productVolumeDiscountId
            salesChannels {
              id
              maxQuantityPerCart
              minQuantityPerCart
              productVolumeDiscountId
              quantitySettings
              status
            }
            shortDescription
            tags {
              id
              name
            }
            totalStock
            translations {
              description
              locale
              name
            }
            type
            updatedAt
            variants {
              barcodeList
              createdAt
              deleted
              hsCode
              id
              images {
                fileName
                imageId
                isMain
                isVideo
                order
              }
              isActive
              prices {
                buyPrice
                currency
                currencyCode
                currencySymbol
                discountPrice
                priceListId
                sellPrice
              }
              sellIfOutOfStock
              sku
              stocks {
                createdAt
                deleted
                id
                productId
                stockCount
                stockLocationId
                updatedAt
                variantId
              }
              unit {
                amount
                type
              }
              updatedAt
              variantValues {
                variantTypeId
                variantTypeName
                variantValueId
                variantValueName
              }
              weight
            }
            vendor {
              id
              name
            }
            weight
            """;

        private const string ListProductQuery = """
            query ListProduct($pagination: PaginationInput) {
              listProduct(pagination: $pagination) {
                count
                data {
                  attributes {
                    imageIds
                    productAttributeId
                    productAttributeOptionId
                    value
                  }
                  baseUnit {
                    baseAmount
                    type
                    unitId
                  }
                  brand {
                    id
                    name
                  }
                  categories {
                    id
                    name
                  }
                  createdAt
                  deleted
                  description
                  dynamicPriceListIds
                  googleTaxonomyId
                  id
                  maxQuantityPerCart
                  metaData {
                    id
                    slug
                  }
                  name
                  productOptionSetId
                  productVolumeDiscountId
                  salesChannels {
                    id
                    maxQuantityPerCart
                    minQuantityPerCart
                    productVolumeDiscountId
                    quantitySettings
                    status
                  }
                  shortDescription
                  tags {
                    id
                    name
                  }
                  totalStock
                  translations {
                    description
                    locale
                    name
                  }
                  type
                  updatedAt
                  variants {
                    barcodeList
                    createdAt
                    deleted
                    hsCode
                    id
                    images {
                      fileName
                      imageId
                      isMain
                      isVideo
                      order
                    }
                    isActive
                    prices {
                      buyPrice
                      currency
                      currencyCode
                      currencySymbol
                      discountPrice
                      priceListId
                      sellPrice
                    }
                    sellIfOutOfStock
                    sku
                    stocks {
                      createdAt
                      deleted
                      id
                      productId
                      stockCount
                      stockLocationId
                      updatedAt
                      variantId
                    }
                    unit {
                      amount
                      type
                    }
                    updatedAt
                    variantValues {
                      variantTypeId
                      variantTypeName
                      variantValueId
                      variantValueName
                    }
                    weight
                  }
                  vendor {
                    id
                    name
                  }
                  weight
                }
                hasNext
                limit
                page
              }
            }
            """;

        private const string UpdateVariantPricesQuery = """
            mutation UpdateVariantPrices($input: UpdateVariantPricesInput!) {
              updateVariantPrices(input: $input) {
                errors {
                  errorCode
                  inputArrayIndex
                  inputData {
                    variantId
                    productId
                    price {
                      buyPrice
                      discountPrice
                      sellPrice
                    }
                  }
                }
              }
            }
            """;

        private const string SaveVariantStocksQuery = """
            mutation SaveVariantStocks($input: SaveVariantStocksInput!) {
              saveVariantStocks(input: $input) {
                errors {
                  errorCode
                  inputArrayIndex
                  inputData {
                    productId
                    variantId
                  }
                }
              }
            }
            """;

        private const string UpdateProductSalesChannelStatusQuery = """
            mutation UpdateProductSalesChannelStatus($input: UpdateSalesChannelStatusInput!) {
              updateProductSalesChannelStatus(input: $input) {
                errors {
                  errorCode
                  inputArrayIndex
                  inputData {
                    productId
                    status
                  }
                }
              }
            }
            """;

        private readonly IGraphQLService graphQLService;

        public ProductManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<Pagination<Product>>> List(ListProductInput? input = null)
        {
            return await graphQLService.QueryAsync<Pagination<Product>>(
                ListProductQuery,
                new { pagination = input?.Pagination },
                "listProduct");
        }

        public async Task<IResult<Product>> Create(CreateProductInput input)
        {
            return await graphQLService.MutationQueryAsync<Product>(
                ProductMutation("CreateProduct", "createProduct", "CreateProductInput"),
                new { input },
                "createProduct");
        }

        public async Task<IResult<Product>> Update(UpdateProductInput input)
        {
            return await graphQLService.MutationQueryAsync<Product>(
                ProductMutation("UpdateProduct", "updateProduct", "UpdateProductInput"),
                new { input },
                "updateProduct");
        }

        public async Task<IResult<Product>> AddVariant(AddVariantToProductInput input)
        {
            return await graphQLService.MutationQueryAsync<Product>(
                ProductMutation("AddVariantToProduct", "addVariantToProduct", "AddVariantToProductInput"),
                new { input },
                "addVariantToProduct");
        }

        public async Task<IResult<UpdateVariantPricesResult>> UpdateVariantPrices(UpdateVariantPricesInput input)
        {
            return await graphQLService.MutationQueryAsync<UpdateVariantPricesResult>(
                UpdateVariantPricesQuery,
                new { input },
                "updateVariantPrices");
        }

        public async Task<IResult<SaveVariantStocksResult>> SaveVariantStocks(SaveVariantStocksInputV2 input)
        {
            return await graphQLService.MutationQueryAsync<SaveVariantStocksResult>(
                SaveVariantStocksQuery,
                new { input },
                "saveVariantStocks");
        }

        public async Task<IResult<UpdateSalesChannelStatusResult>> UpdateSalesChannelStatus(UpdateSalesChannelStatusInput input)
        {
            return await graphQLService.MutationQueryAsync<UpdateSalesChannelStatusResult>(
                UpdateProductSalesChannelStatusQuery,
                new { input },
                "updateProductSalesChannelStatus");
        }

        public async Task<IResult<Product>> Save(ProductInput productInput)
        {
            if (HasLegacyVariantValueIds(productInput))
            {
                return Result<Product>.Fail(
                    "UNSUPPORTED_VARIANT_VALUE_ID_INPUT",
                    "Ikas Admin API v2 create/add variant input accepts variantTypeName and variantValueName. Use CreateProductInput or AddVariantToProductInput with CreateVariantValueInput names instead of v1 variant type/value ids.");
            }

            if (!string.IsNullOrWhiteSpace(productInput.Id))
                return await Update(ToUpdateProductInput(productInput));

            return await Create(ToCreateProductInput(productInput));
        }

        public async Task<IResult<bool>> SaveVariantPrices(SaveVariantPricesInput saveVariantPricesInput)
        {
            var result = await UpdateVariantPrices(new UpdateVariantPricesInput
            {
                PriceListId = saveVariantPricesInput.PriceListId,
                VariantPriceInputs = saveVariantPricesInput.VariantPriceInputs
                    .Select(input => new VariantPriceUpdateInput
                    {
                        ProductId = input.ProductId,
                        VariantId = input.VariantId,
                        Price = new VariantPriceValueInput
                        {
                            BuyPrice = input.Price.BuyPrice,
                            DiscountPrice = input.Price.DiscountPrice,
                            SellPrice = input.Price.SellPrice
                        }
                    })
                    .ToList()
            });

            if (result.IsFail())
                return Result<bool>.Fail(result.GetCode(), result.GetMessage());

            return Result<bool>.Success(result.Data.Errors.Count == 0);
        }

        public async Task<IResult<ProductSearchResponse>> Search(SearchProductInput searchInput)
        {
            var query = graphQLService.CreateQuery<ProductSearchResponse>("searchProducts")
                .AddArguments(new
                {
                    input = searchInput
                })
                .AddField(p => p.Count)
                .AddField(p => p.Results, d => d
                    .AddField(p => p.Id)
                    .AddField(p => p.Name)
                    .AddField(p => p.Type)
                    .AddField(vp => vp.Variants, v => v
                        .AddField(p => p.Id)
                        .AddField(p => p.Sku)
                        .AddField(sv => sv.VariantValues!, v => v
                            .AddField(p => p.VariantTypeId)
                            .AddField(p => p.VariantValueId)
                        )
                    ))
                .AddField(p => p.Limit)
                .AddField(p => p.Page)
                .AddField(p => p.TotalCount);

            return await graphQLService.QueryAsync<ProductSearchResponse>(query, "searchProducts");
        }

        private static string ProductMutation(string operationName, string fieldName, string inputType)
        {
            return $$"""
                mutation {{operationName}}($input: {{inputType}}!) {
                  {{fieldName}}(input: $input) {
                {{ProductFields}}
                  }
                }
                """;
        }

        private static CreateProductInput ToCreateProductInput(ProductInput input)
        {
            return new CreateProductInput
            {
                Name = input.Name,
                Type = input.Type,
                Description = input.Description,
                ShortDescription = input.ShortDescription,
                MetaData = input.MetaData,
                Brand = string.IsNullOrWhiteSpace(input.BrandId) ? null : new ProductRelationInput { Id = input.BrandId },
                Vendor = string.IsNullOrWhiteSpace(input.VendorId) ? null : new ProductRelationInput { Id = input.VendorId },
                Categories = input.CategoryIds?.Select(id => new ProductCategoryRelationInput { Id = id }).ToList() ?? [],
                SalesChannels = input.SalesChannelIds.Select(id => new ProductSalesChannelInput { Id = id }).ToList(),
                Tags = input.TagIds?.Select(id => new ProductRelationInput { Id = id }).ToList() ?? [],
                Variants = input.Variants.Select(ToCreateProductVariantInput).ToList()
            };
        }

        private static UpdateProductInput ToUpdateProductInput(ProductInput input)
        {
            return new UpdateProductInput
            {
                Id = input.Id ?? string.Empty,
                Name = input.Name,
                Type = input.Type,
                Description = input.Description,
                ShortDescription = input.ShortDescription,
                MetaData = input.MetaData,
                Brand = string.IsNullOrWhiteSpace(input.BrandId) ? null : new ProductRelationInput { Id = input.BrandId },
                Vendor = string.IsNullOrWhiteSpace(input.VendorId) ? null : new ProductRelationInput { Id = input.VendorId },
                Categories = input.CategoryIds?.Select(id => new ProductCategoryRelationInput { Id = id }).ToList(),
                SalesChannels = input.SalesChannelIds.Select(id => new ProductSalesChannelInput { Id = id }).ToList(),
                Tags = input.TagIds?.Select(id => new ProductRelationInput { Id = id }).ToList()
            };
        }

        private static CreateProductVariantInput ToCreateProductVariantInput(VariantInput input)
        {
            return new CreateProductVariantInput
            {
                Attributes = input.Attributes,
                BarcodeList = input.BarcodeList,
                HsCode = input.HsCode,
                IsActive = input.IsActive,
                Prices = input.Prices,
                Sku = input.Sku,
                Weight = input.Weight
            };
        }

        private static bool HasLegacyVariantValueIds(ProductInput input)
        {
            return input.Variants.Any(variant => variant.VariantValueIds?.Count > 0);
        }
    }
}
