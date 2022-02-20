using System;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Collections.Generic;
using PayPalHttp;
using Xunit;
using PayPalCheckoutSdk.Test;
using static PayPalCheckoutSdk.Test.TestHarness;


namespace PayPalCheckoutSdk.Orders.Test
{
    [Collection("Orders")]
    public class OrdersGetTest
    {
        [Fact]
        public async void TestOrdersGetRequest()
        {
            var response = await OrdersCreateTest.CreateOrder();
            Order createdOrder = response.Result<Order>();

            OrdersGetRequest request = new OrdersGetRequest(createdOrder.Id);

            response = await TestHarness.client().Execute(request);
            Assert.Equal(200, (int) response.StatusCode);
            Order retrievedOrder = response.Result<Order>();
            Assert.NotNull(retrievedOrder);
            Assert.Equal(retrievedOrder.Id, createdOrder.Id);
            Assert.NotNull(retrievedOrder.PurchaseUnits);
            Assert.Equal(retrievedOrder.PurchaseUnits.Count, createdOrder.PurchaseUnits.Count);

            for (int count = 0; count < retrievedOrder.PurchaseUnits.Count; count++) {
                PurchaseUnit retrievedOrderPurchaseUnit = retrievedOrder.PurchaseUnits[count];
                PurchaseUnit createdOrderPurchaseUnit = createdOrder.PurchaseUnits[count];
                Assert.Equal(retrievedOrderPurchaseUnit.ReferenceId, createdOrderPurchaseUnit.ReferenceId);
                Assert.Equal(retrievedOrderPurchaseUnit.AmountWithBreakdown.CurrencyCode, createdOrderPurchaseUnit.AmountWithBreakdown.CurrencyCode);
                Assert.Equal(retrievedOrderPurchaseUnit.AmountWithBreakdown.Value, createdOrderPurchaseUnit.AmountWithBreakdown.Value);
            }

            Assert.NotNull(retrievedOrder.CreateTime);

            Assert.NotNull(createdOrder.Links);
            bool foundApproveURL = false;
            foreach (var linkDescription in createdOrder.Links) {
                if ("approve".Equals(linkDescription.Rel)) {
                    foundApproveURL = true;
                    Assert.NotNull(linkDescription.Href);
                    Assert.Equal("GET", linkDescription.Method);
                    Console.WriteLine(linkDescription.Href);
                }
            }

            Console.WriteLine(createdOrder.Id);
            Assert.True(foundApproveURL);
            Assert.Equal("CREATED", createdOrder.Status);

        }
    }
}
