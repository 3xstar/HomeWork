#include <iostream>
#include <stdexcept>

using namespace std;

int main(){
    try{

    int number;

    cout << "Введите число: ";
    if(!(cin >> number)){
        throw runtime_error("Ошибка! Введено не число");
    }

    if(number < 0){
        throw runtime_error("Ошибка! Отрицательное число");
    }

    cout << "Успех! Вы ввели корректное число";
    }
    
    catch(const runtime_error& e){
        cout << e.what();
    }
}