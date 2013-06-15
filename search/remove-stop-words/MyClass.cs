using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void remove_stopwords(string[] query, string[] stopwords) {
        List<string> ok = new List<string>();

        for (int i = 0; i < stopwords.Length; i++)
        {
            for (int j = 0; j < query.Length; j++)
            {
                if (query[j] == stopwords[i])
                {
                    query[j] = "";
                }
            }
        }
        
        for (int i = 0; i < query.Length; i++)
        {
            if (!string.IsNullOrEmpty(query[i]))
            {
                System.Console.WriteLine(query[i]);
            }
        }
    }
}
