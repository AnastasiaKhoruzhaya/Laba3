using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Задание
1) Определить класс, указанный в варианте, содержащий:
 Не менее трех конструкторов (с параметрами и без, а также с
параметрами по умолчанию );
 статический конструктор(конструктор типа);
 определите закрытый конструктор; предложите варианты его вызова;
 поле - только для чтения(например, для каждого экземпляра сделайте
поле только для чтения ID - равно некоторому уникальному номеру
(хэшу) вычисляемому автоматически на основе инициализаторов
объекта);
 поле - константу;
 свойства(get, set) – для всех поле класса (поля класса должны быть
закрытыми); Для одного из свойств ограните доступ по set
 в одном из методов класса для работы с аргументами используйте ref -
и out-параметры.
 создайте в классе статическое поле, хранящее количество созданных
объектов (инкрементируется в конструкторе) и статический
метод вывода информации о классе.
 сделайте касс partial
 переопределяете методы класса Object: Equals, для сравнения объектов,
GetHashCode; для алгоритма вычисления хэша руководствуйтесь
стандартными рекомендациями, ToString – вывода строки –
информации об объекте.
2) Создайте несколько объектов вашего типа. Выполните вызов
конструкторов, свойств, методов, сравнение объекты, проверьте тип
созданного объекта и т.п.
3) Создайте массив объектов вашего типа. И выполните задание,
выделенное курсивом в таблице.
4) Создайте и выведите анонимный тип (по образцу вашего класса).
5) Ответьте на вопросы, приведенные ниже*/

/*Создать класс Product: id, Наименование, UPC,
Производитель, Цена, Срок хранения, Количество.
Свойства и конструкторы должны обеспечивать проверку
корректности. Добавить метод вывода общей суммы
продукта. Создать массив объектов. 
Вывести:
a) список товаров для заданного наименования;
b) список товаров для заданного наименования, цена которых
не превосходит заданную;*/

namespace ConsoleApp3
{
    partial class Product
    {
        public readonly int ID;
        public string name;

        private string upd;



        public string UPD
        {
            get { return upd; }
            set { upd = value; }
        }

        public string maker;
        public int price;
        public string shelfLife;
        public const int quantity = 9;

        public override string ToString()//переопределение методов tostring и equals
        {
            return "This object is a product";
        }
        public override bool Equals(object product)
        {
            if ((int)product < 10)
                return true;
            return false;
        }
    }// partial class
    partial class Product
    {
        //конструкторы
        public Product(string nameP)
        {
            name = nameP;
            ID = name.GetHashCode(); //ID - равно некоторому уникальному номеру(хэшу)
            upd = "000";
            maker = "undefind";
            price = 0;
            shelfLife = "undefind";
        }
        public Product(int priceP, string makerP, string shelfLifeP)// с параметрами
        {
            name = "undefined";
            ID = name.GetHashCode();
            upd = "000";
            maker = makerP;
            price = priceP;
            shelfLife = shelfLifeP;
        }
        public Product(string nameP, string makerP, string shelfLifeP)
        {
            name = nameP;
            ID = name.GetHashCode();
            upd = "000";
            maker = makerP;
            price = 0;
            shelfLife = shelfLifeP;
        }

        static Product()//статический
        {
            Console.WriteLine("New product was added");
        }

        //закрытый конструктор не допускает создания объекта
        private Product() //закрытый
        {
            name = "Closed";
            ID = name.GetHashCode();
            upd = "Сlosed";
            maker = "Сlosed";
            price = 999;
            shelfLife = "Сlosed";
        }
        /////////////////////////////////////////
    }


    class Program
    {
        static void Main(string[] args)//точка входа в программу
        {
            Product[] store = new Product[4];//создаем массив продуктов - "мгазин"
            store[0] = new Product("Apple soap");//первый продуктом в массиве будет мыло и тд
            store[1] = new Product("Glam Look", "Luxvisage", "untill 2021");
            store[2] = new Product("Golden apple", "Germany", "1 month");
            store[3] = new Product(2, "Germany", "1 month");

            Console.WriteLine(store[0].ToString());
            Console.WriteLine(store[0].price.Equals(8) + "\n");


            /*Вывести:
            a) список товаров для заданного наименования;
            b) список товаров для заданного наименования, цена которых
            не превосходит заданную; */
            Console.WriteLine("Enter the element you want to find");
            string product = Console.ReadLine();
            var j = 0;///анонимнй тип
            for (int i = 0; i < store.Length; i++)
            {
                if (store[i].name == product)
                {
                    Console.WriteLine("There's the element: " + store[i].name +
                        "! It's price: " + store[i].price);
                    j++;
                }
            }
            if (j == 0) Console.WriteLine("There's no such element");
            ///////////////
            ///
            Console.WriteLine("Enter the element you want to find");
            string product1 = Console.ReadLine();
            Console.WriteLine("Enter the top price of element you want to find");
            int price = Convert.ToInt32(Console.ReadLine());

            var l = 0;
            for (int i = 0; i < store.Length; i++)
            {
                if (store[i].name == product1 && store[i].price <= price)
                {
                    Console.WriteLine("There's the element: " + store[i].name +
                        "! It's price: " + store[i].price);
                    l++;
                }
            }
            if (l == 0) Console.WriteLine("There's no such element");
            ///////////////
            ///
            int sum = 0;
            for (int i = 0; i < store.Length; i++)
            {
                sum += store[i].price * 9;
            }
            Console.WriteLine("\nThe whole sum is " + sum);


            Console.ReadKey();
        }
    }
}
