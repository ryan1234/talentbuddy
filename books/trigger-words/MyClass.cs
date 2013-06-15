using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void extract_trigger_words(string[] contexts, int m) {
        int N = contexts.Length;

        List<IDF> idfs = new List<IDF>();
        
        foreach (string context in contexts.ToList())
        {
            string[] tokens = context.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            
            foreach (string token in tokens.ToList().Where(t => t != "-TITLE-").Distinct())
            {
                if (idfs.Where(i => i.Name == token).Count() > 0)
                {
                    var idf = idfs.Where(i => i.Name == token).First();
                    idf.Counted++;
                }
                else
                {
                    var idf = new IDF() { 
                       Name = token,
                       Counted = 1,
                       Value = 0
                    };
                    
                    idfs.Add(idf);
                }
            }
        }
        
        foreach (var idf in idfs)
        {
            double value = Math.Log(N / idf.Counted);
            idf.Value = value;
        }
                    
        foreach (var idf in idfs.OrderByDescending(i => i.Value).ThenBy(i => i.Name, StringComparer.Ordinal).Take(m))
        {
            System.Console.WriteLine(idf.Name);
        }
    }
    
    public class IDF
    {
        public int Counted { get; set; }
        public double Value { get; set; }
        public string Name { get; set; }       
    }
}
