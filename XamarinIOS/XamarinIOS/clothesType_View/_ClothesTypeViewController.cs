using Foundation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using UIKit;

namespace XamarinIOS
{
    public partial class _ClothesTypeViewController : UIViewController
    {
        UIViewController tshirtViewController;
        UIViewController hoodieViewController;
        UIViewController socsViewController;
        UIViewController capViewController;

        private static readonly HttpClient client = new HttpClient();

        private readonly string ClothesTypeUrl = "http://192.168.0.188:5000/api/values/";

        public _ClothesTypeViewController(IntPtr handle) : base(handle)
        {
        }

        public override void AwakeFromNib()
        {
            // Called when loaded from xib or storyboard.
            this.Initialize();
        }

        public void Initialize()
        {
            tshirtViewController = Storyboard.InstantiateViewController("TshirtViewController") as _TshirtViewController;
            hoodieViewController = Storyboard.InstantiateViewController("HoodieViewController") as HoodieViewController;
            socsViewController = Storyboard.InstantiateViewController("SocsViewController") as SocsViewController;
            capViewController = Storyboard.InstantiateViewController("CapViewController_") as _CapViewController;
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync(ClothesTypeUrl);

            string result = await response.Content.ReadAsStringAsync();

            List<ClothesType> clothesType = JsonConvert.DeserializeObject<List<ClothesType>>(result);

            var clothesTypes = new List<ClothesType>
            {
                new ClothesType
                {
                    NameType = clothesType[0].NameType,
                    TranslateName = "футболки",
                    BdImage = UIImage.FromBundle("t-shirt")
                },
                new ClothesType
                {
                    NameType = clothesType[1].NameType,
                    TranslateName = "худи",
                    BdImage = UIImage.FromBundle("hoodie")
                },
                new ClothesType
                {
                    NameType = clothesType[2].NameType,
                    TranslateName = "кепки",
                    BdImage = UIImage.FromBundle("caps")
                },
                new ClothesType
                {
                    NameType = clothesType[3].NameType,
                    TranslateName = "носки",
                    BdImage = UIImage.FromBundle("socs")
                }
        };

            TshirtViewController.RowHeight = 60;

            TshirtViewController.ReloadData();

            TshirtViewController.Source = new ClothesTypeTVS(clothesTypes, NavigationController, tshirtViewController, hoodieViewController, capViewController, socsViewController);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}