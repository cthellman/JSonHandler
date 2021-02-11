using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace JSonHandler
{
    public class FileHandler<T>
    {
        public void WriteToFile(T obj, string filename)
        {
            StreamWriter sw = null;
            try
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto };
                var output = JsonConvert.SerializeObject(obj,Formatting.Indented/*,settings*/);
                Console.WriteLine(output);
                sw = File.CreateText(filename);
                sw.WriteLine(output);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sw?.Close();
            }
        }

        public T ReadFromFile(string filename)
        {
            try
            {
                var txt = File.ReadAllText(filename);
                return JsonConvert.DeserializeObject<T>(txt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }
    }

    public class DeviceConfigurationConverter : JsonConverter
    {
        NamingStrategy NamingStrategy { get; set; }

        public DeviceConfigurationConverter(NamingStrategy namingStrategy)
        {
            NamingStrategy = namingStrategy;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DeviceConfiguration);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var req = (DeviceConfiguration)value;
            var jo = new JObject(
                req.Components => 
                new JProperty(GetPropertyName(.GetType().Name),
                    JObject.FromObject(req.Components, serializer))
            );
            jo.WriteTo(writer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jo = JObject.Load(reader);

            var baseRequestType = Assembly.GetAssembly(typeof(AntennaConfiguration))
                ?.GetTypes()
                .First(t => t.Name == nameof(AnotherAntennaConfiguration));

            return req;
        }

        private string GetPropertyName(string name)
        {
            return NamingStrategy.GetPropertyName(name, false);
        }
    }
}
