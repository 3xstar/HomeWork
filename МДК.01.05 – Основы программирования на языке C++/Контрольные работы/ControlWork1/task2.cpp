#include <iostream>
#include <vector>
#include <numeric>

using namespace std;

int multiplication = 0;
int first_numb = 0;


int main(){
    vector<int> numbers = {5, 9, 3, 2, 4, 6, 8, 1, 7, 10};
    int sum = accumulate(numbers.begin(), numbers.end(), 0);

    int multiplication = 1;

    cout << "Сумма элементов: " << sum << endl;

    for (int i=0; i < numbers.size(); i++){
    multiplication *= numbers[i];
    }
    
    int min_numb = numbers[0];

    for (int i=0; i < numbers.size() - 1; i++){
    if(min_numb > numbers[i + 1]){
        min_numb = numbers[i + 1];
    }
    }

    int max_numb = numbers[0];
    for (int i=0; i < numbers.size() - 1; i++){
    if(max_numb < numbers[i + 1]){
        max_numb = numbers[i + 1];
    }
    }


    cout << "Произведение элементов: " << multiplication << endl;
    cout << "Мин. элемент: " << min_numb << endl;
    cout << "Макс. элемент: " << max_numb << endl;
    cout << "Разница между мин. элементом и макс. элементом: " << max_numb - min_numb;
}