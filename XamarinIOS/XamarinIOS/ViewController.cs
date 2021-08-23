using Foundation;
using System;
using System.Collections.Generic;
using UIKit;

namespace XamarinIOS
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            var employees = new List<Employee>
            {
                new Employee
                {
                    Name = "T-shirts",
                    TranslateName = "футболки",
                    BdImage = UIImage.FromBundle("t-shirt")
                },
                new Employee
                {
                    Name = "Hoodies",
                    TranslateName = "худи",
                    BdImage = UIImage.FromBundle("hoodie")
                },
                new Employee
                {
                    Name = "Caps",
                    TranslateName = "кепки",
                    BdImage = UIImage.FromBundle("caps")
                },
                new Employee
                {
                    Name = "Socs",
                    TranslateName = "носки",
                    BdImage = UIImage.FromBundle("socs")
                }
        };


            btnPress.TouchUpInside += (object sender, EventArgs e) =>
            {
                var alert = UIAlertController.Create("Not supported", "Scheme 'tel:' is not supported on this device", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
                PresentViewController(alert, true, null);
            };



            bdTableView.RowHeight = 62;

            bdTableView.ReloadData();

            bdTableView.Source = new EmployeesTVS(employees);

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}