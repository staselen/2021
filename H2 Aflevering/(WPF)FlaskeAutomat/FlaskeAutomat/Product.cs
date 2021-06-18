using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlaskeAutomat
{
    //Class of product
    public class Product
    {
        public string Name { get; set; }
        public int IdentificationNumber { get; set; }
        public Image Image { get; set; }
        public string State { get; set; }
        public Product(string name, int identificationNumber, Image image)
        {
            Name = name;
            IdentificationNumber = identificationNumber;
            Image = image;
        }

        public override string ToString()
        {
            return "Name : " + Name + "\n" + "IdentificationNumber : " + IdentificationNumber;
        }
    }


}
