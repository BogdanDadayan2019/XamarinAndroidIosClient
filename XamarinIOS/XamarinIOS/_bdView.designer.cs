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
	[Register ("_bdView")]
	partial class _bdView
	{
		[Outlet]
		UIKit.UIButton _bdButton { get; set; }

		[Outlet]
		UIKit.UITableView _bdTable { get; set; }

		[Outlet]
		UIKit.UITableView _bdTableCell { get; set; }
		
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

			if (_bdButton != null) {
				_bdButton.Dispose ();
				_bdButton = null;
			}
		}
	}
}
