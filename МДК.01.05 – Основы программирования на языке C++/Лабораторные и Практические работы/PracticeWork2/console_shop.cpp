#include <iostream>
#include <vector>
#include <string>

using namespace std;

enum class Category{Console, Game, Device, Accessories};

struct Item_Card{
    string name;
    Category category;
    int quantity;
    double price;
};


string CategoryString(Category name){
    switch(name){
        case Category::Console: return "Консоль";
        case Category::Game: return "Игра";
        case Category::Device: return "Девайс";
        case Category::Accessories: return "Аксессуар";
        default: return "Неизвестная категория";
    }

}


Item_Card PS5{"Playstation 5", Category::Console, 17, 49999.99};
Item_Card XBOX_SERIES_X{"XBOX SERIES X", Category::Console, 25, 39999.99};
Item_Card GTA_VI{"GTA VI", Category::Game, 64, 9999.99};
Item_Card PS_VR{"Playstation VR", Category::Device, 39, 19999.99};
Item_Card PS5_Stand{"Stand for PS5", Category::Accessories, 73, 2999.99};


void all_items(vector <Item_Card> items){
    cout << "Список товаров в магазине:" << endl;
    for (Item_Card i: items){
        cout << "Название: " << i.name << " | Категория: " << CategoryString(i.category) << " | Количество на складе: " << i.quantity << " | Цена за штуку: " << i.price << endl;
    }
}


void basket(vector <Item_Card> items, double& basket_sum, vector <Item_Card> in_basket){
    int index = 1;

    cout << "Ассортимент:" << endl;
    for (Item_Card i: items){
        if (i.quantity > 0){
            cout << index << " | Название: " << i.name << " | Цена: " << i.price << endl;
            index++;
        }
    }

    cout << "Введите номер товара: ";
    int choice;
    cin >> choice;

    int new_index = 1;
    for (Item_Card i: items){
        if (i.quantity > 0){
            if (choice == new_index){
                i.quantity --;
                cout << endl;
                cout << "Товар: " << i.name << " добавлен в корзину!" << endl;
                in_basket.push_back(i);
                basket_sum += i.price;
                cout << "Товары в корзине:" << endl;;
                for(Item_Card i : in_basket)
                {cout << i.name << endl;}
                cout << "Цена корзины: " << basket_sum << endl;
            }
            new_index++;
        }
    }
    int basket_continue_choice = 0;
    cout << endl;
    cout << "Продолжить покупки? (1 - да, 2 - нет): ";
    cin >> basket_continue_choice;

    if (basket_continue_choice == 1){
        cout << endl;
        basket(items, basket_sum, in_basket);
    }
    else if(basket_continue_choice == 2){
    cout << endl;
    cout << "Итоговая цена корзины: " << basket_sum << endl;
    cout << "Итоговые товары в корзине:" << endl;
    for(Item_Card i : in_basket)
    {cout << i.name << endl;}
    }
}


int main(){
vector <Item_Card> my_items;
my_items.push_back(PS5);
my_items.push_back(XBOX_SERIES_X);
my_items.push_back(GTA_VI);
my_items.push_back(PS_VR);
my_items.push_back(PS5_Stand);

double my_basket_sum = 0;

vector<Item_Card> in_my_basket;

all_items(my_items);
cout << endl;
basket(my_items, my_basket_sum, in_my_basket);
}
