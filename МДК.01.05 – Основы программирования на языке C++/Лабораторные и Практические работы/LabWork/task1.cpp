#include <iostream>

using namespace std;

void withdraw_balance(double& balance){
    double amount;

    while(true){
        cout << "Введите количество денег для снятия: ";
        cin >> amount;

        if(amount > balance){
            cout << "Ошибка: нельзя снять денег больше, чем есть на балансе" << endl;
            continue;
        }
        if(amount <= 0){
            cout << "Ошибка: сумма не может быть отрицательной или равной нулю" << endl;
            continue;
        }
        

        balance -= amount;
        cout << "Деньги успешно сняты с баланса" << endl;
        cout << "Текущий баланс: " << balance << endl;
        break;
    }
}

void top_up_balance(double& balance){
    double amount;

    while(true){
        cout << "Введите количество денег для пополнения: ";
        cin >> amount;

        if(amount <= 0){
            cout << "Ошибка: сумма не может быть отрицательной или равной нулю" << endl;
            continue;
        }

        balance += amount;
        cout << "Деньги успешно зачислены на баланс" << endl;
        cout << "Текущий баланс: " << balance << endl;
        break;
    }
};

void check_balance(double& balance){
    cout << "Ваш текущий баланс: " << balance << endl;
};

void menu(double& balance){
    cout << "Добро пожаловать в банк! Здесь вы можете выполнять операции со своим балансом" << endl;
    cout << "Ваш текущий баланс: " << balance << endl;
    while(true){
    cout << "1. Снять денег с баланса\n2. Пополнить деньги на балансе\n3. Проверить баланс\n4. Выйти из банка\n";
    int choice;
    cout << "Введите номер действия: ";
    cin >> choice;
    switch (choice){
        case 1:{
            withdraw_balance(balance);
            break;
           }
        case 2:{
            top_up_balance(balance);
            break;
           }
        case 3:{
            check_balance(balance);
            break;
           }
        case 4:{
            cout << "До встречи!";
            return;
           }
        default:
        cout << "Ошибка: введите число от 1 до 4";
        cin.clear();
        cin.ignore(10000, '\n');
        }
    }
};

int main(){
    double balance = 0;
    cout << "Введите ваш изначальный баланс: ";
    cin >> balance;
    menu(balance);
}