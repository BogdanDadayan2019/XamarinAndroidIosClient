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
       
            listView.Adapter = new ClothesAdapter(this, clothesTypes);

            listView.ItemClick += ListView_ItemClick;
        }

        private void ListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var a = listView.GetItemAtPosition(e.Position);

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


        public ClothesType(string Name, string Code, int ImageResourceId)
        {
            this.Name = Name;
            this.Code = Code;
            this.ImageResourceId = ImageResourceId;
        }

    }
}