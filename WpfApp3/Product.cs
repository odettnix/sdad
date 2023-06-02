using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
    class Product
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacture { get; set; }

        private BitmapImage _ImageData { get; set; }
        public BitmapImage ImageData { get {  return _ImageData; } set { this._ImageData = value; } }

        public int Value { get; set; }
        public decimal Cost { get; set; }
        public double Discont { get; set; }

    }
}
