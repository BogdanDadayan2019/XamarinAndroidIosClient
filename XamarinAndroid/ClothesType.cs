using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XamarinAndroid
{
    public class ClothesType
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int ImageResourceId { get; set; }

        public ClothesType(string Name, string Code, int ImageResourceId)
        {
            this.Name = Name;
            this.Code = Code;
            this.ImageResourceId = ImageResourceId;
        }
    }
}