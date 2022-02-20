using PayPalCheckoutSdk.Core;
using PayPalHttp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace DemoPaypal.PaypalHelper
{
    public class PayPalClient
    {
        /**
        Setting up PayPal environment with credentials with sandbox cerdentails. 
        For Live, this should be LiveEnvironment Instance. 
        */

        ///
        /// for APi Live
        //public static PayPalEnvironment environment()
        //{
        //    return new LiveEnvironment(
        //        System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID") != null ?
        //            System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID") : "client_id_live",
        //        System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET") != null ?
        //            System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET") : "secrete_key_live");
        //}


        /// for sandbox test local
        public static PayPalEnvironment environment()
        {
            return new SandboxEnvironment(
                 System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID") != null ?
                 System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_ID") : "seu client paypal id aqui",
                System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET") != null ?
                 System.Environment.GetEnvironmentVariable("PAYPAL_CLIENT_SECRET") : "seu client secret id aqui");
        }
        /**
            Returns PayPalHttpClient instance which can be used to invoke PayPal API's.
         */
        public static HttpClient client()
        {
            return new PayPalHttpClient(environment());
        }

        public static HttpClient client(string refreshToken)
        {
            return new PayPalHttpClient(environment(), refreshToken);
        }

        /**
            This method can be used to Serialize Object to JSON string.
        */
        public static String ObjectToJSONString(Object serializableObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            var writer = JsonReaderWriterFactory.CreateJsonWriter(
                memoryStream, Encoding.UTF8, true, true, "  ");
            DataContractJsonSerializer ser = new DataContractJsonSerializer(serializableObject.GetType(), new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true });
            ser.WriteObject(writer, serializableObject);
            memoryStream.Position = 0;
            StreamReader sr = new StreamReader(memoryStream);
            return sr.ReadToEnd();
        }
    }
}
