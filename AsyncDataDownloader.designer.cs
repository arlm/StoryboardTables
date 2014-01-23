// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace StoryboardTables
{
	[Register ("AsyncDataDownloader")]
	partial class AsyncDataDownloader
	{
		[Outlet]
		MonoTouch.UIKit.UIImageView DownloadedImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton getAsync { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton getXMLX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton kayitOldumu { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ResultLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView ResultTextView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (DownloadedImageView != null) {
				DownloadedImageView.Dispose ();
				DownloadedImageView = null;
			}

			if (getAsync != null) {
				getAsync.Dispose ();
				getAsync = null;
			}

			if (GetButton != null) {
				GetButton.Dispose ();
				GetButton = null;
			}

			if (getXMLX != null) {
				getXMLX.Dispose ();
				getXMLX = null;
			}

			if (kayitOldumu != null) {
				kayitOldumu.Dispose ();
				kayitOldumu = null;
			}

			if (ResultLabel != null) {
				ResultLabel.Dispose ();
				ResultLabel = null;
			}

			if (ResultTextView != null) {
				ResultTextView.Dispose ();
				ResultTextView = null;
			}
		}
	}
}
