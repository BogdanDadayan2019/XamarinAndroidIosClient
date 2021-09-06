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
    [Activity(Label = "ActivityFour")]
    public class ActivityFour : Activity
    {
        SharedData<int> shared = new SharedData<int>();
        ListView listView;
        Button button;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_four);
            listView = FindViewById<ListView>(Resource.Id.listView4);

            shared.AddClothesForList("Cap 1", Resource.Drawable.cap);
            shared.AddClothesForList("Cap 2", Resource.Drawable.cap);
            shared.AddClothesForList("Cap 3", Resource.Drawable.cap);
            shared.AddClothesForList("Cap 4", Resource.Drawable.cap);

            listView.Adapter = new ClothesAdapter(this, shared.clothes);
            button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            shared.AddClothesForList("Basic", Resource.Drawable.cap);
            listView.InvalidateViews();
        }

    }
}