#include <iostream>
#include <string>
#include <array>
#include <vector>
#include <numeric>
#include <windows.h>
#include <algorithm>
#include <optional>

struct Student{
    std::string name;
    std::array<int, 5> marks;
};

using Gradebook = std::vector<Student>;

double calculateAVG(const Student& s) {
    double sum = std::accumulate(s.marks.begin(), s.marks.end(), 0.0);
    return sum / s.marks.size();
}

void PrintStudent (const Student& s) {
    std::cout << "Имя: " << s.name << "\tОценки: ";
    for (const auto& marks : s.marks) {
        std::cout << marks << "";
    }
    std::cout << "\tСредний балл: " << calculateAVG(s) << std::endl;
}

std::optional<Student> findStudent(const Gradebook& gradebook, std::string name){
    for (const auto& student : gradebook) {
        if (student.name == name){
            return student;
        }
    }
    return std::nullopt;
}

int main() {
    SetConsoleOutputCP(CP_UTF8);
    
    Gradebook gradebook = {
        {"Марк", {4, 5, 5, 5, 4}},
        {"Софья", {5, 5, 5, 4, 4}},
        {"Захар", {5, 5, 5, 5, 3}},
        {"Дима", {3, 2, 2, 4, 2}}
    };

    bool running = true;
    while (running) {
        std::cout << "\n--- Электронный журнал ---" << std::endl;
        std::cout << "1. Показать всех студентов" << std::endl;
        std::cout << "2. Сортировка по имени" << std::endl;
        std::cout << "3. Повысить всем на 1 балл" << std::endl;
        std::cout << "4. Уменьшить всем на 2 балла" << std::endl;
        std::cout << "5. Поиск по имени" << std::endl;

        int choice;
        std::cin >> choice;

        if (!std::cin) {
            std::cout << "ошибка ввода" << std::endl;
            std::cin.clear();
            std::cin.ignore(100, '\n');
            continue;
        }
        
        switch(choice) {
            case 1: {
                std::cout << "\n---Список студентов---" << std::endl;
                for (const auto& student : gradebook){
                    PrintStudent(student);
                }
                break;
            }
            case 2: {
                std::sort(gradebook.begin(), gradebook.end(), [](const Student& a, const Student& b) {
                    return a.name < b.name;
                });
                std::cout << "\nСтуденты отсоритрованы" << std:: endl;
                break;
            }
            case 3: {
                for (auto& student : gradebook) {
                    std::transform(student.marks.begin(), student.marks.end(), student.marks.begin(),
                    [](int marks) {if (marks < 5) return marks + 1; else return marks;});
                };
            }
            case 4: {
                for (auto& student : gradebook) {
                    std::transform(student.marks.begin(), student.marks.end(), student.marks.begin(),
                    [](int marks) {if (marks > 2) return marks -2; else return marks;});
                }
            }
            case 5: {
                std::cout << "Введите имя: " << std::endl;
                std::string name;
                std::cin >> name;
                auto result = findStudent(gradebook, name);
                if(result) {
                    std::cout << "Студент найден:" << std::endl;
                    PrintStudent(*result);
                }
                else {
                    std::cout << "Студента не существует" << std::endl;
                }
            }
        }
    }
}