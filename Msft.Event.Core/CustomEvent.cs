using System;

namespace Msft.Event.Core {
    public class CustomEvent<T> {

        public string Id { get; private set; }

        public string EventType { get; set; }

        public string Subject { get; set; }

        public string EventTime { get; private set; }

        public T Data { get; set; }

        public CustomEvent(){
            Id = DateTime.Now.Ticks.ToString();

            DateTime localTime = DateTime.Now;
            DateTime utcTime = DateTime.UtcNow;
            DateTimeOffset localTimeAndOffset = new DateTimeOffset(localTime, TimeZoneInfo.Local.GetUtcOffset(localTime));
            EventTime = localTimeAndOffset.ToString("o");
         }
    }
}
