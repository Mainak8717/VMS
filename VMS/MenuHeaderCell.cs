using System;

using Foundation;
using UIKit;

namespace VMS
{
	public partial class MenuHeaderCell : UITableViewCell
	{
		public static readonly NSString Key = new NSString("MenuHeaderCell");
		public static readonly UINib Nib;

		static MenuHeaderCell()
		{
			Nib = UINib.FromName("MenuHeaderCell", NSBundle.MainBundle);
		}

		protected MenuHeaderCell(IntPtr handle) : base(handle)
		{
			// Note: this .ctor should not contain any initialization logic.
		}
	}
}
