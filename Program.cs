
//  T7

/* محمد یاسین ولی پور */

/* mohamad yasin valipor */

using Digikala1.Model;
using Digikala1.Operations;

string address = @"DataSet\orders.csv";
DigikalaContext context = new DigikalaContext(address);
DigikalaOperation op = new DigikalaOperation(context.digikalas);
LockKeyboard lk = new LockKeyboard();
Digikala_all_city.Class2 op2 = new Digikala_all_city.Class2();



Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("HELLO\nThis is an Application For DigiKala\nThat Gives You Information About The Purchase Of Each \"Item\",\"Customer\"\nby \'Year\' and \'Month\' in All Cities ==>");
Console.ResetColor();

Console.WriteLine("\n-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-\n");

Console.ForegroundColor = ConsoleColor.Magenta;
Console.WriteLine("You can see the sales amount of each item below\nto choose them , enter the desired number..!!\n ");
Console.ResetColor();





bool cnt = true;
do
{
    Console.WriteLine("1)City\n2)Information Of Customer\n3)Information Of Item\n4)Information Of Oreder\n5)Year\n6)Month\n");

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("I Choose : ");
    Console.ResetColor();


    lk.LockKeyboradFirst();
    string request = Console.ReadLine();
    Console.WriteLine("\n-----------------");

    switch (request)
    {

        case "1":
            op2.Creat_file_All_city(); ////

            Console.WriteLine("\n-------------------------------------------------------------------");
            break;


        case "2":

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nYour ID Customer is:  ");
            Console.ResetColor();


            lk.LockKeyborad_ID();
            int ID_CUSTOMER = Convert.ToInt32(Console.ReadLine());

            foreach (var item in op.SearchByUser1(ID_CUSTOMER))
            {
                Console.WriteLine("\n{0} {1} {2} {3} {4} {5}",
                item.ID_Order,
                item.ID_Item,
                item.DateTime_CartFinalize,
                item.Amount_Gross_Order,
                item.city_name_fa,
                item.Quantity_item);

                Console.WriteLine("\n-------------------------------------------------------------------");
            }
            break;


        case "3":

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nYour ID Item is:  ");
            Console.ResetColor();


            lk.LockKeyborad_ID();
            int ID_Item = Convert.ToInt32(Console.ReadLine());

            foreach (var item in op.SearchByUser3(ID_Item))
            {
                Console.WriteLine("\n{0} {1} {2} {3} {4} {5}",
                item.ID_Order,
                item.ID_Customer,
                item.DateTime_CartFinalize,
                item.Amount_Gross_Order,
                item.city_name_fa,
                item.Quantity_item);

                Console.WriteLine("\n-------------------------------------------------------------------");
            }
            break;


        case "4":

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nYour ID Order is:  ");
            Console.ResetColor();


            lk.LockKeyborad_ID();
            int ID_Order = Convert.ToInt32(Console.ReadLine());

            foreach (var item in op.SearchByUser2(ID_Order))
            {
                Console.WriteLine("\n{0} {1} {2} {3} {4} {5}",
                item.ID_Customer,
                item.ID_Item,
                item.DateTime_CartFinalize,
                item.Amount_Gross_Order,
                item.city_name_fa,
                item.Quantity_item);

                Console.WriteLine("\n-------------------------------------------------------------------");
            }
            break;


        case "5":

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("if you see all \"Sales\" By Year press \'A\'\nIf you want see \"sum Sales By Year\" press \'B\'");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("You choose:  ");
            Console.ResetColor();


            op2.Sell_sum_by_Year();
            Console.WriteLine("\n-------------------------------------------------------------------");
            break;


        case "6":

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("if you see all \"Sales\" By Month press \'A\'\nIf you want see \"sum Sales By Month\" press \'B\'");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hint : if your Month is in range (1,9) , must type a 0 behind the number ");
            Console.ResetColor();


            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("You choose:  ");
            Console.ResetColor();


            op2.Sell_sum_by_Month();
            Console.WriteLine("\n-------------------------------------------------------------------");
            break;
    }

} while (lk.LockKeyboradYN().ToLower() == "y");

Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine("Thanks for Use This program");
Console.ResetColor();

















