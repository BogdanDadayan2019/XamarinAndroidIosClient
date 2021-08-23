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
    public class Clothes
    {
        public string Name { get; set; }
        public int ImageResourceId { get; set; }

        public Clothes(string Name, int ImageResourceId)
        {
            this.Name = Name;
            this.ImageResourceId = ImageResourceId;
        }
    }
}