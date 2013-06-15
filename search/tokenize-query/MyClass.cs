using System;
using System.Collections.Generic;

class MyClass {
    public void tokenize_query(string query, string punctuation) {
        List<string> tokens = new List<string>();
        
        string token = "";
        
        foreach (char c in query.ToCharArray())
        {
            if (punctuation.Contains(c.ToString()))
            {
                tokens.Add(token);
                token = "";
            }
            else
            {
                token += c.ToString();
            }
        }
        
        tokens.Add(token);
        
        foreach (string str in tokens)
        {
            System.Console.WriteLine(str);            
        }
    }
}
