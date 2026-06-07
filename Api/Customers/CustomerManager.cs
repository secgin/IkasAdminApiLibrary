using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Customers.Abstracts;
using IkasAdminApiLibrary.Api.Customers.Models;
using IkasAdminApiLibrary.Api.Customers.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Customers
{
    internal class CustomerManager : ICustomerManager
    {
        private const string ListCustomerQuery = """
            query ListCustomer($pagination: PaginationInput!, $search: String) {
              listCustomer(pagination: $pagination, search: $search) {
                count
                data {
                  accountStatus
                  accountStatusUpdatedAt
                  addresses {
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
                    createdAt
                    deleted
                    district {
                      code
                      id
                      name
                    }
                    firstName
                    id
                    identityNumber
                    isDefault
                    lastName
                    phone
                    postalCode
                    state {
                      code
                      id
                      name
                    }
                    taxNumber
                    taxOffice
                    title
                    updatedAt
                  }
                  attributes {
                    customerAttributeId
                    customerAttributeOptionId
                    value
                  }
                  birthDate
                  createdAt
                  customerGroupIds
                  customerSegmentIds
                  customerSequence
                  deleted
                  email
                  emailVerifiedDate
                  firstName
                  firstOrderDate
                  fullName
                  gender
                  id
                  ip
                  isEmailVerified
                  isPhoneVerified
                  lastName
                  lastOrderDate
                  lastPriceListId
                  lastStorefrontRoutingId
                  note
                  orderCount
                  passwordUpdateDate
                  phone
                  phoneSubscriptionStatus
                  phoneSubscriptionStatusUpdatedAt
                  phoneVerifiedDate
                  preferredLanguage
                  priceListId
                  priceListRules {
                    discountRate
                    filters {
                      type
                      valueList
                    }
                    priceListId
                    shouldMatchAllFilters
                    value
                    valueType
                  }
                  registrationSource
                  smsSubscriptionStatus
                  smsSubscriptionStatusUpdatedAt
                  subscriptionStatus
                  subscriptionStatusUpdatedAt
                  tagIds
                  totalOrderPrice
                  updatedAt
                  userAgent
                }
                hasNext
                limit
                page
              }
            }
            """;

        private readonly IGraphQLService graphQLService;

        public CustomerManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<Pagination<Customer>>> List(ListCustomerInput? input = null)
        {
            input ??= new ListCustomerInput();

            return await graphQLService.QueryAsync<Pagination<Customer>>(
                ListCustomerQuery,
                new
                {
                    input.Pagination,
                    input.Search
                },
                "listCustomer");
        }
    }
}
