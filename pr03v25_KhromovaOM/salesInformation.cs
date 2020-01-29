using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr03v25_KhromovaOM
{
    public class SalesInformation
    {
        private static List<PurchaseInformation> sales;

        public SalesInformation()
        {
            sales = new List<PurchaseInformation>();
        }

        public PurchaseInformation PurchaseInformation
        {
            get => default(PurchaseInformation);
            set
            {
            }
        }

        public void AddPurchase
        (string _fabricname, string _factory, Fabric _typeoffabric, Colors _color, int _pricepermeter, double _meters, Payment _typeofpayment)
        {
            sales.Add(new PurchaseInformation(_fabricname, _factory, _typeoffabric, _color, _pricepermeter, _meters, _typeofpayment));
        }

        public void DeleteAll()
        {
            sales.Clear();
        }

        public bool DeletePurchase(int index)
        {
            if (index > sales.Count)
                return false;
            sales.RemoveAt(index - 1);
            return true;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            int i = 0;
            foreach (PurchaseInformation prod in sales)
            {
                i++;
                builder.Append("№").Append(i).Append(" ");
                builder.Append(prod.ToString()).AppendLine();
            }
            return builder.ToString();
        }

        public double TotalPrice()
        {
            double totalPrice = 0;

            foreach (PurchaseInformation prod in sales)
            {
                totalPrice += prod.PricePereMeter * prod.Meters;

            }
            return totalPrice;
        }

        public string Total()
        {
            StringBuilder builder2 = new StringBuilder();
            if (sales.Count != 0)
            {
                builder2.AppendLine("===============================");
                builder2.AppendFormat("ИТОГО: Всего {0} покупок на сумму {1} руб.", sales.Count, Convert.ToDouble(TotalPrice()));
                builder2.AppendLine();
                builder2.AppendFormat("Средняя стоимость товаров: {0} руб.", Convert.ToDouble(TotalPrice() / sales.Count));
                builder2.AppendLine();
                builder2.AppendFormat("Общее количество проданных метров {0}м", Convert.ToDouble(TotalMeters()));
            }
            return builder2.ToString();
        }

        public double TotalMeters()
        {
            double totalMeters = 0;

            foreach (PurchaseInformation prod in sales)
            {
                totalMeters += prod.Meters;
            }

            return totalMeters;
        }
    }
}
