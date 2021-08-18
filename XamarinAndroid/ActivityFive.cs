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
    [Activity(Label = "ActivityFive")]
    public class ActivityFive : Activity
    {
        List<Clothes> clothes = new List<Clothes>();
        ListView listView;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_five);
            listView = FindViewById<ListView>(Resource.Id.listView5);

            clothes.Add(new Clothes("Socs 1", Resource.Drawable.socs));
            clothes.Add(new Clothes("Socs 2", Resource.Drawable.socs));
            clothes.Add(new Clothes("Socs 3", Resource.Drawable.socs));
            clothes.Add(new Clothes("Socs 4", Resource.Drawable.socs));

            listView.Adapter = new ClothesAdapter(this, clothes);
            button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            clothes.Add(new Clothes("Basic", Resource.Drawable.socs));
            listView.InvalidateViews();
        }

    }
}
