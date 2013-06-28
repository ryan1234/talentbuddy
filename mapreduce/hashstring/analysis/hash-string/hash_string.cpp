#include <iostream>
#include <string>
#include <cmath>
#include <fstream>
#include <streambuf>
#include <sys/time.h>
#include <ctime>
#include <inttypes.h>
#include <stdio.h>
#include <string.h>

using namespace std;

int d = 10;

uint64_t GetTimeMs64()
{
	struct timeval tv;

	gettimeofday(&tv, NULL);

	uint64_t ret = tv.tv_usec;
	/* Convert from micro seconds (10^-6) to milliseconds (10^-3) */
	ret /= 1000;

	/* Adds the seconds (10^0) after converting them to milliseconds (10^-3) */
	ret += (tv.tv_sec * 1000);

	return ret;
}

int search_rabin_karp(string pat, string txt, int q)
{
	int M = pat.length();
	int N = txt.length();
	int i;
	int p = 0;  // hash value for pattern
	int t = 0; // hash value for txt
	int h = 1;
	int counted = 0;
 
	uint64_t start = 0;
	uint64_t end = 0;

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
			if (txt.substr(i, M) == pat) 
			{
				counted++;
			}
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

int search_naive_1(const string &a, const string &b) {
	int counted = 0;
	int index = 0;

	string::size_type location = b.find(a, index);
	while (location != string::npos) {
		counted++;
		index = location + 1;
	        location = b.find(a, index);
	}
	
	return counted;
}

int search_naive_2(const string &pat, const string &txt)
{
	int counted = 0;
	int M = pat.length();
	int N = txt.length();
 
	/* A loop to slide pat[] one by one */
	for (int i = 0; i <= N - M; i++)
	{
		int j;
 
		/* For current index i, check for pattern match */
		for (j = 0; j < M; j++)
		{
			if (txt[i+j] != pat[j])
				break;
		}

		if (j == M)  // if pat[0...M-1] = txt[i, i+1, ...i+M-1]
		{
			counted++;
		}
	}

	return counted;
}

main() {
	std::ifstream f1("shaks12.txt");
	std::string search_text((std::istreambuf_iterator<char>(f1)),
		std::istreambuf_iterator<char>());

	std::ifstream f2("pattern.txt");
	std:string search_term((std::istreambuf_iterator<char>(f2)),
		std::istreambuf_iterator<char>());

	search_term = search_term.substr(0, search_term.length() - 1);

	uint64_t start = 0;
	uint64_t end = 0;

	start = GetTimeMs64();
	int count1 = search_rabin_karp(search_term, search_text, 104677);
	end = GetTimeMs64();
	uint64_t elapsed1 = end - start;	
	cout << "Rabin Karp" << "," << end - start << "\n";

	start = GetTimeMs64();
	int count2 = search_naive_1(search_term, search_text);
	end = GetTimeMs64();
	uint64_t elapsed2 = end - start;
	cout << "Naive 1" << "," << end - start << "\n";

        start = GetTimeMs64();
        int count3 = search_naive_2(search_term, search_text);
        end = GetTimeMs64();
	uint64_t elapsed3 = end - start;
        cout << "Naive 2" << "," << end - start << "\n";

	//cout << elapsed1 << "," << elapsed2 << "," << elapsed3 << "\n";

	return 0;
}
