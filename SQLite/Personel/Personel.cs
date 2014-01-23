//using System;
//using System.Drawing;
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
//using System.IO;
//using MonoTouch.Dialog;
//
//namespace MonoTouchData_Hal
//{
//
//   public class MainTabBarController : UITabBarController
//   {
//
//     
//
//
//      public override void ViewDidLoad ()
//      { 
//
//         KayitEkle kayit;
//         Yardim yardim;
//         Personel personel;
//         Yonetim yonet;
//         MainPersonel mp;
//        
//         kayit = new KayitEkle();
//         kayit.Title = "Kayıt Ekleme Modülü";
//         kayit.TabBarItem = new UITabBarItem ("Kayıt Ekle", UIImage.FromFile("Images/plus.png"), 0); // Tag == initial order
//
//         personel = new Personel();
//         personel.Title = "İDB Giriş Ekranına Hoşgeldin";
//         personel.TabBarItem = new UITabBarItem ("Giriş", UIImage.FromFile("Images/home.png"), 1);
//
//         yonet = new Yonetim();
//         yonet.Title = "Düzenleme Modülü";
//         yonet.TabBarItem = new UITabBarItem ("Düzenle", UIImage.FromFile("Images/edit.png"), 2);
//
//         yardim = new Yardim();
//         yardim.Title = "İletişim";
//         yardim.TabBarItem = new UITabBarItem ("İletişim", UIImage.FromFile("Images/iletisim.png"), 3);
//         yardim.View.BackgroundColor = UIColor.Magenta;
//
//         mp = new MainPersonel();
//         mp.Title = "Check";
//         mp.TabBarItem = new UITabBarItem ("Kontrol", UIImage.FromFile("Images/iletisim.png"), 3);
//         mp.View.BackgroundColor = UIColor.Magenta;
//
//
//
//
//
//
//         ViewControllers = new UIViewController[]
//         {
//            personel,
//            kayit,
//            yonet,
//            yardim,
//            mp
//
//
//         };
//         SelectedIndex = 0;
//      }
//   }
//
//
//  
//
//
//   public partial class Personel : UIViewController
//   {
//      UINavigationController navController;
//      UIWindow window;
//      Yardim yx;
//
//       public Personel() : base("Personel", null)
//      {
//      }
//       public override void DidReceiveMemoryWarning()
//      {
//         // Releases the view if it doesn't have a superview.
//         base.DidReceiveMemoryWarning();
//         
//         // Release any cached data, images, etc that aren't in use.
//      }
//
//      public override void ViewDidLoad()
//      {
//         base.ViewDidLoad();
//
//          
//         if(yx==null)
//         {
//            yx = new Yardim();
//
//
//         }
//
//
//         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "idbgm.db3");
//
//          
//
//         // Perform any additional setup after loading the view, typically from a nib.
//      }
//   }
//}
//
