using System;
using System.Collections.Generic;
using LiteDB;
using Translator.Words;
using System.Linq;
using System.Text;

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
            return "";
        }

        public string SpanishToEnglish(string spanish)
        {
            var builder = new StringBuilder();
            var original = new List<string>();
            original.AddRange(spanish.Split(' '));
            for (int x = 0; x <= original.Count; x++) original[x] = original[x].ToLower();
            if (original[0] == "El" || original[0] == "La" || original[0] == "Los" || original[0] == "Las")
                builder.Append("The ");
            if (original[0] == "Un" || original[0] == "Una")
                builder.Append("A ");
            if (original[0] == "Unos" || original[0] == "Unas")
                builder.Append("Some ");
            bool pronoun = !Database.GetCollection<Noun>("Nouns").Exists(x =>
                x.Trans[1, 0] == original[0] || x.Trans[1, 0] == original[1] || x.Trans[1, 1] == original[0] ||
                x.Trans[1, 1] == original[1]);
            if (!pronoun)
            {
                string[,] noun =
                    Database.GetCollection<Noun>("Nouns")
                        .Exists(x => x.Trans[1, 0] == original[0] || x.Trans[0, 1] == original[0])
                        ? Database.GetCollection<Noun>("Nouns")
                            .FindOne(x => x.Trans[1, 0] == original[0] || x.Trans[0, 1] == original[0]).Trans
                        : Database.GetCollection<Noun>("Nouns")
                            .FindOne(x => x.Trans[1, 0] == original[1] || x.Trans[0, 1] == original[1]).Trans;
                if (original.Contains(noun[1, 0])) builder.Append(noun[0, 0]);
                else builder.Append(noun[0, 1]);
            }
            
            return builder.ToString();
        }
    }
}
