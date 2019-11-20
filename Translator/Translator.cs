using System;
using LiteDB;
using Translator.Words;
using System.Linq;

namespace Translator
{
    public class Translator
    {
        public static LiteDatabase Database = new LiteDatabase("Dictionary.db");

        public static void AddWord(Noun noun)
        {
            var nounsdb = Database.GetCollection<Noun>("Nouns");
            nounsdb.Delete(x => x.Trans[0, 0] == noun.Trans[0, 0]);
            nounsdb.Insert(noun);
        }
        public static void AddWord(Verb verb)
        {
            var nounsdb = Database.GetCollection<Verb>("Verbs");
            nounsdb.Delete(x => x.Trans[0, 0] == verb.Trans[0, 0]);
            nounsdb.Insert(verb);
        }
        
        public string EnglishToSpanish(string english)
        {
            return english;
        }

        public string SpanishToEnglish(string spanish)
        {
            return spanish;
        }
    }
}
