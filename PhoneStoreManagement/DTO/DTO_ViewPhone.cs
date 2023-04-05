using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneStoreManagement.DTO
{
    class DTO_ViewPhone
    {
        public int IDPhone { get; set; }
        public string NamePhone { get; set; }
        public int RAM { get; set; }
        public int ROM { get; set; }
        public string ScreenSize { get; set; }
        public int Battery { get; set; }
        public int Camera { get; set; }
        public int Price { get; set; }
        public string Operating { get; set; }
        public string Brand { get; set; }
        public Image Picture { get; set; }
    }
}
