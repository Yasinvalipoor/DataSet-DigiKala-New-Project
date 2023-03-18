using Digikala1.Model;
using System.Net;
using System;

namespace Digikala1.Operations
{
    class DigikalaOperation
    {//لیستی درست کردیم از کلاس دیجیکالا=============== گت و ست
        List<Digikala> digikalas;
        public DigikalaOperation(List<Digikala> digikalas)
        {
            this.digikalas = digikalas;
        }

        /////////////  SearchBy++UserID_Customer  ////////////////

        public List<Digikala> SearchByUser1(int ID_Customer)
        {
            return digikalas
                 .Where(x => x.ID_Customer == ID_Customer)
                 .ToList();
        }

        /////////////  SearchBy++UserID_Order  ////////////////

        public List<Digikala> SearchByUser2(int ID_Order)
        {
            return digikalas
                .Where(x => x.ID_Order == ID_Order)
                .ToList();
        }

        /////////////  SearchBy++UserID_Order  ////////////////

        public List<Digikala> SearchByUser3(int ID_Item)
        {
            return digikalas
                .Where(x => x.ID_Item == ID_Item)
                .ToList();
        }

        /////////////  YEAR   ////////////////

        public List<int> AllSalesByYear(int year)
        {
            return digikalas.
             Where(x => x.DateTime_CartFinalize.Year == year)
             .Select(x => x.Amount_Gross_Order)
             .ToList();
        }
        public long SumSalesByYear(int year)
        {
            List<int> sales = AllSalesByYear(year);
            long total = 0;

            Parallel.ForEach(sales, sale =>
            {
                total += sale;

            });

            return total;
        }


        /////////////  MONTH   ////////////////


        public List<int> AllSalesByMonth(int month)
        {
            return digikalas.
             Where(x => x.DateTime_CartFinalize.Month == month)
             .Select(x => x.Amount_Gross_Order)
             .ToList();
        }
        public long SumSalesByMonth(int month)
        {
            List<int> sales = AllSalesByMonth(month);
            long total = 0;

            Parallel.ForEach(sales, sale =>
            {
                total += sale;

            });

            return total;
        }

        /////////////  output   //////////////


    }
}
