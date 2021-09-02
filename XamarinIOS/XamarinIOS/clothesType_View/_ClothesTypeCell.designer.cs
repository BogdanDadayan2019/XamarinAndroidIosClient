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
	[Register ("_ClothesTypeCell")]
	partial class _ClothesTypeCell
	{
		[Outlet]
		UIKit.UIImageView bdImage { get; set; }

		[Outlet]
		UIKit.UILabel bdLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (bdImage != null) {
				bdImage.Dispose ();
				bdImage = null;
			}

			if (bdLabel != null) {
				bdLabel.Dispose ();
				bdLabel = null;
			}
		}
	}
}
