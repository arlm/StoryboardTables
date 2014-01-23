// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace MonoTouchData_Hal
{
	[Register ("KayitEkle")]
	partial class KayitEkle
	{
		[Outlet]
		MonoTouch.UIKit.UITextField departmanX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UILabel durumT { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField email { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField gorevX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField isim { get; set; }

		[Outlet]
		MonoTouch.UIKit.UIButton kaydetX { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField kullaniciAdi { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField parola { get; set; }

		[Outlet]
		MonoTouch.UIKit.UITextField telefon { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (departmanX != null) {
				departmanX.Dispose ();
				departmanX = null;
			}

			if (email != null) {
				email.Dispose ();
				email = null;
			}

			if (gorevX != null) {
				gorevX.Dispose ();
				gorevX = null;
			}

			if (isim != null) {
				isim.Dispose ();
				isim = null;
			}

			if (kaydetX != null) {
				kaydetX.Dispose ();
				kaydetX = null;
			}

			if (kullaniciAdi != null) {
				kullaniciAdi.Dispose ();
				kullaniciAdi = null;
			}

			if (parola != null) {
				parola.Dispose ();
				parola = null;
			}

			if (telefon != null) {
				telefon.Dispose ();
				telefon = null;
			}

			if (durumT != null) {
				durumT.Dispose ();
				durumT = null;
			}
		}
	}
}
