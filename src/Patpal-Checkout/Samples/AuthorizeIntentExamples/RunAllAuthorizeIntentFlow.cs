using System;

using Samples.AuthorizeIntentExamples;
using PayPalCheckoutSdk.Orders;
using PayPalCheckoutSdk.Payments;

namespace Samples
{
public class RunAllAuthorizeIntentFlow
{
    //Rename to Main1 => Main
    static void Main(string []args){
        Console.WriteLine("Running Authorize Intent Flow.."); 
        var createOrderResponse = Samples.AuthorizeIntentExamples.CreateOrderSample.CreateOrder().Result;
        var createOrderResult = createOrderResponse.Result<Order>();
                Console.WriteLine("Status: {0}", createOrderResult.Status);
                Console.WriteLine("Order Id: {0}", createOrderResult.Id);
                Console.WriteLine("Intent: {0}", createOrderResult.CheckoutPaymentIntent);
                Console.WriteLine("Links:");
                foreach (PayPalCheckoutSdk.Orders.LinkDescription link in createOrderResult.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }
                AmountWithBreakdown amount = createOrderResult.PurchaseUnits[0].AmountWithBreakdown;
                Console.WriteLine("Total Amount: {0} {1}", amount.CurrencyCode, amount.Value);
        
        Console.WriteLine("Copy approve link and paste it in browser. Login with buyer account and follow the instructions.\nOnce approved hit enter...\n");
        Console.Read();

        Console.WriteLine("Authorizing the Order....");
        var authorizeOrderResponse = AuthorizeOrderSample.AuthorizeOrder(createOrderResult.Id).Result;
        var authorizeOrderResult = authorizeOrderResponse.Result<Order>();
        Console.WriteLine("Status: {0}", authorizeOrderResult.Status);
        var authorizationId = authorizeOrderResult.PurchaseUnits[0].Payments.Authorizations[0].Id;
                Console.WriteLine("Order Id: {0}", authorizeOrderResult.Id);
                Console.WriteLine("Authorization Id: {0}", authorizeOrderResult.PurchaseUnits[0].Payments.Authorizations[0].Id);
                Console.WriteLine("Intent: {0}", authorizeOrderResult.CheckoutPaymentIntent);
                Console.WriteLine("Links:");
                foreach (PayPalCheckoutSdk.Orders.LinkDescription link in authorizeOrderResult.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }
                AmountWithBreakdown authorixedAmount = authorizeOrderResult.PurchaseUnits[0].AmountWithBreakdown;
                Console.WriteLine("Buyer:");
                Console.WriteLine("\tEmail Address: {0}", authorizeOrderResult.Payer.Email);

        Console.WriteLine("Capturing the payment...");
        var captureOrderResponse = CaptureOrderSample.CaptureOrder(authorizationId).Result;
        var captureOrderResult = captureOrderResponse.Result<PayPalCheckoutSdk.Payments.Capture>();
                Console.WriteLine("Status: {0}", captureOrderResult.Status);
                Console.WriteLine("Capture Id: {0}", captureOrderResult.Id);
                Console.WriteLine("Links:");
                foreach (PayPalCheckoutSdk.Payments.LinkDescription link in captureOrderResult.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }
            
        Console.WriteLine("Refunding the Order....");
        var refundOrderResponse = CapturesRefundSample.CapturesRefund(captureOrderResult.Id).Result;
        var refundOrderResult = refundOrderResponse.Result<PayPalCheckoutSdk.Payments.Refund>();
                Console.WriteLine("Status: {0}", refundOrderResult.Status);
                Console.WriteLine("Refund Id: {0}", refundOrderResult.Id);
                Console.WriteLine("Links:");
                foreach (PayPalCheckoutSdk.Payments.LinkDescription link in refundOrderResult.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }

    }
}

}