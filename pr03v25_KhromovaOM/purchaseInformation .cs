using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr03v25_KhromovaOM
{
    public class PurchaseInformation
    {
        string fabricname;
        string factory;
        Fabric typeoffabric;
        Colors color;
        double pricepermeter;
        double meters;
        Payment typeofpayment;

        public string FabricName
        {
            get { return fabricname; }
            set
            {
                if (value == null) fabricname = "Без названия";
                else fabricname = value;
            }
        }
        public string Factory
        {
            get { return factory; }
            set
            {
                if (value == null) factory = "-Без названия-";
                else factory = value;
            }
        }
        public Fabric TypeOfFabric
        {
            get { return typeoffabric; }
            set
            {
                if (!Enum.IsDefined(typeof(Fabric), value))
                {
                    typeoffabric = 0;
                }
                else typeoffabric = value;
            }
        }
        public Colors Color
        {
            get { return color; }
            set
            {
                if (!Enum.IsDefined(typeof(Colors), value))
                {
                    color = 0;
                }
                else color = value;
            }
        }
        public double PricePereMeter
        {
            get { return pricepermeter; }
            set
            {   
                if (value < 0||value==0) pricepermeter = 0.0;
                else pricepermeter = value;
            }
        }
        public double Meters
        {
            get { return meters; }
            set
            {
                if (value < 0 || value == 0) meters = 0.0;
                else meters = value;
            }
        }
        public Payment TypeOfPayment
        {
            get { return typeofpayment; }
            set
            {
                if (!Enum.IsDefined(typeof(Payment), value))
                {
                    typeofpayment = 0;
                }
                else typeofpayment = value;
            }
        }

        public Fabric Fabric
        {
            get => default(Fabric);
            set
            {
            }
        }
        public Payment Payment
        {
            get => default(Payment);
            set
            {
            }
        }
        public Colors Colors
        {
            get => default(Colors);
            set
            {
            }
        }

        public override string ToString()
        {
            return String.Format("Наименование: {0} Производитель: {1} " +
                 "Тип ткани: {2} " +
                 "Цвет: {3} " +
                 "{5} м х {4} руб. = {7} руб. " +
                 "Тип оплаты: {6}", 
                 FabricName, Factory, TypeOfFabric, Color, PricePereMeter, Meters, TypeOfPayment, PricePereMeter*Meters);
        }

        public PurchaseInformation
            (string _fabricname, string _factory, Fabric _typeoffabric, 
            Colors _color, double _pricepermeter, double _meters, Payment _typeofpayment)
        {
            FabricName = _fabricname;
            Factory = _factory;
            TypeOfFabric = _typeoffabric;
            Color = _color;
            PricePereMeter = _pricepermeter;
            Meters = _meters;
            TypeOfPayment = _typeofpayment;
        }


    }
}
