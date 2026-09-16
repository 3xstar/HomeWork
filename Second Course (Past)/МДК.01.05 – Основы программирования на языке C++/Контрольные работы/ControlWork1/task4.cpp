#include <iostream>
#include <chrono>
#include <vector>
#include <algorithm>
#include <array>

using namespace std;


int main(){
    volatile long long sum = 0;

    auto time_in = chrono::steady_clock::now();

    for(int i=0; i < 10000000; i++){
        sum += i;
    }

    auto time_out = chrono::steady_clock::now();

    auto duration = time_out - time_in;

    auto ms = chrono::duration_cast<chrono::milliseconds>(duration); 
    cout << "Затраченное время на 10 000 000 итераций составляет: " << ms.count() << "ms." << endl;


    auto time_in2 = chrono::steady_clock::now();

    vector<int> arr2;
    for(int i=1; i < 1000; i++){
        arr2.push_back(i * i);
    }

    auto time_out2 = chrono::steady_clock::now();

    auto duration2 = time_out2 - time_in2;

    auto ms2 = chrono::duration_cast<chrono::milliseconds>(duration2); 
    cout << "Затраченное время на 1000 квадратов составляет: " << ms2.count() << "ms." << endl;

}