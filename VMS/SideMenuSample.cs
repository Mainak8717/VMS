using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UIKit;
using System.Drawing;


namespace VMS
{
	public partial class SideMenuSample : UIViewController
	{

		SideMenuManager _sideMenuManager;

		UISlider _menuScreenWidth, _menuTransformScaleFactor;


		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            this.NavigationItem.SetLeftBarButtonItem(new UIBarButtonItem(
			UIImage.FromFile("menu.png"),
			UIBarButtonItemStyle.Plain,
			(s, e) =>
					{
                        PresentViewController(_sideMenuManager.LeftNavigationController, true, null);
					}
				),
				false);

			_sideMenuManager = new SideMenuManager();

			View.BackgroundColor = UIColor.White;
			Title = "Side Menu";

			var menuPresentMode = new UILabel
			{
				Text = "Menu Present Mode",
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			this.View.Add(menuPresentMode);

			var menuScreenWidth = new UILabel
			{
				Text = "Menu Screen Width",
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			this.View.Add(menuScreenWidth);

			_menuScreenWidth = new UISlider
			{
				MinValue = 0f,
				MaxValue = 1f,
				Value = .75f,
				Continuous = true,
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			_menuScreenWidth.ValueChanged += (sender, e) =>
			{
				_sideMenuManager.MenuWidth = this.View.Frame.Width * _menuScreenWidth.Value;
			};
			this.View.Add(_menuScreenWidth);

			var menuTransformScaleFactor = new UILabel
			{
				Text = "Menu Transform Scale Factor",
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			this.View.Add(menuTransformScaleFactor);

			_menuTransformScaleFactor = new UISlider
			{
				MinValue = 0f,
				MaxValue = 2f,
				Value = 1f,
				Continuous = true,
				TranslatesAutoresizingMaskIntoConstraints = false
			};
			_menuTransformScaleFactor.ValueChanged += (sender, e) =>
			{
				_sideMenuManager.AnimationTransformScaleFactor = _menuTransformScaleFactor.Value;
			};
			this.View.Add(_menuTransformScaleFactor);

			SetupSideMenu();

		}

		void SetupSideMenu()
		{
			_sideMenuManager.LeftNavigationController = new UISideMenuNavigationController(_sideMenuManager, new SampleTableView(), leftSide: true);

			// Enable gestures. The left and/or right menus must be set up above for these to work.
			// Note that these continue to work on the Navigation Controller independent of the View Controller it displays!
			//_sideMenuManager.AddPanGestureToPresent(toView: this.NavigationController?.NavigationBar);

			_sideMenuManager.AddScreenEdgePanGesturesToPresent(toView: this.NavigationController?.View);

			// Set up a cool background image for demo purposes
			_sideMenuManager.AnimationBackgroundColor = UIColor.FromPatternImage(UIImage.FromFile("stars.png"));
		}

		//protected override void Dispose(bool disposing)
		//{
		//	if (disposing)
		//	{
		//		if (_navBarGesture != null)
		//			this.NavigationController?.NavigationBar?.RemoveGestureRecognizer(_navBarGesture);

		//		//if (_navControllerGesture != null)
		//		//    this.NavigationController?.View.RemoveGestureRecognizer(_navControllerGesture);
		//	}

		//	base.Dispose(disposing);
		//}
	}
}