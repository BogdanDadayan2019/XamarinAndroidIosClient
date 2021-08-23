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
	[Register ("_bdCell")]
	partial class _bdCell
	{
		[Outlet]
		UIKit.UIImageView _bdImage { get; set; }

		[Outlet]
		UIKit.UILabel _bdLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_bdLabel != null) {
				_bdLabel.Dispose ();
				_bdLabel = null;
			}

			if (_bdImage != null) {
				_bdImage.Dispose ();
				_bdImage = null;
			}
		}
	}
}
