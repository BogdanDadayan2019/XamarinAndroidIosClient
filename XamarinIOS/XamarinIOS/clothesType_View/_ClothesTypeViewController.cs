using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace XamarinIOS
{
    public partial class _ClothesTypeViewController : UIViewController
    {
        UIViewController tshirtViewController;
        UIViewController hoodieViewController;
        UIViewController socsViewController;
        UIViewController capViewController;

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

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            var clothesTypes = new List<ClothesType>
            {
                new ClothesType
                {
                    Name = "T-shirts",
                    TranslateName = "футболки",
                    BdImage = UIImage.FromBundle("t-shirt")
                },
                new ClothesType
                {
                    Name = "Hoodies",
                    TranslateName = "худи",
                    BdImage = UIImage.FromBundle("hoodie")
                },
                new ClothesType
                {
                    Name = "Caps",
                    TranslateName = "кепки",
                    BdImage = UIImage.FromBundle("caps")
                },
                new ClothesType
                {
                    Name = "Socs",
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