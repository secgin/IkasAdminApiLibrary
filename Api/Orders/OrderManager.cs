using IkasAdminApiLibrary.Abstracts;
using IkasAdminApiLibrary.Api.Common.Models;
using IkasAdminApiLibrary.Api.Orders.Abstracts;
using IkasAdminApiLibrary.Api.Orders.Models;
using IkasAdminApiLibrary.Api.Orders.Models.Inputs;

namespace IkasAdminApiLibrary.Api.Orders
{
    internal class OrderManager : IOrderManager
    {
        private const string OrderFields = """
            archived
            billingAddress {
              addressLine1
              addressLine2
              company
              firstName
              id
              identityNumber
              isDefault
              lastName
              phone
              postalCode
              taxNumber
              taxOffice
            }
            cancelReason
            cancelledAt
            cartId
            cartStatus
            checkoutId
            couponCode
            createdAt
            currencyCode
            currencySymbol
            customer {
              email
              firstName
              fullName
              id
              isGuestCheckout
              lastName
              notificationsAccepted
              phone
              preferredLanguage
            }
            customerId
            deleted
            dueDate
            edited
            id
            invoices {
              appId
              appName
              createdAt
              hasPdf
              id
              invoiceData
              invoiceNumber
              storeAppId
              type
            }
            itemCount
            merchantId
            netTotalFinalPrice
            note
            orderLineItems {
              createdAt
              currencyCode
              currencySymbol
              deleted
              discountPrice
              edited
              finalPrice
              finalUnitPrice
              id
              price
              quantity
              sourceId
              status
              statusUpdatedAt
              stockLocationId
              taxValue
              unitPrice
              updatedAt
            }
            orderNumber
            orderPackageStatus
            orderPackages {
              createdAt
              deleted
              errorMessage
              id
              note
              orderLineItemIds
              orderPackageFulfillStatus
              orderPackageNumber
              sourceId
              stockLocationId
              updatedAt
            }
            orderPaymentStatus
            orderSequence
            orderTagIds
            orderedAt
            paymentMethods {
              isAlternativeGateway
              paymentGatewayCode
              paymentGatewayId
              paymentGatewayName
              price
              type
            }
            priceList {
              id
              name
            }
            priceListId
            salesChannel {
              id
              name
              type
            }
            salesChannelId
            shippingAddress {
              addressLine1
              addressLine2
              company
              firstName
              id
              identityNumber
              isDefault
              lastName
              phone
              postalCode
              taxNumber
              taxOffice
            }
            shippingLines {
              finalPrice
              isRefunded
              paymentMethod
              price
              priceListId
              shippingSettingsId
              shippingZoneRateId
              taxValue
              title
              transactionId
            }
            shippingMethod
            sourceId
            status
            stockLocation {
              id
              name
            }
            stockLocationId
            storefront {
              id
              name
            }
            storefrontId
            taxLines {
              price
              rate
            }
            totalFinalPrice
            totalPrice
            updatedAt
            """;

        private const string ListOrderTransactionsQuery = """
            query ListOrderTransactions($orderId: String!) {
              listOrderTransactions(orderId: $orderId) {
                amount
                authCode
                checkoutId
                createdAt
                currencyCode
                currencySymbol
                customerId
                deleted
                error {
                  code
                  declineCode
                  message
                }
                gatewayReferenceId
                id
                lineItems {
                  finalPrice
                  id
                  price
                  quantity
                  taxValue
                  variant {
                    id
                    mainImageId
                    name
                    productId
                    sku
                    slug
                    type
                  }
                }
                orderId
                paymentGatewayCode
                paymentGatewayId
                paymentGatewayName
                paymentMethod
                paymentMethodDetail {
                  bankName
                  binNumber
                  cardAssociation
                  cardFamily
                  cardType
                  installment {
                    installmentCount
                    installmentPrice
                    originalRate
                    rate
                    totalPrice
                  }
                  lastFourDigits
                  paymentMethodName
                  threeDSecure
                }
                processedAt
                refundReason
                status
                type
                updatedAt
              }
            }
            """;

        private const string ListOrderTagQuery = """
            query ListOrderTag {
              listOrderTag {
                createdAt
                deleted
                id
                name
                updatedAt
              }
            }
            """;

        private const string CreateOrderTagMutation = """
            mutation CreateOrderTag($input: CreateOrderTagInput!) {
              createOrderTag(input: $input) {
                createdAt
                deleted
                id
                name
                updatedAt
              }
            }
            """;

        private const string AddOrderTagMutation = """
            mutation AddOrderTag($input: SaveOrderTagInput!) {
              addOrderTag(input: $input)
            }
            """;

        private readonly IGraphQLService graphQLService;

