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

            ClothesType tshirt = new ClothesType("T-shirt", "T-shirt", Resource.Drawable.tshirt, 1);
            ClothesType hoodie = new ClothesType("Hoodie", "худи", Resource.Drawable.hoodie, 2);
            ClothesType cap = new ClothesType("Cap", "кепки", Resource.Drawable.cap, 3);
            ClothesType socs = new ClothesType("Socs", "носки", Resource.Drawable.socs, 4);

            clothesTypes.Add(tshirt);
            clothesTypes.Add(hoodie);
            clothesTypes.Add(cap);
            clothesTypes.Add(socs);

            listView.Adapter = new ClothesAdapter(this, clothesTypes);
            listView.ItemClick += ListView_ItemClick;

        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Intent intent = new Intent(this, typeof(ActivityTwo));
            StartActivity(intent);


            //var a = listView.GetItemAtPosition(e.Position);
            //if (e.Position == tshirt.id)
            //{
            //    Intent intent = new Intent(this, typeof(ActivityThree));
            //    StartActivity(intent);
            //}
            //else if (e.Position == hoodie.id)
            //{
            //    Intent intent = new Intent(this, typeof(ActivityTwo));
            //    StartActivity(intent);
            //}
            //else if (e.Position == cap.id)
            //{
            //    Intent intent = new Intent(this, typeof(ActivityThree));
            //    StartActivity(intent);
            //}
            //else if (e.Position == socs.id)
            //{
            //    Intent intent = new Intent(this, typeof(ActivityThree));
            //    StartActivity(intent);
            //}
        }
    }

    public class ClothesAdapter : BaseAdapter<ClothesType>
    {
        List<ClothesType> items;
        Activity context;
        public ClothesAdapter(Activity context, List<ClothesType> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }
        public override long GetItemId(int position)
        {
            return position;
        }
        public override ClothesType this[int position]
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
                view = context.LayoutInflater.Inflate(Resource.Layout.list_item, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.Code;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(item.ImageResourceId);

            return view;

        }
    }

    public class ClothesType
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int ImageResourceId { get; set; }
        public int id { get; set; }


        public ClothesType(string Name, string Code, int ImageResourceId, int id)
        {
            this.Name = Name;
            this.Code = Code;
            this.ImageResourceId = ImageResourceId;
            this.id = id;
        }

    }
}