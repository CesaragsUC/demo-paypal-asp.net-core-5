using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.PaypalHelper
{
    public class CaptureOrder
    {
        public async static Task<HttpResponse> captureOrder(string orderId)
        {
            // Construct a request object and set desired parameters
            // Replace ORDER-ID with the approved order id from create order
            var request = new OrdersCaptureRequest(orderId);
            request.RequestBody(new OrderActionRequest());
            HttpResponse response = await PayPalClient.client().Execute(request);
            var statusCode = response.StatusCode;
            Order result = response.Result<Order>();
            // Console.WriteLine("Status: {0}", result.Status);
            // Console.WriteLine("Capture Id: {0}", result.Id);
            return response;
        }
    }
}
