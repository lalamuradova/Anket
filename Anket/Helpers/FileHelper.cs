using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Anket.Helpers
{
    class FileHelpers
    {
        public void JsonSerialization(List<Questions>questions)
        {
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter("Anket.json"))
            {
                using (var jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Newtonsoft.Json.Formatting.Indented;
                    serializer.Serialize(jw, questions);
                }
            }
        }
        public void JsonDeserialize(Database DB)
        {
           List<Questions> ankets = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("Anket.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    ankets = serializer.Deserialize<List<Questions>>(jr);
                }
                foreach (var anket in ankets)
                {
                    DB.AddAnket(anket);
                }
            }

        }
        public void JsonDeserialize2(Database db)
        {
            Questions anket = null;
            var serializer = new JsonSerializer();

            using (StreamReader sr = new StreamReader("Anket.json"))
            {
                using (var jr = new JsonTextReader(sr))
                {
                    anket = serializer.Deserialize<Questions>(jr);
                }
                
            }
            db.AddAnket(anket);
        }

    }
}
