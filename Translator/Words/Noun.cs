using System;

namespace Translator.Words
{
    [Serializable]
    public class Noun
    {
        public string[,] Trans { get; }
        public Noun(string[,] trans)
        {
            Trans = trans;
        }
    }
}
