using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using SharedProject;

namespace XamarinAndroid
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button button1;

        private static readonly HttpClient client = new HttpClient();

        private readonly string helloUrl = "http://192.168.0.188:5000/api/values/";


        private Task AlertDialog(string v1, string v2, string v)
        {
            throw new NotImplementedException();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            button1 = FindViewById<Button>(Resource.Id.button1);

            button1.Click += button1_click;


        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private async void button1_click(object sender, EventArgs e)
        {

            JavaDictionary<string, string> dict = new JavaDictionary<string, string>()
            {
                { "s", "Vasya"}
            };

            FormUrlEncodedContent form = new FormUrlEncodedContent(dict);

            var values = new Dictionary<string, string>{
              { "productId", "1" },
              { "productKey", "Abc6666" },
              { "userName", "OPPO" },
            };

            var json = JsonConvert.SerializeObject(values, Formatting.Indented);

            var stringContent = new StringContent(json);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.PostAsync(helloUrl, stringContent);

            string result = await response.Content.ReadAsStringAsync();

            Utilits b = new Utilits();

            string a = b.Name();  


            Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
            Android.App.AlertDialog alert = dialog.Create();
            alert.SetTitle("Test");
            alert.SetMessage("Привет, " + a);
            alert.SetButton("ОК", (c, ev) =>
            {
                // Задача нажатия кнопки ОК  
            });
            alert.Show();



        }


    }
}
