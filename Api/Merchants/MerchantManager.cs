using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Merchants.Abstracts;
using IkasAdminApiLibrary.Api.Merchants.Models;

namespace IkasAdminApiLibrary.Api.Merchants
{
    internal class MerchantManager : IMerchantManager
    {
        private const string GetMerchantQuery = """
            query GetMerchant {
              getMerchant {
                address {
                  addressLine1
                  addressLine2
                  city {
                    code
                    id
                    name
                  }
                  company
                  country {
                    code
                    id
                    iso2
                    iso3
                    name
                  }
                  district {
                    code
                    id
                    name
                  }
                  firstName
                  identityNumber
                  lastName
                  postalCode
                  state {
                    code
                    id
                    name
                  }
                  taxNumber
                  taxOffice
                  title
                  type
                  vkn
                }
                email
                firstName
                id
                lastName
                merchantName
                merchantSequence
                phoneNumber
                storeName
              }
            }
            """;

        private const string ListMerchantSettingsQuery = """
            query ListMerchantSettings {
              listMerchantSettings {
                accessPermission
                accessPermissionToDate
                address {
                  addressLine1
                  addressLine2
                  city {
                    code
                    id
                    name
                  }
                  company
                  country {
                    code
                    id
                    iso2
                    iso3
                    name
                  }
                  district {
                    code
                    id
                    name
                  }
                  firstName
                  identityNumber
                  lastName
                  postalCode
                  state {
                    code
                    id
                    name
                  }
                  taxNumber
                  taxOffice
                  title
                  type
                  vkn
                }
                billingAddress {
                  addressLine1
                  addressLine2
                  company
                  firstName
                  identityNumber
                  lastName
                  postalCode
                  taxNumber
                  taxOffice
                  title
                  type
                  vkn
                }
                createdAt
                currencyCode
                currencyFormats {
                  currencyCode
                  decimalSeparator
                  omitZeroDecimal
                  symbol
                  symbolPosition
                  thousandSeparator
                }
                currencySymbol
                defaultLocale
                deleted
                id
                logoId
                merchantName
                phone
                requireMFAForAllStaffs
                timezone
                updatedAt
              }
            }
            """;

        private readonly IGraphQLService graphQLService;

        public MerchantManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<Merchant>> Get()
        {
            return await graphQLService.QueryAsync<Merchant>(GetMerchantQuery, null, "getMerchant");
        }

        public async Task<IResult<List<MerchantSetting>>> ListSettings()
        {
            return await graphQLService.QueryAsync<List<MerchantSetting>>(ListMerchantSettingsQuery, null, "listMerchantSettings");
        }
    }
}
