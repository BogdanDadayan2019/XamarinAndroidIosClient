// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using SharedProject;
using UIKit;

namespace XamarinIOS
{
	public partial class HoodieCell : UITableViewCell
	{
		public HoodieCell(IntPtr handle) : base(handle)
		{
		}

		internal void UpdateCell(Clothes<UIImage> clothess)
		{
			bdLabel.Text = clothess.Name;
			bdImage.Image = clothess.bgImage;
		}
	}
}
