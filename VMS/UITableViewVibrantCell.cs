using System;
using UIKit;

namespace VMS
{
	public class UITableViewVibrantCell : UITableViewCell
	{
		UIVisualEffectView _vibrancyView = new UIVisualEffectView();

		UIVisualEffectView _vibrancySelectedBackgroundView = new UIVisualEffectView();

		UIView _defaultSelectedBackgroundView;

		UIBlurEffect _blurEffect;

		public UITableViewVibrantCell(IntPtr handle) : base(handle) {
			Initialize();
		}

		public UITableViewVibrantCell()
		{
			Initialize();
		}

		void Initialize() {
			_vibrancyView.Frame = this.Bounds;
			_vibrancyView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight | UIViewAutoresizing.FlexibleWidth;

			foreach (var view in this.Subviews)
				_vibrancyView.ContentView.AddSubview(view);

			AddSubview(_vibrancyView);

			_defaultSelectedBackgroundView = this.SelectedBackgroundView;
		}


		public override void LayoutSubviews()
		{
			base.LayoutSubviews();
			this.BackgroundColor = UIColor.Clear;
		}
	}
}