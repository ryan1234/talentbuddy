using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void extract_books(string[] contexts, string[] tweets) {
        List<string> books = new List<string>();
        
        foreach (string tweet in tweets.ToList()) {        
            var tweetTokens = tweet.Split(' ').ToList().Where(t => t.Trim().Length > 0);
            
            foreach (string context in contexts.ToList()) {                                
                var contextTokens = context.Split(' ').ToList().Where(c => c.Trim().Length > 0);
                bool sandwich = context.Trim().Split(new string[] { "-TITLE-" }, StringSplitOptions.RemoveEmptyEntries).Count() == 2;
                bool leftOnly = context.Trim().EndsWith("-TITLE-");
                bool rightOnly = context.Trim().StartsWith("-TITLE-");
                                
                if (sandwich) {
                    var contextLeftTokens = context.Split(new string[] { "-TITLE-" }, StringSplitOptions.RemoveEmptyEntries)[0].Split(' ').ToList();                    
                    var contextRightTokens = context.Split(new string[] { "-TITLE-" }, StringSplitOptions.RemoveEmptyEntries)[1].Split(' ').ToList();                                    
                    string book = GetSandwichTitle(tweetTokens.ToList(), contextLeftTokens.Where(t => t.Length > 0).ToList(), contextRightTokens.Where(t => t.Length > 0).ToList());
                    if (book != "")
                    {
                        //Console.WriteLine("sandwich" + " context: " + context);
                        books.Add(book);
                        break;
                    }
                }
                
                if (leftOnly) {
                    var leftmostContextTokens = context.Replace("-TITLE-", "").Trim().Split(' ').ToList();
                    string book = GetLeftTitle(tweetTokens.ToArray(), leftmostContextTokens.ToArray());
                    if (book != "") 
                    {
                        //Console.WriteLine("left" + " context: " + context);
                        books.Add(book);
                        break;
                    }
                }
                
                if (rightOnly) {
                    var rightmostContextTokens = context.Replace("-TITLE-", "").Trim().Split(' ').ToList();
                    string book = GetRightTitle(tweetTokens.ToArray(), rightmostContextTokens.ToArray());
                    if (book != "") 
                    {
                        //Console.WriteLine("right" + " context: " + context);
                        books.Add(book);
                        break;
                    }
                }
            }
        }
        
        foreach (var book in books.Distinct().OrderBy(b => b, StringComparer.Ordinal))
        {
            Console.WriteLine(book);
        }
    }
    
    public string GetRightTitle(string[] tweetTokens, string[] contextTokens) {
        List<int> firstLast = GetFirstLast(tweetTokens, contextTokens);
        if (firstLast.Count() > 0) {
            int first = firstLast.ToArray()[0];
        
            if (first > -1) {
                return String.Join(" ", tweetTokens.Take(first).ToArray());
            }
        }

        return "";
    }
    
    public string GetLeftTitle(string[] tweetTokens, string[] contextTokens) {
        List<int> firstLast = GetFirstLast(tweetTokens, contextTokens);
        if (firstLast.Count() > 0) {
            int last = firstLast.ToArray()[1];

            if (last > -1) {
                return string.Join(" ", tweetTokens.ToList().Skip(last + 1).Take(tweetTokens.Count() - last).ToArray());
            }
        }

        return "";
    }    
    
    public string GetSandwichTitle(List<string> tweetTokens, List<string> leftContextTokens, List<string> rightContextTokens) {
        List<int> firstLast = GetFirstLast(tweetTokens.ToArray(), leftContextTokens.ToArray());
        if (firstLast.Count() > 0) {
            int last = firstLast.ToArray()[1];
            var newTweetTokens = tweetTokens.Skip(last + 1).ToList();
            
            firstLast.Clear();
            firstLast = GetFirstLast(newTweetTokens.ToArray(), rightContextTokens.ToArray());
            if (firstLast.Count() > 0) {
                int first = firstLast.ToArray()[0];
                int offset = tweetTokens.Count() - newTweetTokens.Count();
                //Console.WriteLine("First: " + first + " " + String.Join(" ", tweetTokens.ToArray()));
                return String.Join(" ", tweetTokens.Skip(last + 1).Take(first + offset - last - 1).ToArray());
            }
        }

        return "";
    }
    
    public string GetBook(string[] tweetTokens, int start, int end) {
        List<string> tokens = new List<string>();
        
        for (int i = start; i <= end; i++) {
            tokens.Add(tweetTokens[i]);
        }
        
        return String.Join(" ", tokens.ToArray());
    }
    
    public List<int> GetFirstLast(string[] big, string[] small) {
        int[,] matrix = new int[big.Length,small.Length];
        
        for (int i = 0; i < big.Length; i++) {
            for (int j = 0; j < small.Length; j++) {
        		if (big[i] == small[j]) { matrix[i,j] = 1; }
        		else { matrix[i,j] = 0; }
        	}
        }
        
        int diagonalCount = big.Length - small.Length + 1;
        int sum = 0;
        int first = -1;
        int last = -1;
        List<int> firstLast = new List<int>();
        
        for (int i = 0; i < diagonalCount; i++) {
            for (int j = 0; j < small.Length; j++) {
                if (j == 0) { first = j + i; }
                if (j == small.Length - 1) { last = j + i; }
                
        		sum += matrix[j + i, j];
        	}
        	if (sum == small.Length) 
            { 
                firstLast.Add(first);
                firstLast.Add(last);
            }
        	sum = 0;
            first = -1;
            last = -1;
        }
        
        return firstLast;
    }
}
