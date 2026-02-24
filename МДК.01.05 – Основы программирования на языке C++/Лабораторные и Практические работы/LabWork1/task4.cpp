#include <iostream>
#include <algorithm>
#include <vector>

using namespace std;

int main()
{
    vector <int> numbers = {5,4,3,2,1,2,3,4,5};

    bool isPalindrom = equal(numbers.begin(), numbers.begin()+numbers.size()/2, numbers.rbegin());

    if(isPalindrom)
    {
        cout << "Вектор является палиндромом";
    }
    else
    {
        cout << "Вектор не является палиндромом";
    }
}