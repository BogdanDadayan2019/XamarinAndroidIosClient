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
using SharedProject;

namespace XamarinAndroid.Resources.layout
{
    [Activity(Label = "ActivityFive")]
    public class ActivityFive : Activity
    {
        SharedData<int> shared = new SharedData<int>();
        ListView listView;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_five);
            listView = FindViewById<ListView>(Resource.Id.listView5);

            shared.AddClothesForList("Socs 1", Resource.Drawable.socs);
            shared.AddClothesForList("Socs 2", Resource.Drawable.socs);
            shared.AddClothesForList("Socs 3", Resource.Drawable.socs);
            shared.AddClothesForList("Socs 4", Resource.Drawable.socs);

            listView.Adapter = new ClothesAdapter(this, shared.clothes);
            button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;

        }

        private void Button_Click(object sender, EventArgs e)
        {
            shared.AddClothesForList("Basic", Resource.Drawable.socs);
            listView.InvalidateViews();
        }

    }
}
