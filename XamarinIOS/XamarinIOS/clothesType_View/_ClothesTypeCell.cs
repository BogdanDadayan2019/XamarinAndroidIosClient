// This file has been autogenerated from a class added in the UI designer.

using System;

using Foundation;
using UIKit;

namespace XamarinIOS
{
	public partial class _ClothesTypeCell : UITableViewCell
	{
		public _ClothesTypeCell (IntPtr handle) : base (handle)
		{
		}

		internal void UpdateCell(ClothesType _clothesType)
		{
			bdLabel.Text = _clothesType.NameType;
			bdImage.Image = _clothesType.BdImage;
		}
	}
}
