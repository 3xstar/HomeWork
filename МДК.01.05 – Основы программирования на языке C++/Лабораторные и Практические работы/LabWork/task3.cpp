#include <iostream>

using namespace std;

struct Student{
    string name;
    double grade;
    string pass_status;
};

const int students_count = 9;

void pass_status(Student (&array)[students_count]){
    for(Student& s : array){
        Student* ptr = &s;
        if(ptr->grade >= 3){
            ptr->pass_status = "passed";
        }
        else{
            ptr->pass_status = "not_passed";
        }
    }
}

void student_operations(Student (&array)[students_count]){
    int passed_count = 0;
    int not_passed_count = 0;
    double sum = 0;
    
    for(Student& s : array){
        Student* ptr = &s;
        if(ptr->pass_status == "passed"){
            passed_count += 1;
        }
        if(ptr->pass_status == "not_passed"){
            not_passed_count += 1;
        }
        sum += ptr->grade;
    }
    
    double passed_percent = (passed_count * 100) /students_count;
    double not_passed_percent = (not_passed_count * 100) /students_count;
    double mid_grade = sum/students_count;
    
    cout << "Процент сдавших учеников: " << passed_percent << "%" << endl;
    cout << "Процент несдавших учеников: " << not_passed_percent << "%" << endl;
    cout << "Средняя оценка за зачет: " << mid_grade << endl;
};

int main(){
    Student students_list[students_count]{{"Гриша", 5, "Нет"},  {"Саша", 3, "Нет"}, {"Маша", 4, "Нет"}, {"Никита", 5, "Нет"},
     {"Артем", 1, "Нет"}, {"Максим", 3, "Нет"}, {"Влад", 4, "Нет"}, {"Боря", 2, "Нет"}, {"Захар", 5, "Нет"}};

    pass_status(students_list);
    student_operations(students_list);
}