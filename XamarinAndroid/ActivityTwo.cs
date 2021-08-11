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
    [Activity(Label = "ActivityTwo")]
    public class ActivityTwo : Activity
    {
        List<Clothes> clothes = new List<Clothes>();
        ListView listView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_two);
            listView = FindViewById<ListView>(Resource.Id.listView2);

            clothes.Add(new Clothes("T-shirt 1", Resource.Drawable.tshirt));
            clothes.Add(new Clothes("T-shirt 2", Resource.Drawable.tshirt));
            clothes.Add(new Clothes("T-shirt 3", Resource.Drawable.tshirt));
            clothes.Add(new Clothes("T-shirt 4", Resource.Drawable.tshirt));

            listView.Adapter = new ClothesAdapter(this, clothes);

        }

        public class ClothesAdapter : BaseAdapter<Clothes>
        {
            List<Clothes> items;
            Activity context;
            public ClothesAdapter(Activity context, List<Clothes> items)
                : base()
            {
                this.context = context;
                this.items = items;
            }
            public override long GetItemId(int position)
            {
                return position;
            }
            public override Clothes this[int position]
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
                view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Name;
                view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(item.ImageResourceId);

                return view;

            }
        }
    }
    
}