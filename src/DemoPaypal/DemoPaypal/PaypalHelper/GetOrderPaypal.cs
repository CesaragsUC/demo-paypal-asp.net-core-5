using PayPalCheckoutSdk.Orders;
using PayPalCheckoutSdk.Payments;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Capture = PayPalCheckoutSdk.Orders.Capture;
using LinkDescription = PayPalCheckoutSdk.Orders.LinkDescription;

namespace DemoPaypal.PaypalHelper
{
    public class GetOrderPaypal
    {
        /*
            This method cn be used to retrieve an order by passing the order id.
         */
        public async static Task<HttpResponse> GetOrder(string orderId, bool debug = false)
        {
            OrdersGetRequest request = new OrdersGetRequest(orderId);

            var response = await PayPalClient.client().Execute(request);
            var result = response.Result<Order>();
            Console.WriteLine("Retrieved Order Status");
            Console.WriteLine("Status: {0}", result.Status);
            Console.WriteLine("Order Id: {0}", result.Id);
            Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
            Console.WriteLine("Links:");
            foreach (LinkDescription link in result.Links)
            {
                Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
            }
            AmountWithBreakdown amount = result.PurchaseUnits[0].AmountWithBreakdown;
            Console.WriteLine("Total Amount: {0} {1}", amount.CurrencyCode, amount.Value);
            Console.WriteLine("Response JSON: \n {0}", PayPalClient.ObjectToJSONString(result));

            return response;
        }


        //This method  can be used to capture the payment on the approved authorization.
        public async static Task<HttpResponse> CaptureOrder(string AuthorizationId, bool debug = false)
        {
            var request = new AuthorizationsCaptureRequest(AuthorizationId);
            request.Prefer("return=representation");
            request.RequestBody(new CaptureRequest());
            var response = await PayPalClient.client().Execute(request);

            if (debug)
            {
                var result = response.Result<Capture>();
                Console.WriteLine("Status: {0}", result.Status);
                Console.WriteLine("Order Id: {0}", result.Id);
                Console.WriteLine("Links:");
                foreach (LinkDescription link in result.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }
                Console.WriteLine("Response JSON: \n {0}", PayPalClient.ObjectToJSONString(result));
            }

            return response;
        }
    }
}
