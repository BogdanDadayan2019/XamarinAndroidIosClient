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

namespace XamarinAndroid.Resources.layout
{
    [Activity(Label = "ActivityTwo")]
    public class ActivityTwo : Activity
    {
        List<Clothes> clothes = new List<Clothes>();
        ListView listView;
        Button button;


        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_two);
            listView = FindViewById<ListView>(Resource.Id.listView2);

            clothes.Add(new Clothes("T-shirt 1", Resource.Drawable.tshirt));
            clothes.Add(new Clothes("T-shirt 2", Resource.Drawable.tshirt));
            clothes.Add(new Clothes("T-shirt 3", Resource.Drawable.tshirt));
            clothes.Add(new Clothes("T-shirt 4", Resource.Drawable.tshirt));

            listView.Adapter = new ClothesAdapter(this, clothes);

            button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            clothes.Add(new Clothes("Basic", Resource.Drawable.tshirt));
            listView.InvalidateViews();

        }
    }
}