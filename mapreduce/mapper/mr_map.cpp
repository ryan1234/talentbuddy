#include <iostream>
#include <string>
#include <vector>

using namespace std;

int d = 10;

string search(string pat, string txt, int q)
{
    int M = pat.length();
    int N = txt.length();
    int i;
    int p = 0;  // hash value for pattern
    int t = 0; // hash value for txt
    int h = 1;
    int counted = 0;
  
    for (i = 0; i < M-1; i++)
        h = (h * d) % q;
  
    for (i = 0; i < M; i++)
    {
        p = (d*p + pat[i])%q;
        t = (d*t + txt[i])%q;
    }
  
    for (i = 0; i <= N - M; i++)
    {
        if ( p == t )
        {
    		return txt.substr(i, M);
        }
         
        if ( i < N-M )
        {
            t = (d*(t - txt[i]*h) + txt[i+M])%q;
             
            if(t < 0) 
              t = (t + q); 
        }
    }
    
    return "";
}

void mr_map(const vector<string> &search_strings, const vector<string> &docs) {
    for (int i = 0; i < search_strings.size(); i++) {
        string str;
        
        for (int j = 0; j < docs.size(); j++) {
            string found = search(search_strings[i], docs[j], 104677);
            if (found == search_strings[i]) {
                str += std::to_string(j) + " ";
            }
        }
        
        if (str == "") {
            cout << "-1\n";
        }
        else {
            cout << str + "\n";
        }
    }
    
}
