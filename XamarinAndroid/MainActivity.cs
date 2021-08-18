using Android.App;
using Android.Widget;
using Android.Views;
using Android.OS;
using System.Collections.Generic;
using XamarinAndroid;
using Android.Content;
using XamarinAndroid.Resources.layout;

namespace DesignerWalkthrough
{
    [Activity(Label = "Wardrobe", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AndroidX.AppCompat.App.AppCompatActivity
    {
        List<ClothesType> clothesTypes = new List<ClothesType>();
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            listView = FindViewById<ListView>(Resource.Id.listView1);

            clothesTypes.Add(new ClothesType("T-shirt", "футболки", Resource.Drawable.tshirt));
            clothesTypes.Add(new ClothesType("Hoodie", "худи", Resource.Drawable.hoodie));
            clothesTypes.Add(new ClothesType("Cap", "кепки", Resource.Drawable.cap));
            clothesTypes.Add(new ClothesType("Socs", "носки", Resource.Drawable.socs));
       
            listView.Adapter = new ClothesTypeAdapter(this, clothesTypes);

            listView.ItemClick += ListView_ItemClick;

        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            if (e.Position == 0)
            {
                Intent intent = new Intent(this, typeof(ActivityTwo));
                StartActivity(intent);
            } else if (e.Position == 1)
            {
                Intent intent = new Intent(this, typeof(ActivityThree));
                StartActivity(intent);
            }
            else if (e.Position == 2)
            {
                Intent intent = new Intent(this, typeof(ActivityFour));
                StartActivity(intent);
            }
            else if (e.Position == 3)
            {
                Intent intent = new Intent(this, typeof(ActivityFive));
                StartActivity(intent);
            }

        }
    }
}