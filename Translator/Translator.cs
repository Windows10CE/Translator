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
            try
            {
                var nounsdb = Database.GetCollection<Noun>("Nouns").FindAll().ToList();
                var verbsdb = Database.GetCollection<Verb>("Verbs").FindAll().ToList();

                var pronouns = new List<string>();
                var verbs = new List<Verb>();
                var things = new List<string>();
                bool negative = false;
                bool command = false;
                var words = english.Split(' ').Select(x => x.ToLower()).ToList();
                for (int index = 0; index < words.Count; index++)
                {
                    var word = words[index];
                    var verb = verbsdb.DefaultIfEmpty(null)
                        .FirstOrDefault(x => x.Trans.Any(y => y.Any(z => z.ToLower() == word)));
                    if (verb != null)
                        verbs.Add(verb);
                    if (word.Contains('\''))
                    {
                        word = word.Split('\'')[0];
                    }

                    bool leave = false;
                    switch (word)
                    {
                        case "i":
                            pronouns.Add("i");
                            break;
                        case "you":
                            if (pronouns.Count > 0)
                            {
                                break;
                            }

                            pronouns.Add("you");
                            leave = true;
                            break;
                        case "she":
                        case "he":
                            pronouns.Add("he");
                            break;
                        case "they":
                            pronouns.Add("they");
                            break;
                        case "we":
                            pronouns.Add("we");
                            break;
                        case "let":
                            pronouns.Add("let");
                            command = true;
                            break;
                    }

                    if (leave)
                        continue;

                    if (word == "me")
                    {
                        things.Add("to me");
                    }

                    if (word == "you")
                    {
                        things.Add("to you");
                    }

                    if (word == "him" || word == "her")
                    {
                        things.Add("to him");
                    }

                    if (word == "it")
                    {
                        if (words[index - 1] == "to")
                            things.Add("to it");
                        else things.Add("it");
                    }

                    if (word == "them")
                    {
                        if (words[index - 1] == "to")
                            things.Add("to them");
                        else things.Add("them");
                    }

                    if (word == "us")
                    {
                        things.Add("to us");
                    }

                    if (word == "don't" || word == "not")
                        negative = true;
                }

                if (pronouns.Count < 0)
                    command = true;

                var builder = new StringBuilder();
                var verbBuilder = new StringBuilder();
                things.Reverse();

                if (negative)
                    builder.Append("no ");

                if (!command)
                {
                    switch (pronouns[0])
                    {
                        case "i":
                            verbBuilder.Append(verbs[0].Trans[1][1]);
                            break;
                        case "you":
                            verbBuilder.Append(verbs[0].Trans[1][2]);
                            break;
                        case "he":
                            verbBuilder.Append(verbs[0].Trans[1][3]);
                            break;
                        case "they":
                            verbBuilder.Append(verbs[0].Trans[1][5]);
                            break;
                        case "we":
                            verbBuilder.Append(verbs[0].Trans[1][4]);
                            break;
                    }

                    foreach (var thing in things)
                    {
                        if (thing == "to him" || thing == "to her")
                        {
                            if (things.Any(x => x == "it" || x == "them"))
                                builder.Append("se ");
                            else
                                builder.Append("le ");
                        }

                        if (thing == "to them")
                        {
                            if (things.Any(x => x == "it" || x == "them"))
                                builder.Append("se ");
                            else
                                builder.Append("les ");
                        }

                        if (thing == "to me")
                            builder.Append("me ");
                        if (thing == "to you")
                            builder.Append("te ");
                        if (thing == "to us")
                            builder.Append("nos ");
                        if (thing == "it")
                            builder.Append("lo ");
                    }
                }
                else
                {
                    if (pronouns[0] == "let")
                        verbBuilder.Append(verbs[0].Trans[1][8]);
                    else
                        verbBuilder.Append(verbs[0].Trans[1][3]);

                    foreach (var thing in things)
                    {
                        if (thing == "to him" || thing == "to her")
                        {
                            if (things.Any(x => x == "it" || x == "them"))
                                verbBuilder.Append("se");
                            else
                                verbBuilder.Append("le");
                        }

                        if (thing == "to them")
                        {
                            if (things.Any(x => x == "it" || x == "them"))
                                verbBuilder.Append("se");
                            else
                                verbBuilder.Append("les");
                        }

                        if (thing == "to me")
                            verbBuilder.Append("me");
                        if (thing == "to you")
                            verbBuilder.Append("te");
                        if (thing == "to us")
                            verbBuilder.Append("nos");
                        if (thing == "it")
                            verbBuilder.Append("lo");
                    }
                }

                builder.Append($"{verbBuilder.ToString()} ");

                if (verbs.Count > 1)
                {
                    if (verbs[0].RequireA)
                        builder.Append("a ");
                    builder.Append(verbs[1].Trans[1][0]);
                }

                builder.Append(".");
                return builder.ToString();
            }
            catch
            {
                return "";
            }
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
            var negative = false;
            var command = false;
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

                var verb = verbsdb.FirstOrDefault(x => x.Trans.Any(y => y.Any(z => word.ToLower().Contains(z))))?.Trans;
                if (verbsdb.Any(x => x.Trans.Any(y => y.Any(z => word.ToLower().Contains(z)))))
                {
                    if (word.ToLower().Contains(verb[1][0].Replace("|", "").ToLower()))
                        verbs.Add("to " + verb[0][1]);
                    else if (word.ToLower().Contains(verb[1][1].Replace("|", "").ToLower()))
                    {
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][0]);
                        else if (!negative)
                            verbs.Add("I'm " + verb[0][2]);
                        else if (negative)
                            verbs.Add("I'm not " + verb[0][2]);
                    }
                    else if (word.ToLower().Contains(verb[1][2].Replace("|", "").ToLower()))
                    {
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][1]);
                        else if (!negative)
                            verbs.Add("You're " + verb[0][2]);
                        else if (negative)
                            verbs.Add("You're not " + verb[0][2]);
                    }
                    else if (word.ToLower().Contains(verb[1][3].Replace("|", "").ToLower()))
                    {
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][0]);
                        else if (!negative)
                            verbs.Add("He's " + verb[0][2]);
                        else if (negative)
                            verbs.Add("He's not " + verb[0][2]);
                    }
                    else if (word.ToLower().Contains(verb[1][4].Replace("|", "").ToLower()))
                    {
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][2]);
                        else if (!negative)
                            verbs.Add("We're " + verb[0][2]);
                        else if (negative)
                            verbs.Add("We're not " + verb[0][2]);
                    }
                    else if (word.ToLower().Contains(verb[1][5].Replace("|", "").ToLower()))
                    {
                        if (nouns.Count > 0)
                            verbs.Add(verb[0][0]);
                        else if (!negative)
                            verbs.Add("They're " + verb[0][2]);
                        else if (negative)
                            verbs.Add("They're not " + verb[0][2]);
                    }
                    else
                    {
                        verbs.Add(verb[0][1]);
                        command = true;
                    }

                    string ending = "";
                    if (!verbsdb.Any(x => x.Trans.Any(y => y.Any(z => z == word.ToLower()))))
                    {
                        if (word.Length >= 6)
                            ending = word.ToLower().Substring(word.Length - 6);
                        else if (word.Length >= 4)
                            ending = word.ToLower().Substring(word.Length - 4);
                        else
                            ending = word.ToLower().Substring(word.Length - 2);
                    }
                    if (ending.Contains("me"))
                        things.Add("to me");
                    if (ending.Contains("te"))
                        things.Add("to you");
                    if (ending.Contains("les"))
                        things.Add("to them");
                    else if (ending.Contains("le"))
                        things.Add("to him");
                    if (ending.Contains("se"))
                        things.Add("to him");
                    if (ending.Contains("los") || ending.Contains("las"))
                        things.Add("them");
                    else if (ending.Contains("lo") || ending.Contains("la"))
                        things.Add("it");
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

                if (word.ToLower() == "no")
                    negative = true;
            }
            
            var builder = new StringBuilder();
            if (nouns.Count > 0)
            {
                if (articles.Count > 0)
                    builder.Append(articles[0] + " ");
                builder.Append(nouns[0] + " ");
            }

            if (negative && command)
                builder.Append("Don't ");

            foreach (var verb in verbs)
            {
                builder.Append(verb + " ");
            }

            things.Reverse();
            foreach (var thing in things)
            {
                builder.Append(thing + " ");
            }

            builder.Append(".");
            return builder.ToString();
        }
    }
}
