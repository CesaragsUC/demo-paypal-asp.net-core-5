using DemoPaypal.Model;
using Domain.Entidades;
using PayPalCheckoutSdk.Orders;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoPaypal.PaypalHelper
{
    public class CreateOrderPaypal
    {
        //Below function can be used to build the create order request body with complete payload.
        private static OrderRequest BuildRequestBody(Produto produto)
        {
            OrderRequest orderRequest = new OrderRequest()
            {
                CheckoutPaymentIntent = "CAPTURE", //"AUTHORIZE","CAPTURE"

                ApplicationContext = new ApplicationContext
                {
                    BrandName = $"Produto {produto.Nome}",
                    LandingPage = "BILLING",
                    //CancelUrl = "https://oppressorcheat.com/home",
                    //ReturnUrl = "https://oppressorcheat.com/shop/order",
                    CancelUrl = "https://localhost:5001/",
                    ReturnUrl = "https://localhost:5001/Pedidos/",
                    UserAction = "CONTINUE",
                    ShippingPreference = "NO_SHIPPING"
                },
                PurchaseUnits = new List<PurchaseUnitRequest>
                {
                    new PurchaseUnitRequest{
                        ReferenceId =  "PUHF",
                        Description = produto.Nome,
                        CustomId = "CUST-DemoShop",
                        SoftDescriptor = "DemoShop",
                        AmountWithBreakdown = new AmountWithBreakdown
                        {
                            CurrencyCode = "BRL", //"EUR", "USD", "BRL"
                            Value = produto.Preco.ToString().Replace(",","."),
                            AmountBreakdown = new AmountBreakdown
                            {
                                ItemTotal = new Money
                                {
                                    CurrencyCode = "BRL",
                                    Value = produto.Preco.ToString().Replace(",",".")
                                }

                            }
                        }
                    }
                }
            };

            return orderRequest;
        }



        //This function can be used to perform authorization on the approved order.
        public async static Task<HttpResponse> AuthorizeOrder(string OrderId, bool debug = false)
        {
            var request = new OrdersAuthorizeRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new AuthorizeRequest());
            var response = await PayPalClient.client().Execute(request);

            if (debug)
            {
                var result = response.Result<Order>();
                Console.WriteLine("Status: {0}", result.Status);
                Console.WriteLine("Order Id: {0}", result.Id);
                Console.WriteLine("Authorization Id: {0}", result.PurchaseUnits[0].Payments.Authorizations[0].Id);
                Console.WriteLine("Intent: {0}", result.CheckoutPaymentIntent);
                Console.WriteLine("Links:");
                foreach (LinkDescription link in result.Links)
                {
                    Console.WriteLine("\t{0}: {1}\tCall Type: {2}", link.Rel, link.Href, link.Method);
                }
                AmountWithBreakdown amount = result.PurchaseUnits[0].AmountWithBreakdown;
                Console.WriteLine("Buyer:");
                Console.WriteLine("\tEmail Address: {0}", result.Payer.Email);
                Console.WriteLine("Response JSON: \n {0}", PayPalClient.ObjectToJSONString(result));
            }

            return response;
        }

        /*
            Method to create order
            
            @param debug true = print response data
            @return HttpResponse<Order> response received from API
            @throws IOException Exceptions from API if any
        */
        //public async static Task<HttpResponse> CreateOrder(Cheat cheat, bool debug = false)
        //{
        //    var request = new OrdersCreateRequest();
        //    request.Headers.Add("prefer", "return=representation");
        //    request.RequestBody(BuildRequestBody(cheat));
        //    try
        //    {
        //        return await PayPalClient.client().Execute(request);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //}

        //Below function can be used to create an order with complete payload.
        public async static Task<HttpResponse> CreateOrder(Produto produto, bool debug = false)
        {

            var request = new OrdersCreateRequest();
            request.Prefer("return=representation");
            request.RequestBody(BuildRequestBody(produto));
            var response = await PayPalClient.client().Execute(request);
            var result = response.Result<Order>();
            if (debug)
            {
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
            }
            return response;
        }



    }
}
