// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace XamarinIOS.tshirt_View
{
	[Register ("_bdView")]
	partial class _bdView
	{
		[Outlet]
		UIKit.UITableView _bdTable { get; set; }

		[Outlet]
		UIKit.UITableView _bdTableCell { get; set; }

		[Outlet]
		UIKit.UIBarButtonItem bdButton2 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_bdTable != null) {
				_bdTable.Dispose ();
				_bdTable = null;
			}

			if (_bdTableCell != null) {
				_bdTableCell.Dispose ();
				_bdTableCell = null;
			}

			if (bdButton2 != null) {
				bdButton2.Dispose ();
				bdButton2 = null;
			}
		}
	}
}
