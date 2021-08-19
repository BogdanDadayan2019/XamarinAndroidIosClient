using System;
using Foundation;
using UIKit;

namespace XamarinIOS
{
    public class ClothesTypeTableViewSource : UITableViewSource
    {
        public ClothesTypeTableViewSource(System.Collections.Generic.List<Employee> employees)
        {
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            throw new NotImplementedException();
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            throw new NotImplementedException();
        }
    }
}
