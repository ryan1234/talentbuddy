using System.Collections.Generic;
using System.Collections;
using System.Linq;

class MyClass {
    public void search_query(string[] query, string[] pages) {
        // Write your code here.
        int counted = 0;
        
        foreach (string page in pages.ToList())
        {
            int maxLocation = 0;
            int occurences = 0;

            foreach (string q in query.ToList())
            {
                int location = page.IndexOf(q, maxLocation, page.Length - maxLocation);
                if (location >= 0)
                {
                    occurences++;
                    maxLocation = location + q.Length;
                }
            }
            
            if (occurences == query.ToList().Count)
            {
                counted++;
            }
        }
        
        System.Console.WriteLine(counted);
    }
}
