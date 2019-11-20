using System;

namespace Translator.Words
{
    [Serializable]
    public class Verb
    {
        public string[,] Trans;
        public Verb(string[,] trans)
        {
            Trans = trans;
        }
    }
}