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
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace XamarinAndroid.Resources.layout
{
    [Activity(Label = "ActivityTwo")]
    public class ActivityTwo : Activity
    {

        SharedData<int> shared = new SharedData<int>();
        ListView listView;
        Button button;

        private static readonly HttpClient client = new HttpClient();

        private readonly string ClothesTypeUrl = "http://192.168.0.188:5000/api/values/tshirt";
        private readonly string AddUrl = "http://192.168.0.188:5000/api/values";

        protected override async void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_two);
            listView = FindViewById<ListView>(Resource.Id.listView2);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(ClothesTypeUrl);

            string result = await response.Content.ReadAsStringAsync();

            List<Clothes<int>> _clothes = JsonConvert.DeserializeObject<List<Clothes<int>>>(result);

            foreach (Clothes<int> i1 in _clothes)
            {
                shared.AddClothesForList(i1.NameClothes, Resource.Drawable.tshirt, 7, i1.id);
            }

            listView.Adapter = new ClothesAdapter(this, shared.clothes);

            button = FindViewById<Button>(Resource.Id.button1);
            button.Click += Button_Click;

        }

        private async void Button_Click(object sender, EventArgs e)
        {
            var cl = new Clothes<int>
            {
                idType = 7,
                NameClothes = "T-shirt",
                bgImage = 0
            };

            var json = JsonConvert.SerializeObject(cl, Formatting.Indented);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, AddUrl);
            request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            string _result = await request.Content.ReadAsStringAsync();

            HttpResponseMessage _response = await client.PostAsync(AddUrl, stringContent);

            shared.clothes.Add(new Clothes<int>(cl.NameClothes, Resource.Drawable.tshirt, 7, cl.id));
            listView.InvalidateViews();
        }
    }
}