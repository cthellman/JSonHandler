using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace JSonHandler
{
    public class FileHandler<T>
    {
        public void WriteToFile(T obj, string filename)
        {
            StreamWriter sw = null;
            try
            {
                var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var output = JsonConvert.SerializeObject(obj,Formatting.Indented,settings);
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
}
