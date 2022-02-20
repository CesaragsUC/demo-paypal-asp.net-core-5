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
    public class OrdersAuthorizeTest
    {
        [Fact(Skip = "This test is an example. In production, you will need payer approval")]
        public async void TestOrdersAuthorizeRequest()
        {
            OrdersAuthorizeRequest request = new OrdersAuthorizeRequest("ORDER-ID");

            HttpResponse response = await TestHarness.client().Execute(request);
            Assert.Equal(200,(int) response.StatusCode);
            Assert.NotNull(response.Result<Order>());
        }
    }
}
