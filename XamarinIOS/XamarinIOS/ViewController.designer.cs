// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinIOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UITableView bdTableView { get; set; }

		[Outlet]
		UIKit.UITableViewCell bdTableViewCell { get; set; }

		[Outlet]
		UIKit.UIButton btnPress { get; set; }

		[Outlet]
		UIKit.UILabel dd { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (bdTableView != null) {
				bdTableView.Dispose ();
				bdTableView = null;
			}

			if (bdTableViewCell != null) {
				bdTableViewCell.Dispose ();
				bdTableViewCell = null;
			}

			if (btnPress != null) {
				btnPress.Dispose ();
				btnPress = null;
			}

			if (dd != null) {
				dd.Dispose ();
				dd = null;
			}
		}
	}
}
