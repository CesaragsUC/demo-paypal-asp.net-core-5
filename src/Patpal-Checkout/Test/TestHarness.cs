using System;
using PayPalCheckoutSdk.Core;
using PayPalHttp;
using Xunit;
[assembly: CollectionBehavior(MaxParallelThreads = -1)]

namespace PayPalCheckoutSdk.Test
{
    public class TestHarness
    {

        public static PayPalEnvironment environment()
        {
            return new SandboxEnvironment(
                System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID") != null ?
                 System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID"):"<<PAYPAL-CLIENT-ID>>",
                System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET") != null ?
                 System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET"):"<<PAYPAL-CLIENT-SECRET>>");
        }

        public static HttpClient client()
        {
            return new PayPalHttpClient(environment());
        }

        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }
    }
}
