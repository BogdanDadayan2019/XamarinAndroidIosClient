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
using System.Net.Http.Headers;
using System.Net.Http;
using Newtonsoft.Json;

namespace XamarinAndroid
{
    public class ClothesAdapter : BaseAdapter<Clothes<int>>
    {

        List<Clothes<int>> items;
        Activity context;
        Button button1;
        Button button2;

        private static readonly HttpClient client = new HttpClient();
        private readonly string AllClothesUrl = "http://192.168.0.188:5000/api/values/allclothes/";
        private readonly string DeleteClothesUrl = "http://192.168.0.188:5000/api/values/deleteclothes";
        private readonly string ChangeClothesUrl = "http://192.168.0.188:5000/api/values/changeclothes";


        public ClothesAdapter(Activity context, List<Clothes<int>> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override Clothes<int> this[int position]
        {
            get { return items[position]; }
        }
        public override int Count
        {
            get { return items.Count; }
        }
        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];

            View view = convertView;
            if (view == null)
                view = context.LayoutInflater.Inflate(Resource.Layout.list_clothes_item, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.NameClothes;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(item.bgImage);

            button1 = view.FindViewById<Button>(Resource.Id.buttonChanged);
            button1.Click += Button1_Click;


            button2 = view.FindViewById<Button>(Resource.Id.buttonDelete);
            button2.Click += Button_Click2;

            async void Button_Click2(object sender, EventArgs e)
            {

                var json = JsonConvert.SerializeObject(item, Formatting.Indented);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, DeleteClothesUrl);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                string _result = await request.Content.ReadAsStringAsync();

                HttpResponseMessage _response = await client.PostAsync(DeleteClothesUrl, stringContent);


                items.Remove(item);
                NotifyDataSetChanged();
            }

             async void Button1_Click(object sender, EventArgs e)
            {

                LayoutInflater layoutInflater = LayoutInflater.From(Application.Context);
                View view = layoutInflater.Inflate(Resource.Layout.update_clothes_layout, null);


                AlertDialog.Builder dialog = new AlertDialog.Builder(context);
                EditText editText = view.FindViewById<EditText>(Resource.Id.editText1);
                dialog.SetView(view);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Change name");

               

                editText.Text = item.NameClothes;

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(AllClothesUrl);

                string result = await response.Content.ReadAsStringAsync();

                List<Clothes<int>> _clothes = JsonConvert.DeserializeObject<List<Clothes<int>>>(result);


                alert.SetButton("Ok", async (s, e) =>
                {
                    if (editText.Text.Equals(""))
                    {
                        item.NameClothes = item.NameClothes;

                    }
                    else
                    {

                        item.NameClothes = editText.Text;

                        
                        var json = JsonConvert.SerializeObject(item, Formatting.Indented);
                        var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, ChangeClothesUrl);
                        request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                        string _result = await request.Content.ReadAsStringAsync();

                        HttpResponseMessage _response = await client.PostAsync(ChangeClothesUrl, stringContent);
                    }
                });

                alert.Show();
            }

            return view;
        }

    }
}