using System.Collections.Generic;

namespace JSonHandler
{
    public class DeviceConfiguration
    {
        public string DeviceId { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string DeviceType { get; set; }
        public int ReconnectInterval { get; set; }
        public int? KeepAliveInterval { get; set; }

        public List<AntennaConfiguration> Components = new List<AntennaConfiguration>();
    }
}