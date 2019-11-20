using System;
using LiteDB;

namespace Translator
{
    public class Translator
    {
        public static LiteDatabase Database = new LiteDatabase("Dictionary.db");

        public string EnglishToSpanish(string english)
        {
            return "";
        }

        public string SpanishToEnglish(string spanish)
        {
            return "";
        }
    }
}
