#include <iostream>
#include <string>
#include <cmath>

using namespace std;

int d = 10;

int search(string pat, string txt, int q)
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
			counted++;
        }
         
        if ( i < N-M )
        {
            t = (d*(t - txt[i]*h) + txt[i+M])%q;
             
            if(t < 0) 
              t = (t + q); 
        }
    }
    
    return counted;
}

void hash_string(const string &a, const string &b) {
    int counted = search(a, b, 104677);
    cout << counted;
}
