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
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace XamarinAndroid.Resources.layout
{
    [Activity(Label = "ActivityFour")]
    public class ActivityFour : Activity
    {
        SharedData<int> shared = new SharedData<int>();
        ListView listView;
        Button button;

        private static readonly HttpClient client = new HttpClient();

        private readonly string ClothesTypeUrl = "http://192.168.0.188:5000/api/values/cap";

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_four);
            listView = FindViewById<ListView>(Resource.Id.listView4);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(ClothesTypeUrl);

            string result = await response.Content.ReadAsStringAsync();

            List<Clothes<int>> _clothes = JsonConvert.DeserializeObject<List<Clothes<int>>>(result);

            foreach (Clothes<int> i1 in _clothes)
            {
                shared.AddClothesForList(i1.NameClothes, Resource.Drawable.cap);
            }

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