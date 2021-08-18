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
    [Activity(Label = "ActivityFour")]
    public class ActivityFour : Activity
    {
        List<Clothes> clothes = new List<Clothes>();
        ListView listView;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_four);
            listView = FindViewById<ListView>(Resource.Id.listView4);

            clothes.Add(new Clothes("Cap 1", Resource.Drawable.cap));
            clothes.Add(new Clothes("Cap 2", Resource.Drawable.cap));
            clothes.Add(new Clothes("Cap 3", Resource.Drawable.cap));
            clothes.Add(new Clothes("Cap 4", Resource.Drawable.cap));

            listView.Adapter = new ClothesAdapter(this, clothes);
            button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            clothes.Add(new Clothes("Basic", Resource.Drawable.cap));
            listView.InvalidateViews();
        }

    }
}