#include <iostream>
#include <fstream>
#include <vector>

using namespace std;

int main() {

    ofstream outFile("numbers.txt");

    outFile << 10 << " "
            << 20 << " "
            << 30 << " "
            << 40 << " "
            << 50;

    outFile.close();

    ifstream inFile("numbers.txt");


    vector<int> numbers;
    int value;
    

    while (inFile >> value) {
        numbers.push_back(value);
    }

    inFile.close();


    // Вычисление среднего
    double sum = 0;

    for (int num : numbers) {
        sum += num;
    }

    double average = sum / numbers.size();


    // Вывод
    cout << "Среднее значение: " << average << endl;

    return 0;
}
