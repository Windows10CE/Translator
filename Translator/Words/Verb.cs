using System;

namespace Translator.Words
{
    [Serializable]
    public class Verb
    {
        public string[][] Trans { get; set; }
        public bool RequireA { get; set; }

        public Verb()
        {
        }
    }
}