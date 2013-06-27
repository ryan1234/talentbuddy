using System;
using System.Linq;
using System.Collections.Generic;

class MyClass {
    public void context_pruning(string[] contexts, string[] triggers) {
        foreach (string context in contexts.ToList()) {        
            foreach (string trigger in triggers.Reverse().ToList()) {
                var left = context.Split(new string[] { "-TITLE-" }, StringSplitOptions.None)[0];
                var leftTokens = left.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
                
                var right = context.Split(new string[] { "-TITLE-" }, StringSplitOptions.None)[1];
                var rightTokens = right.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries).ToList();
                
                if (InContext(left, trigger)) {
                    ProcessLeft(left, trigger, rightTokens);
                    break;
                }
                
                if (InContext(right, trigger)) {
                    ProcessRight(right, trigger, leftTokens);
                    break;
                }
            }
        }
    }
    
    public bool InContext(string context, string trigger) 
    {
        if (context.Trim() == trigger.Trim()) { return true; }
        
        if (context.Contains(trigger))
        {
            int i = context.IndexOf(trigger);
            
            if (context.StartsWith(trigger)) 
            {
                if (context[i + trigger.Length] == ' ')    
                    return true;
                else
                    return false;
            }
            
            if (context.EndsWith(trigger)) 
            {
                if (context[i - 1] == ' ')
                    return true;
                else
                    return false;
            }
            
            if (context[i - 1] == ' ' && context[i + trigger.Length] == ' ')
                return true;
        }
        
        return false;
    }
    
    public void ProcessLeft(string left, string trigger, List<string> rightTokens)
    {
        string rightOfTrigger = "";
        
        int count = left.Split(new string[] { trigger }, StringSplitOptions.RemoveEmptyEntries).Where(s => s.Trim().Length > 0).Count();
        if (left.StartsWith(trigger) && count == 1) {
            rightOfTrigger = left.Split(new string[] { trigger }, StringSplitOptions.RemoveEmptyEntries)[0];
            Console.WriteLine(trigger.Trim() + " " + rightOfTrigger.Trim() + " -TITLE- " + GetFirst(rightTokens));                    
        }
        else if (count > 1) {
            rightOfTrigger = left.Split(new string[] { trigger }, StringSplitOptions.RemoveEmptyEntries)[1];
            Console.WriteLine(trigger.Trim() + " " + rightOfTrigger.Trim() + " -TITLE- " + GetFirst(rightTokens));        
        }
        else {
            Console.WriteLine(trigger.Trim() + " -TITLE- " + GetFirst(rightTokens));
        }
    }
    
    public void ProcessRight(string right, string trigger, List<string> leftTokens)
    {
        string leftOfTrigger = "";
        
        int count = right.Split(new string[] { trigger }, StringSplitOptions.RemoveEmptyEntries).Where(s => s.Trim().Length > 0).Count();
        
        if (count >= 1) {
            leftOfTrigger = right.Split(new string[] { trigger }, StringSplitOptions.RemoveEmptyEntries)[0];
            Console.WriteLine(GetLast(leftTokens) + " -TITLE- " + leftOfTrigger.Trim() + " " + trigger.Trim());            
        }
        else {
            Console.WriteLine(GetLast(leftTokens) + " -TITLE- " + trigger.Trim());            
        }
    }
    
    public string GetFirst(List<string> strings)
    {
        if (strings.Count == 0) { return ""; }
        return strings.First();
    }
    
    public string GetLast(List<string> strings)
    {
        if (strings.Count == 0) { return ""; }
        return strings.Last();
    }
}
