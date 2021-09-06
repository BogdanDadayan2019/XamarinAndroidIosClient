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

namespace XamarinAndroid
{
    public class ClothesAdapter : BaseAdapter<Clothes<int>>
    {

        List<Clothes<int>> items;
        Activity context;
        Button button1;
        Button button2;

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
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Name;
            view.FindViewById<ImageView>(Resource.Id.imageView1).SetImageResource(item.bgImage);

            button1 = view.FindViewById<Button>(Resource.Id.buttonChanged);
            button1.Click += Button1_Click;


            button2 = view.FindViewById<Button>(Resource.Id.buttonDelete);
            button2.Click += Button_Click2;

            void Button_Click2(object sender, EventArgs e)
            {
                items.Remove(item);
                NotifyDataSetChanged();
            }

             void Button1_Click(object sender, EventArgs e)
            {

                LayoutInflater layoutInflater = LayoutInflater.From(Application.Context);
                View view = layoutInflater.Inflate(Resource.Layout.update_clothes_layout, null);


                AlertDialog.Builder dialog = new AlertDialog.Builder(context);
                EditText editText = view.FindViewById<EditText>(Resource.Id.editText1);
                dialog.SetView(view);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Taking Input");

                alert.SetButton("Ok", (s, e) =>
                {
                    if (editText.Text.Equals(""))
                    {
                        item.Name = item.Name;
                    }
                    else
                    {
                        item.Name = editText.Text;
                    }
                });

                alert.Show();

            }

            return view;

        }
        
    }
}