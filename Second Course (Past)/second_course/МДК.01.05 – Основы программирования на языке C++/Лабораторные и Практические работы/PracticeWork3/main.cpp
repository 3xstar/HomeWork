#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include <algorithm>
#include <vector>
#include <ctime>
#include <iomanip>

using namespace std;

// Файл, хранящий данные:
const string DATA_FILE = "data.csv";

// Типы финансовых операций
enum OperationType{
    INCOME,
    EXPENSE
};

// Структура финансовой операции
struct Operation {
    int id;
    OperationType type;
    string category;
    double amount;
    string date;
    string description;
};


vector<Operation> operations;
int nextId = 1;

void loadFromFile() {
    ifstream file(DATA_FILE);
    string line;

    if(!file.is_open()){
        cout << "Ошибка: Файл не найден, при сохранении будет создан новый" << endl;
        return;
    }

    while(getline(file, line)){
        if(line.empty()) continue;
        stringstream ss(line);
        string field;

        Operation op;


        getline(ss, field, ',');
        op.id = stoi(field);

        getline(ss, field, ',');
        op.type = static_cast<OperationType>(stoi(field));

        getline(ss, field, ',');
        op.category = field;

        getline(ss, field, ',');
        op.amount = stod(field);

        getline(ss, field, ',');
        op.date = field;

        getline(ss, field, ',');
        op.description = field;

        
        operations.push_back(op);
        if(op.id >= nextId) {
            nextId = op.id + 1;
        }
    }
    
    file.close();
    cout << "Данные выгружены из файла " << DATA_FILE << endl;
}

void saveToFile() {
    ofstream file(DATA_FILE);

    if(!file.is_open()){
        cout << "Ошибка: Не удалось открыть файл для записи" << endl;
        return;
    }

    for (const Operation& op : operations){
        file << op.id << ","
            << (op.type == INCOME ? "0" : "1") << ","
            << op.category << ","
            << op.amount << ","
            << op.date << ","
            << op.description << "\n";
    }

    file.close();
    cout << "Данные сохранены в файл " << DATA_FILE << endl;
}

void addOperation(OperationType type, string category, double amount, string date, string description)
{
    Operation op{nextId++, type, category, amount, date, description};
    operations.push_back(op);
    cout << "Добавлена операция: " << category << " на сумму " << amount << " прошло успешно!";
    saveToFile();
}

void displayOperations()
{
    if (operations.empty()) {
        cout << "Список операций пуст\n";
        return;
    }

    cout << "\nВсе операции:\n";
    cout << setw(3) << "ID" << " | "
    << setw(10) << "Тип: " << " | "
    << setw(15) << "Категория" << " | "
    << setw(10) << "Сумма" << " | "
    << setw(10) << "Дата" << " | "
    << "Описание\n";
    cout << string(80, '-') << endl;

    for(const auto& op : operations) {
        cout << setw(3) << op.id << " | "
        << setw(10) << (op.type == INCOME ? "ДОХОД" : "РАСХОД") << " | "
        << setw(15) << op.category << " | "
        << setw(10) << fixed << setprecision(2) << op.amount << " | "
        << setw(10) << op.date << " | "
        << op.description << "\n";
    }
}

void displayByType(OperationType type){
    if (operations.empty()) {
        cout << "Список операций пуст\n";
        return;
    }

    cout << "\nВсе операции с типом: " << (type == INCOME ? "ДОХОД" : "РАСХОД") << "\n";
    cout << setw(3) << "ID" << " | "
    << setw(10) << "Тип: " << " | "
    << setw(15) << "Категория" << " | "
    << setw(10) << "Сумма" << " | "
    << setw(10) << "Дата" << " | "
    << "Описание\n";
    cout << string(80, '-') << endl;

    bool found = false;
    for(const auto& op : operations) {
        if(op.type == type){
            found = true;
            cout << setw(3) << op.id << " | "
            << setw(10) << (op.type == INCOME ? "ДОХОД" : "РАСХОД") << " | "
            << setw(15) << op.category << " | "
            << setw(10) << fixed << setprecision(2) << op.amount << " | "
            << setw(10) << op.date << " | "
            << op.description << "\n";
        }
    }

    if(!found) {
        cout << "Операции данного типа не найдены\n";
    }
}

void displayByDateRange(string startDate, string endDate){
    if (operations.empty()) {
        cout << "Список операций пуст\n";
        return;
    }

    cout << "\nВсе операции в перимод с " << startDate << " по " << endDate << endl;
    cout << setw(3) << "ID" << " | "
    << setw(10) << "Тип: " << " | "
    << setw(15) << "Категория" << " | "
    << setw(10) << "Сумма" << " | "
    << setw(10) << "Дата" << " | "
    << "Описание\n";
    cout << string(80, '-') << endl;

    bool found = false;
    for(const auto& op : operations) {
        if(op.date >= startDate && op.date <= endDate)
        {
            found = true;
            cout << setw(3) << op.id << " | "
            << setw(10) << (op.type == INCOME ? "ДОХОД" : "РАСХОД") << " | "
            << setw(15) << op.category << " | "
            << setw(10) << fixed << setprecision(2) << op.amount << " | "
            << setw(10) << op.date << " | "
            << op.description << "\n";
        }
    }
        if(!found) {
        cout << "Операции в данный период не найдены\n";
    }
}

void deleteOperation(int id){
    if (operations.empty()) {
        cout << "Список операций пуст\n";
        return;
    }

    auto it = find_if(operations.begin(), operations.end(), [id](const Operation& op)
    {
        return op.id == id;
    });
        
    if (it != operations.end()){
        operations.erase(it);
        cout << "Операция с ID " << id << " успешно удалена\n";
        saveToFile();
    }
    
    else{
        cout << "Операция с ID " << id << " не найдена\n";
    }
}





