using Digikala1.Model;
using Digikala1.Operations;
using System.Text.RegularExpressions;

namespace Digikala_all_city;
internal class Class2
{


    public void Creat_file_All_city()
    {
        string address = @"DataSet\orders.csv";

        string line;

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n Please wait\r\n This process takes time\r\n Thank you for your patience");
        Console.ResetColor();


        List<string> citys = new List<string>();

        using (StreamReader reader = new StreamReader(address))
        {
            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                citys.Add(Regex.Replace(line, @"(\d|\.|,|:|-| )+", ""));
            }
        }
        var nonduplicatecitys = citys.Distinct();

        Parallel.ForEach(nonduplicatecitys, city =>
        {
            using (StreamWriter writer = new StreamWriter(@"all_citys\" + city + ".csv"))
            {

                using (StreamReader reader2 = new StreamReader(address))
                {
                    while (!reader2.EndOfStream)
                    {
                        string line2 = reader2.ReadLine();

                        if (line2.Contains(city))
                        {
                            writer.WriteLine(line2);
                        }
                    }
                }
            }
        });
    }

    public void Sell_sum_by_Month()

    {

        string address = @"DataSet\orders.csv";
        DigikalaContext context = new DigikalaContext(address);
        DigikalaOperation op = new DigikalaOperation(context.digikalas);

        string cont2 = Console.ReadLine();


        switch (cont2.ToUpper())
        {
            case "A":

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\nyour Month is: ");
                Console.ResetColor();


                int Month = Convert.ToInt32(Console.ReadLine());
                foreach (var item in op.AllSalesByMonth(Month))
                {
                    Console.WriteLine(item);
                    Console.WriteLine("\n-----------------");
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("IF you want creat a file and paste information in it press F");
                Console.ResetColor();

                string file = Console.ReadLine();

                if (file.ToUpper() == "F")
                {
                    using (StreamWriter write = new StreamWriter(@"all_Date_Month\" + Month + ".csv"))
                    {
                        using (StreamReader read = new StreamReader(address))
                        {
                            while (!read.EndOfStream)
                            {
                                string lines = read.ReadLine();
                                string Month2 = Month + "-";

                                if (lines.Contains(Convert.ToString(Month2)))
                                {
                                    write.WriteLine(lines);
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"done\ncreat a new file named {file} in deboug directory");
                            Console.ResetColor();

                        }

                    }


                }
                break;

            case "B":
                if (cont2.ToUpper() == "B")
                {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("\nyour year is: ");
                    Console.ResetColor();

                    int year_sum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(op.SumSalesByYear(year_sum));

                }
                break;
        }
       
    }

    public void Sell_sum_by_Year()
    {
        string address = @"DataSet\orders.csv";
        DigikalaContext context = new DigikalaContext(address);
        DigikalaOperation op = new DigikalaOperation(context.digikalas);

        string cont = Console.ReadLine();


        switch (cont.ToUpper())
        {
            case "A":
                Console.Write("\nyour year is: ");
                int year = Convert.ToInt32(Console.ReadLine());
                foreach (var item in op.AllSalesByYear(year))
                {
                    Console.WriteLine(item);
                    Console.WriteLine("\n-----------------");
                }
                Console.WriteLine("IF you want creat a file and paste information in it press F");
                string file = Console.ReadLine();

                if (file.ToUpper() == "F")
                {
                    using (StreamWriter write = new StreamWriter(@"all_Date_Year\" + year + ".csv"))
                    {
                        using (StreamReader read = new StreamReader(address))
                        {
                            while (!read.EndOfStream)
                            {
                                string lines = read.ReadLine();
                                string year2 = year + "-";

                                if (lines.Contains(Convert.ToString(year2)))
                                {
                                    write.WriteLine(lines);
                                }
                            }
                            Console.WriteLine($"done\ncreat a new file named {file} in deboug directory");
                        }

                    }


                }
                break;

            case "B":
                if (cont.ToUpper() == "B")
                {
                    Console.Write("\nyour year is: ");
                    int year_sum = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(op.SumSalesByYear(year_sum));

                }
                break;
        }
    }


}

