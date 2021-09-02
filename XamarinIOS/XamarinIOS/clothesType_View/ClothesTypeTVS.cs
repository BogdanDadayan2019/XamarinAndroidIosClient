using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace XamarinIOS
{
    internal class ClothesTypeTVS : UITableViewSource
    {
        private List<ClothesType> clothesType;
        UINavigationController navigationController;
        UIViewController tshirtViewController;
        UIViewController hoodieViewController;
        UIViewController socsViewController;
        UIViewController capViewController;

        public ClothesTypeTVS(List<ClothesType> clothesType, UINavigationController navigationController, UIViewController hoodieViewController, UIViewController tshirtViewController, UIViewController socsViewController, UIViewController capViewController)
        {
            this.clothesType = clothesType;
            this.navigationController = navigationController;

            this.tshirtViewController = tshirtViewController;
            this.hoodieViewController = hoodieViewController;
            this.capViewController = capViewController;
            this.socsViewController = socsViewController;

        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            var cell = (_ClothesTypeCell) tableView.DequeueReusableCell("cell_id", indexPath);

            var _clothesType = clothesType[indexPath.Row];

            cell.UpdateCell(_clothesType);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return clothesType.Count;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {

            var row = indexPath.Row;

            if (row == 1)
            {
                this.navigationController.PushViewController(tshirtViewController, true);
            }
            else if (row == 0)
            {
                this.navigationController.PushViewController(hoodieViewController, true);
            }
            else if (row == 3)
            {
                this.navigationController.PushViewController(capViewController, true);
            }
            else if (row == 2)
            {
                this.navigationController.PushViewController(socsViewController, true);
            }

        }
    }
}