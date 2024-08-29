using System;
namespace Digital_supermarket
{
    internal class Program
    {
        static void Main()
        {
            Console.WriteLine("                  OUR PRODUCTS\n");
            //عرض المنتجات و سعرها و وحدتها بشكل منظم
            string[,] goods = new string[13, 4]
            {
               {"Name      ","Price"," Unit  ","Inventory"},
               {"Toast     "," 95","$ for One","20"},
               {"Jam       "," 40","$ for Kg ","20"},
               {"Egg       "," 05","$ for One","20"},
               {"Chocolate ","100","$ for Kg ","20"},
               {"juice     "," 10","$ for L  ","20"},
               {"Cheese    "," 55","$ for Kg ","20"},
               {"Milk      "," 25","$ for L  ","20"},
               {"Cinnamon  "," 90","$ for Kg ","20"},
               {"Pepsi     "," 15","$ for L  ","20"},
               {"Banana    "," 20","$ for Kg ","20"},
               {"Apple     "," 60","$ for Kg ","20"},
               {"Mango     "," 40","$ for Kg ","20"},
            };
            for (int i = 0; i < 13; i++)
            {
                if (i >= 0 && i <= 9) Console.Write($"Product 0{i} : ");
                else Console.Write($"Product {i} : ");

                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{goods[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            //تنيه المستخدم للخصم
            Console.WriteLine("If you buy for 300 $ or more, you will get 10 % discount\n");
            //Console.WriteLine($"Number of rows = {goods.GetLength(0)}");
            //Console.WriteLine($"Number of columns = {goods.GetLength(0)}");
            float price = 0, discount = 0;
        start:
            Console.Write("Enter product number : ");
            int product_num = Convert.ToInt32(Console.ReadLine());
            //استقبال رقم يدل على المنتج المطلوب
            if (product_num <= 0 || product_num > goods.GetLength(0) - 1)
            { Console.WriteLine("Stupid !"); goto start; }
            //عرض معلومات المنتج المطلوب
            Console.WriteLine($"Product name is {goods[product_num, 0]}");
            Console.WriteLine($"Product price is {goods[product_num, 1]} {goods[product_num, 2]}");
            //استقبال قيمة الكمية المطلوبة من هذا المنتج بالموجب
            Console.WriteLine("How much amount are you need ?");
        start2:
            Console.Write("Enter amount : ");
            float amount1 = Math.Abs(Convert.ToSingle(Console.ReadLine()));
            //التحقق من الكيمة المتوفرة فى المخزن
            float exist = Convert.ToSingle(goods[product_num, 3]);
            //إذا نفذ هذا المنتج من المخزن
            if (exist == 0)
            {
                Console.WriteLine("This product is currently not available .");
            }
            //المنتج موجود و لكن بكمية أقل من الكمية المطلوبة
            if (amount1 > exist && exist > 0)
            {
                Console.WriteLine($"\nSorry ! We have not enough to sail you . We only have ({exist})");
                Console.WriteLine("If you need to buy some of this amount enter 1 or 2 to finish");
                Console.Write("Enter number : ");
                int ans1 = Convert.ToInt32(Console.ReadLine());
                if (ans1 == 1)
                {
                    goto start2;
                }
            }
            //إذا كانت الكمية المطلوبة متوفرة
            if (exist >= amount1)
            {
                exist -= amount1;
                goods[product_num, 3] = Convert.ToString(exist);//هنا الفكرة
                int price1 = Convert.ToInt32(goods[product_num, 1]);
                float price2 = amount1 * price1;
                Console.WriteLine($"This cost {price2} $");
                price += price2;
            }
            //عرض سؤال إذا كان يريد شراء منتج أخر
            Console.Write("\nAre you need to buy another product ?\n");
            Console.Write("Enter 1 to continue or 2 to finish\nEnter number : ");
            int ans = Convert.ToInt32(Console.ReadLine());
            if (ans == 1) { Console.WriteLine(); goto start; }
            else
            {
                //حساب قيمة الخصم على التكلفة النهائية للمنتجات
                if (price >= 300)
                {
                    discount = price * 10 / 100;
                    price -= discount;
                }
                //طباعة التكلفة النهائية بعد الخصم
                if (price >= 300) { Console.WriteLine($"\nYou have 10 % discount = {discount} $"); }
                Console.WriteLine($"\nTotal cost = {price} $");
            }
        }
    }
}