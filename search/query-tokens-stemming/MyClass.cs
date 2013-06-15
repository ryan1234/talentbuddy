using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void token_stemming(string[] tokens, string[] suffixes)                                      
    {
        List<string> output = new List<string>();
        
        foreach (string token in tokens.ToList())
        {
            string newToken = token;
            
            foreach (string suffix in suffixes.ToList().OrderByDescending(s => s.Length)) 
            {                    
                if (token.EndsWith(suffix)) {
                    newToken = token.Substring(0, token.Length - suffix.Length);
                    break;
                }
            }
            
            output.Add(newToken);
        }
        
        foreach (string str in output)
        {
            System.Console.WriteLine(str);
        }
    }        
}
