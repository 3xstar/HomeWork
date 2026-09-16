#include <iostream>
#include <vector>
#include <algorithm>

using namespace std;

int main() {

    string str = "apple,banana,orange,apple,kiwi";
    vector<string> words;
    string temp = "";

    // Разбиваем строку
    for (char ch : str) {
        if (ch == ',') {
            words.push_back(temp);
            temp = "";
        } else {
            temp += ch;
        }
    }
    // Добавляем последнее слово
    words.push_back(temp);

    // Сортируем
    sort(words.begin(), words.end());

    // Удаляем дубликаты
    words.erase(unique(words.begin(), words.end()), words.end());

    // Вывод
    for (const string& word : words) {
        cout << word << " ";
    }

    return 0;
}
