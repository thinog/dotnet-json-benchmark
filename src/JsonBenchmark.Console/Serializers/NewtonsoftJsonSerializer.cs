using System.Collections.Generic;
using System.IO;
using System.Linq;
using JsonBenchmark.Console;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonBenchmark.Console.Serializers
{
    public class NewtonsoftJsonSerializer
    {
        private readonly string _jsonPath = "../dataset.json";

        public Model GetModelByIdAllInMemory(int id)
        {
            IEnumerable<Model> items;

            using (StreamReader r = new StreamReader("../dataset.json"))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<IEnumerable<Model>>(json);
            }

            return items.FirstOrDefault(item => item.Id == id);
        }

        public Model GetModelByIdIterateOnFile(int id)
        {
            using (var fs = File.OpenRead(_jsonPath))
            using (var textReader = new StreamReader(fs))
            using (var reader = new JsonTextReader(textReader))
            {
                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.StartObject)
                    {
                        var model = JObject.Load(reader).ToObject<Model>();
                        
                        if(model.Id == id)
                            return model;
                    }
                }
            }

            return null;
        }
    }
}