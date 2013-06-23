#include <iostream>
#include <vector>

using namespace std;

unsigned mod_pow(unsigned num, unsigned pow, unsigned mod)
{
    unsigned test;
    for(test = 1; pow; pow >>= 1)
    {
        if (pow & 1)
            test = (test * num) % mod;
        num = (num * num) % mod;
    }

    return test;
}

void fast_power(const vector<int> &a, const vector<int> &b) {
        int size = a.size();
    
        for (int i = 0; i < size; i++) {
            int total = mod_pow(a[i], b[i], 4211);
/*            
            int power = b[i];
            
            for (int j = 0; j < power; j++) {
                total = (total * a[i]) % 4211;
            }
*/

            cout << total << "\n";
        }
    
}
