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
	[Register ("AsyncDownload")]
	partial class AsyncDownload
	{
		[Outlet]
		MonoTouch.UIKit.UIButton belgeGoster { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIBarButtonItem dGosterUI { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIImageView DownloadedImageView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton GetButton { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel ResultLabel { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextView ResultTextView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (belgeGoster != null) {
				belgeGoster.Dispose ();
				belgeGoster = null;
			}

			if (DownloadedImageView != null) {
				DownloadedImageView.Dispose ();
				DownloadedImageView = null;
			}

			if (GetButton != null) {
				GetButton.Dispose ();
				GetButton = null;
			}

			if (ResultLabel != null) {
				ResultLabel.Dispose ();
				ResultLabel = null;
			}

			if (ResultTextView != null) {
				ResultTextView.Dispose ();
				ResultTextView = null;
			}

			if (dGosterUI != null) {
				dGosterUI.Dispose ();
				dGosterUI = null;
			}
		}
	}
}
