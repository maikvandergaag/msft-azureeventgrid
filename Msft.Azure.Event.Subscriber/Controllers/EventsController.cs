using Microsoft.ApplicationInsights;
using Msft.Event.Core;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace Msft.Azure.Event.Subscriber.Controllers {
    public class EventsController : ApiController {
        // POST api/values
        public void Post([FromBody]List<CustomEvent<Account>> value) {
            foreach(var eventValue in value) {
                string data = JsonConvert.SerializeObject(eventValue);
                Dictionary<string, string> allData = new Dictionary<string, string>();
                allData.Add("event id", eventValue.Id);
                allData.Add("eventdata", data);

                TelemetryClient client = new TelemetryClient();
                client.TrackEvent("Event Received", allData);
            }
        }
    }
}
