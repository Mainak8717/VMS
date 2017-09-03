using System;
using Foundation;
using UIKit;

namespace VMS
{
	public class SampleTableView : UITableViewController
	{
		string[] menuArray = { "Home", "Create New Trip", "List of Trips", "Logout" };
		public SampleTableView()
		{
		}
		public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
		{
			if (indexPath.Row == 0)
				return 100;
			return 40;
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			//this.TableView.RegisterClassForCellReuse(typeof(UITableViewVibrantCell), "VibrantCell");
			this.TableView.RegisterClassForCellReuse(typeof(MenuHeaderCell), "MenuHeaderCell");
		}

		public override nint RowsInSection(UITableView tableView, nint section)
		{
			return 1;
		}

		public override UITableViewCell GetCell(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			UITableViewCell cell = (MenuHeaderCell)tableView.DequeueReusableCell("MenuHeaderCell");
			//if (indexPath.Row == 0)
			//	cell = (MenuHeaderCell)tableView.DequeueReusableCell("MenuHeaderCell");
			//else
			//{
			//	//cell = tableView.DequeueReusableCell("VibrantCell");

			//	//cell.TextLabel.Text = menuArray[indexPath.Row];
			//}

			return cell;
		}

		public override void RowSelected(UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			tableView.DeselectRow(indexPath, true);

			var rnd = new Random(Guid.NewGuid().GetHashCode());

			var vc = new UIViewController() { };
			vc.View.BackgroundColor = UIColor.FromRGB(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));

			this.ShowViewController(vc, this);
		}
	}
}