        public OrderManager(IGraphQLService graphQLService)
        {
            this.graphQLService = graphQLService;
        }

        public async Task<IResult<Pagination<Order>>> List(ListOrderInput? input = null)
        {
            input ??= new ListOrderInput();

            return await graphQLService.QueryAsync<Pagination<Order>>(
                ListOrderQuery(),
                input,
                "listOrder");
        }

        public async Task<IResult<List<OrderTransaction>>> ListTransactions(ListOrderTransactionsInput input)
        {
            return await graphQLService.QueryAsync<List<OrderTransaction>>(
                ListOrderTransactionsQuery,
                input,
                "listOrderTransactions");
        }

        public async Task<IResult<Order>> Fulfill(FulfillOrderInput input)
        {
            return await graphQLService.MutationQueryAsync<Order>(
                OrderMutation("FulfillOrder", "fulfillOrder", "PublicFulFillOrderInput"),
                new { input },
                "fulfillOrder");
        }

        public async Task<IResult<Order>> UpdatePackageStatus(UpdateOrderPackageStatusInput input)
        {
            return await graphQLService.MutationQueryAsync<Order>(
                OrderMutation("UpdateOrderPackageStatus", "updateOrderPackageStatus", "UpdateOrderPackageStatusInput"),
                new { input },
                "updateOrderPackageStatus");
        }

        public async Task<IResult<List<OrderTag>>> ListTags()
        {
            return await graphQLService.QueryAsync<List<OrderTag>>(ListOrderTagQuery, null, "listOrderTag");
        }

        public async Task<IResult<OrderTag>> CreateTag(CreateOrderTagInput input)
        {
            return await graphQLService.MutationQueryAsync<OrderTag>(
                CreateOrderTagMutation,
                new { input },
                "createOrderTag");
        }

        public async Task<IResult<bool>> AddTag(AddOrderTagInput input)
        {
            return await graphQLService.MutationQueryAsync<bool>(
                AddOrderTagMutation,
                new { input },
                "addOrderTag");
        }

        public async Task<IResult<Order>> AddInvoice(AddOrderInvoiceInput input)
        {
            return await graphQLService.MutationQueryAsync<Order>(
                OrderMutation("AddOrderInvoice", "addOrderInvoice", "AddOrderInvoiceInput"),
                new { input },
                "addOrderInvoice");
        }

        public async Task<IResult<Order>> CancelFulfillment(CancelFulfillmentInput input)
        {
            return await graphQLService.MutationQueryAsync<Order>(
                OrderMutation("CancelFulfillment", "cancelFulfillment", "PublicCancelFulfillmentInput"),
                new { input },
                "cancelFulfillment");
        }

        private static string ListOrderQuery()
        {
            return $$"""
                query listOrder($branchId: StringFilterInput, $branchSessionId: StringFilterInput, $closedAt: DateFilterInput, $customerEmail: StringFilterInput, $customerId: StringFilterInput, $id: StringFilterInput, $invoicesStoreAppId: StringFilterInput, $orderNumber: StringFilterInput, $orderPackageStatus: OrderPackageStatusEnumInputFilter, $orderPaymentStatus: OrderPaymentStatusEnumInputFilter, $orderTagIds: StringFilterInput, $orderedAt: DateFilterInput, $pagination: PaginationInput, $paymentMethodType: OrderPaymentMethodEnumFilterInput, $salesChannelId: StringFilterInput, $search: String, $shippingMethod: OrderShippingMethodEnumFilterInput, $sort: String, $status: OrderStatusEnumInputFilter, $stockLocationId: StringFilterInput, $terminalId: StringFilterInput, $updatedAt: DateFilterInput) {
                  listOrder(branchId: $branchId, branchSessionId: $branchSessionId, closedAt: $closedAt, customerEmail: $customerEmail, customerId: $customerId, id: $id, invoicesStoreAppId: $invoicesStoreAppId, orderNumber: $orderNumber, orderPackageStatus: $orderPackageStatus, orderPaymentStatus: $orderPaymentStatus, orderTagIds: $orderTagIds, orderedAt: $orderedAt, pagination: $pagination, paymentMethodType: $paymentMethodType, salesChannelId: $salesChannelId, search: $search, shippingMethod: $shippingMethod, sort: $sort, status: $status, stockLocationId: $stockLocationId, terminalId: $terminalId, updatedAt: $updatedAt) {
                    count
                    data {
                {{OrderFields}}
                    }
                    hasNext
                    limit
                    page
                  }
                }
                """;
        }

        private static string OrderMutation(string operationName, string fieldName, string inputType)
        {
            return $$"""
                mutation {{operationName}}($input: {{inputType}}!) {
                  {{fieldName}}(input: $input) {
                {{OrderFields}}
                  }
                }
                """;
        }
    }
}
