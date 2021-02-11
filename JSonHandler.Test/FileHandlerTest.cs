using System;
using Xunit;

namespace JSonHandler.Test
{
    public class FileHandlerTest
    {
        [Fact]
        public void TestWriteAndRead()
        {
            var fileHandler = new FileHandler<Product>();
            var p1 = new Product
            {
                Name = "Apple",
                ExpiryDate = new DateTime(2008, 12, 28),
                Price = 3.99M,
                Sizes = new[] { "Small", "Medium", "Large" }
            };
            fileHandler.WriteToFile(p1,@"c:\temp\out.json");
            var p2 = fileHandler.ReadFromFile(@"c:\temp\out.json");
            Assert.Equal(p1,p2);
        }

        [Fact]
        public void ClassNameFromJsonTest()
        {
            var c = new Configuration();

            var a1 = new Antenna
            {
                RemoteAntennaId= 2,
                DhdGpiIndexPrepare= -1,
                DhdGpiIndexOnAir= 1,
                DhdGpiIndexOffAir= 2,
                DhdGpoIndexOnAir= 1
            };
            var a2 = new Antenna
            {
                RemoteAntennaId= 3,
                DhdGpiIndexPrepare= -1,
                DhdGpiIndexOnAir= -1,
                DhdGpiIndexOffAir= -1,
                DhdGpoIndexOnAir= -1
            };
            var mac = new MixerAntennaConfiguration
            {
                MixerData = "I am a mixer",
                Antennas = {a1, a2},
                Password = "testpassword",
                UserName = "testuser"
            };

            var aac = new AnotherAntennaConfiguration
            {
                AnotherData = "I am not mixer",
                Antennas = { a1, a2 },
                Password = "testpassword",
                UserName = "testuser"
            };

            var dc1 = new DeviceConfiguration
            {
                DeviceId = "dhd-matrix",
                Components = {aac},
                DeviceType = "DhdMatrix",
                Host = "134.25.46.146",
                Port = 9000,
                ReconnectInterval = 5000,
                KeepAliveInterval = null
            };

            var dc2 = new DeviceConfiguration
            {
                DeviceId = "KVBREF-ME-TEST-01",
                Components = {mac},
                DeviceType = "MeAresMixer",
                Host = "KVBREF-ME-TEST-01.sr.se",
                Port = 50099,
                ReconnectInterval = 5000,
                KeepAliveInterval = 4000
            };

            c.DeviceConfigurations.Add(dc1);
            c.DeviceConfigurations.Add(dc2);

            new FileHandler<Configuration>().WriteToFile(c, @"c:\temp\derived.json");

        }
    }
}
