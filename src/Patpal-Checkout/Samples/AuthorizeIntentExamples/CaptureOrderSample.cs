using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Samples;
using PayPalCheckoutSdk.Payments;
using PayPalHttp;

namespace Samples.AuthorizeIntentExamples
{
    public class CaptureOrderSample
    {
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

        // static void Main(string[] args)
        // {
        //     string OrderId = "<<REPLACE-WITH-APPROVED-ORDER-ID>>";
        //     CaptureOrder(OrderId, true).Wait();
        // }
    }
}
