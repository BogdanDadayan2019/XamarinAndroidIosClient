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
	[Register ("_CapViewController")]
	partial class _CapViewController
	{
		[Outlet]
		UIKit.UIBarButtonItem bdButton { get; set; }

		[Outlet]
		UIKit.UITableView CapTableView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (CapTableView != null) {
				CapTableView.Dispose ();
				CapTableView = null;
			}

			if (bdButton != null) {
				bdButton.Dispose ();
				bdButton = null;
			}
		}
	}
}
