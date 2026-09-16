#include <iostream>
#include <vector>

using namespace std;

struct Person{
    string name;
    int target_floor;
    double weight;
    string direction;
};

struct Elevator{
    int current_floor;
    int max_weight;
    int person_count;
    vector <Person> person_list;
};

void elevator_settings(Elevator& test){
    cout << "Настройка лифта..." << endl;
    while(true){
        cout << "Введите на каком этаже находится лифт: ";
        cin >> test.current_floor;
        if(test.current_floor < 1){
            cout << "ЭТАЖ НЕ МОЖЕТ БЫТЬ ОТРИЦАТЕЛЬНЫМ!!!" << endl;
            continue;
        }

        cout << "Введите грузоподъемность лифта (в кг): ";
        cin >> test.max_weight;

        if(test.max_weight < 1){
            cout << "ГРУЗОПОДЪЕМНОСТЬ НЕ МОЖЕТ БЫТЬ ОТРИЦАТЕЛЬНОЙ!!!" << endl;
            continue;
        }
        cout << "Настройка лифта закончена!" << endl;
        break;
    }
}

Person customize_person(Person& test, Elevator& floor_check){
    while(true){
        cout << "Введите имя человека: ";
        cin >> test.name;

        cout << "Введите целевой этаж человека: ";
        cin >> test.target_floor;
        if(test.target_floor < 1){
            cout << "ЭТАЖ НЕ МОЖЕТ БЫТЬ ОТРИЦАТЕЛЬНЫМ!!!" << endl;
            continue;
        }
        if(test.target_floor == floor_check.current_floor){
            cout << "Зачем человеку на этаж, где он уже находится?" << endl;
            continue;
        }

        cout << "Введите вес человека: ";
        cin >> test.weight;
        if(test.weight < 1){
            cout << "ВЕС НЕ МОЖЕТ БЫТЬ ОТРИЦАТЕЛЬНЫМ!!!" << endl;
            continue;
        }
        cout << "Настройка человека закончена!" << endl;
        return test;
        break;
    }
}

string calculate_direction(Person& person, Elevator& elevator){
    if(person.target_floor > elevator.current_floor){
        person.direction = "up";
    }
    if(person.target_floor < elevator.current_floor){
        person.direction = "down";
    }
    return person.direction;
}

void add_to_elevator(Person& person, Elevator& elevator){
    cout << "Добавление человека под именем " << person.name << " в лифт..." << endl;
    if(elevator.max_weight < person.weight){
        cout << "В лифте не хватает грузоподъемности для добавления пассажира с таким весом\nОставшееся место в лифте в кг: " << elevator.max_weight << "\nВес человека: " << person.weight << " кг"<< endl;
        return;
    }
    elevator.max_weight -= person.weight;
    elevator.person_count += 1;
    elevator.person_list.push_back(person);
}

void calculate_way(Person person, Elevator elevator){
    if(person.direction == "up"){
        int way = person.target_floor - elevator.current_floor;
        cout << "Чтобы человеку под именем " << person.name << " добраться до целевого этажа, ему нужно преодолеть " << way << " этажей вверх" << endl;
    }

    else if(person.direction == "down"){
        int way = elevator.current_floor - person.target_floor;
        cout << "Чтобы человеку под именем " << person.name << " добраться до целевого этажа, ему нужно преодолеть: " << way << " этажей вниз" << endl;
    }
}

int main(){
    Elevator elevator;
    Person person1;
    Person person2;
    Person person3;
    cout << "---БЕСКОНЕЧНЫЙ ЛИФТ---" << endl;

    elevator_settings(elevator);

    cout << "Настройка людей в лифте..." << endl;

    customize_person(person1, elevator);
    customize_person(person2, elevator);
    customize_person(person3, elevator);

    calculate_direction(person1, elevator);
    add_to_elevator(person1, elevator);

    calculate_direction(person2, elevator);
    add_to_elevator(person2, elevator);
    

    calculate_direction(person3, elevator);
    add_to_elevator(person3, elevator);

    cout << "Вычисление пути пассажиров..." << endl;
    calculate_way(person1, elevator);
    calculate_way(person2, elevator);
    calculate_way(person3, elevator);
}