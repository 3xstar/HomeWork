#include <iostream>

using namespace std;

struct Day{
    string day_name;
    int steps_count;
};

void step_enter(Day (&array)[7]){
    for(Day& d : array){
        cout << "Сколько шагов было сделано в " << d.day_name << ": ";
        cin >> d.steps_count; 
    }
};

void day_operations(Day (&array)[7]){
    Day min_steps_day = {"Day", array[0].steps_count};
    Day max_steps_day = {"Day", 0};
    int sum = 0;
    
    for(Day& d : array){
        if(min_steps_day.steps_count >= d.steps_count){
            min_steps_day = d;}
    }

    for(Day& d : array){
        if(max_steps_day.steps_count < d.steps_count){
            max_steps_day = d;}
        }
    

    for(Day& d : array){
        sum += d.steps_count;
    }
    double middle_steps = sum / 7;
    
    cout << "День с минимальным количеством шагов: " << min_steps_day.day_name << endl;
    cout << "День с максимальным количеством шагов: " << max_steps_day.day_name << endl;
    cout << "Среднее количество шагов в неделю: " << middle_steps << endl;
};

int main(){
    Day week[7]{{"Monday", 0}, {"Tuesday", 0}, {"Wednesday", 0},
     {"Thursday", 0}, {"Friday", 0}, {"Saturday", 0}, {"Sunday", 0}};

    cout << "Отчет шагов за неделю" << endl;
    step_enter(week);
    cout << endl;
    cout << "По результатам..." << endl;
    day_operations(week);
}