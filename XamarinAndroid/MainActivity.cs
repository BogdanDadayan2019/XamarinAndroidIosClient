using Android.App;
using Android.Widget;
using Android.Views;
using Android.OS;
using System.Collections.Generic;
using XamarinAndroid;
using Android.Content;
using XamarinAndroid.Resources.layout;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;
using Android.Runtime;

namespace DesignerWalkthrough
{
    [Activity(Label = "Wardrobe", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AndroidX.AppCompat.App.AppCompatActivity
    {
        List<ClothesType> clothesTypes = new List<ClothesType>();
        ListView listView;
        
        private static readonly HttpClient client = new HttpClient();

        private readonly string ClothesTypeUrl = "http://192.168.0.188:5000/api/values/";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            listView = FindViewById<ListView>(Resource.Id.listView1);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(ClothesTypeUrl);

            string result = await response.Content.ReadAsStringAsync();

            List<ClothesType> clothesType = JsonConvert.DeserializeObject<List<ClothesType>>(result);

            clothesTypes.Add(new ClothesType(clothesType[0].NameType, "футболки", Resource.Drawable.tshirt));
            clothesTypes.Add(new ClothesType(clothesType[1].NameType, "худи", Resource.Drawable.hoodie));
            clothesTypes.Add(new ClothesType(clothesType[2].NameType, "кепки", Resource.Drawable.cap));
            clothesTypes.Add(new ClothesType(clothesType[3].NameType, "носки", Resource.Drawable.socs));
       
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