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
    [Activity(Label = "ActivityThree")]
    public class ActivityThree : Activity
    {
        List<Clothes> clothes = new List<Clothes>();
        ListView listView;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_three);
            listView = FindViewById<ListView>(Resource.Id.listView3);

            clothes.Add(new Clothes("Hoodie 1", Resource.Drawable.hoodie));
            clothes.Add(new Clothes("Hoodie 2", Resource.Drawable.hoodie));
            clothes.Add(new Clothes("Hoodie 3", Resource.Drawable.hoodie));
            clothes.Add(new Clothes("Hoodie 4", Resource.Drawable.hoodie));

            listView.Adapter = new ClothesAdapter(this, clothes);

            button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            clothes.Add(new Clothes("Basic", Resource.Drawable.hoodie));
            listView.InvalidateViews();
        }

    }
}