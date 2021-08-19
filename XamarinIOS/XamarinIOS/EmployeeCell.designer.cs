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
	[Register ("EmployeeCell")]
	partial class EmployeeCell
	{
		[Outlet]
		UIKit.UIImageView bdImageCell { get; set; }

		[Outlet]
		UIKit.UILabel bdLabelCell1 { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (bdLabelCell1 != null) {
				bdLabelCell1.Dispose ();
				bdLabelCell1 = null;
			}

			if (bdImageCell != null) {
				bdImageCell.Dispose ();
				bdImageCell = null;
			}
		}
	}
}
