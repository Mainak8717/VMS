using System;

using UIKit;

namespace VMS
{
	public partial class LoginViewController : UIViewController
	{
		public LoginViewController() : base("LoginViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			this.NavigationController.NavigationBar.Hidden = true;
			this.submitBtn.TouchUpInside += (sender, e) =>
			{

			var cvc = new SideMenuSample();


				UINavigationController navC = new UINavigationController(new SideMenuSample());
				UIApplication.SharedApplication.KeyWindow.RootViewController = navC;
				UIApplication.SharedApplication.KeyWindow.MakeKeyAndVisible();

			};
		}
	}
}

