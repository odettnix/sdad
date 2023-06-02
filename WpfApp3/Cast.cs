using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace WpfApp3
{
    class Cast
    {
        private BitmapImage _ImageData { get; set; }
        public BitmapImage ImageData { get { return _ImageData; } set { this._ImageData = value; } }

        public int idUser { get; set; }
        public int idCast { get; set; }
        public int idProduct { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Manufacture { get; set; }
        public int Count { get; set; }
        public decimal EndCost { get; set; }
        public decimal SaleValue { get; set; }
        public int Status { get; set; }
    }
}
