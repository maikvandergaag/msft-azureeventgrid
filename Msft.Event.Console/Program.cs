using Msft.Event.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Msft.Event {
    class Program {
        static void Main(string[] args) {
            var eventNew = MakeRequestEvent();
            eventNew.Wait();            
            Console.WriteLine(eventNew.Result.Content.ReadAsStringAsync().Result);

            Console.ReadKey();
        }

        private static async Task<HttpResponseMessage> MakeRequestEvent() {
            string endpoint = "[endpoint]";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("aeg-sas-key", "[key]");

            List<CustomEvent<Account>> events = new List<CustomEvent<Account>>();

            var customEvent = new CustomEvent<Account>();
            customEvent.EventType = "TestType";
            
            customEvent.Subject = "Test";
            customEvent.Data = new Account() { Name = "Maik", Gender = "Male" };

            events.Add(customEvent);
            string jsonContent = JsonConvert.SerializeObject(events);

            Console.WriteLine(jsonContent);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            return await httpClient.PostAsync(endpoint, content);            
        }
    }
}