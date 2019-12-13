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
            nounsdb.Delete(x => x.Trans[0][0] == noun.Trans[0][0]);
            nounsdb.Insert(noun.Trans[0][0], noun);
        }

        public static void AddWord(Verb verb)
        {
            var nounsdb = Database.GetCollection<Verb>("Verbs");
            nounsdb.Delete(x => x.Trans[0][0] == verb.Trans[0][0]);
            nounsdb.Insert(verb.Trans[0][0], verb);
        }

        public string EnglishToSpanish(string english)
        {
            var nounsdb = Database.GetCollection<Noun>("Nouns").FindAll().ToList();
            var verbsdb = Database.GetCollection<Verb>("Verbs").FindAll().ToList();



            throw new OverflowException("Out of Memory");
        }

        public string SpanishToEnglish(string spanish)
        {
            var nounsdb = Database.GetCollection<Noun>("Nouns").FindAll().ToList();
            var verbsdb = Database.GetCollection<Verb>("Verbs").FindAll().ToList();

            var words = spanish.Split(' ');
            var nouns = new List<string>();
            var verbs = new List<string>();
            var things = new List<string>();
            var articles = new List<string>();
            foreach (var word in words)
            {
                var noun = nounsdb.FirstOrDefault(x => x.Trans.Any(y => y.Any(z => z == word.ToLower())))?.Trans;
                if (nounsdb.Any(x => x.Trans.Any(y => y.Any(z => z == word.ToLower()))))
                {
                    if (noun[1][0].Replace("|", "").ToLower() == word.ToLower())
                        nouns.Add(noun[0][0]);
                    if (noun[1][1].Replace("|", "").ToLower() == word.ToLower())
                        nouns.Add(noun[0][1]);
                }

                var verb = verbsdb.FirstOrDefault(x => x.Trans.Any(y => y.Any(z => z == word.ToLower())))?.Trans;
                if (verbsdb.Any(x => x.Trans.Any(y => y.Any(z => z == word.ToLower()))))
                {
                    if (verb[1][1].Replace("|", "").ToLower() == word.ToLower())
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][0]);
                        else
                            verbs.Add("I'm " + verb[0][2]);
                    else if (verb[1][0].Replace("|", "").ToLower() == word.ToLower())
                        verbs.Add("to " + verb[0][1]);
                    else if (verb[1][2].Replace("|", "").ToLower() == word.ToLower())
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][1]);
                        else
                            verbs.Add("You're " + verb[0][2]);
                    else if (verb[1][3].Replace("|", "").ToLower() == word.ToLower())
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][0]);
                        else
                            verbs.Add("He's " + verb[0][2]);
                    else if (verb[1][4].Replace("|", "").ToLower() == word.ToLower())
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][2]);
                        else
                            verbs.Add("We're " + verb[0][2]);
                    else if (verb[1][5].Replace("|", "").ToLower() == word.ToLower())
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][0]);
                        else
                            verbs.Add("They're " + verb[0][2]);
                    else
                        verbs.Add(verb[0][1]);
                }
                
                if (word.ToLower() == "te")
                    things.Add("to you");
                if (word.ToLower() == "le")
                    things.Add("to him");
                if (word.ToLower() == "me")
                    things.Add("to me");
                if (word.ToLower() == "nos")
                    things.Add("to us");
                if (word.ToLower() == "les")
                    things.Add("to them");
                if (word.ToLower() == "lo" || word.ToLower() == "la")
                    things.Add("it");
                if (word.ToLower() == "los" || word.ToLower() == "las")
                    things.Add("them");
                if (word.ToLower() == "se")
                    things.Add("to him");
                if (word.ToLower() == "un" || word.ToLower() == "una")
                    articles.Add("a(n)");
                if (word.ToLower() == "unos" || word.ToLower() == "unas")
                    articles.Add("some");
            }
            
            var builder = new StringBuilder();
            if (nouns.Count > 0)
            {
                if (articles.Count > 0)
                    builder.Append(articles[0] + " ");
                builder.Append(nouns[0] + " ");
            }

            foreach (var verb in verbs)
            {
                builder.Append(verb + " ");
            }

            foreach (var thing in things)
            {
                builder.Append(thing + " ");
            }

            builder.Append(".");
            return builder.ToString();
        }
    }
}
