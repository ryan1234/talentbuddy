using System;
using System.Linq;
using System.Text;

class MyClass {
    public void extract_contexts(string[] books, string[] tweets, int w) {
        foreach (string tweet in tweets.ToList())
        {   
            foreach (string book in books.ToList())
            {
                // We found a book in the tweet. Let's check the tokens.
                if (tweet.Contains(book))
                {
                    string[] tokens = tweet.Split(new string[] { book }, StringSplitOptions.None);

                    string[] tokensLeft = tokens[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    string[] tokensRight = tokens[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    
                    StringBuilder sb = new StringBuilder();
                    
                    foreach (string tokenLeft in tokensLeft.ToList().Skip(Math.Max(0, tokensLeft.Count() - w)).Take(w))
                    {
                        sb.Append(tokenLeft + " ");
                    }
                    
                    sb.Append("-TITLE- ");
                    
                    foreach (string tokenRight in tokensRight.ToList().Take(w))
                    {
                        sb.Append(tokenRight + " ");
                    }
                    
                    System.Console.WriteLine(sb.ToString().Trim());
                }
            }
        }
    }
}
