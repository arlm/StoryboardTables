//using System;                  
//using System.Drawing;
//using System.Collections.Generic;
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
//using System.Net;
//using System.Linq;
//using System.Xml.Linq;
//using System.IO;
//using Mono.Data.Sqlite;
//
//namespace StoryboardTables
//{
//   public partial class SubeViewListController : UITableViewController
//   {   
//      List<TaskX> tasks;
//
//      public string namex;
//      public string notesx;
//      public string SubeVerisi { get; set;}
//
//      public async void Yukle()
//      { 
//         tasks = new List<TaskX> 
//         {
//
//            new TaskX() {Name= namex, Notes=notesx, Done=false},
//            new TaskX() {Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}
//
//         };
//         TableView.Source = new RootTableSource(tasks.ToArray ());
//      }
//
//      public SubeViewListController (IntPtr handle) : base (handle)
//      {
//
//      }
//
//      public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
//      {
//         if (segue.Identifier == "subeVerileriGonder") { // set in Storyboard
//            var navctlr = segue.DestinationViewController as SubeVerileriTaskControllerList;
//            if (navctlr != null) {
//               var row = TableView.IndexPathForSelectedRow;
//               var source = TableView.Source as RootTableSource;
//               var item = source.GetItem(row.Row);
//               navctlr.SetTask(this, item);
//            }
//         }
//      }
//      public void CreateTask () {
//         var newId = tasks[tasks.Count - 1].Id + 1;
//         var newTask = new TaskX(){Id=newId};
//         tasks.Add (newTask);
//
//         var detail = Storyboard.InstantiateViewController("subedetail") as SubeVerileriTaskControllerList;
//         detail.SetTask (this, newTask);
//         NavigationController.PushViewController (detail, true);
//
//
//      }
//      public void SaveTask (TaskX task) {
//         Console.WriteLine("Save "+task.Name);
//         var oldTask = tasks.Find(t => t.Id == task.Id);
//         oldTask = task;
//         NavigationController.PopViewControllerAnimated(true);
//      }
//      public void DeleteTask (TaskX task) {
//         Console.WriteLine("Delete "+task.Name);
//         var oldTask = tasks.Find(t => t.Id == task.Id);
//         tasks.Remove (oldTask);
//         NavigationController.PopViewControllerAnimated(true);
//      }
//      public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
//      {
//         // Return true for supported orientations
//         return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
//      }
//
//      public override void DidReceiveMemoryWarning ()
//      {
//         // Releases the view if it doesn't have a superview.
//         base.DidReceiveMemoryWarning ();
//
//         // Release any cached data, images, etc that aren't in use.
//      }
//
//
//
//
//
//
//
//
//      public override void ViewDidLoad ()
//      {
//         base.ViewDidLoad ();
//         //  Yukle();
//         if (SubeVerisi != null)
//            this.Title = SubeVerisi;
//         else
//            this.Title = "BB King";
//         AddButton.Clicked += (sender, e) => {
//            CreateTask ();
//         };
//         //Non Crypted Data
//         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), " MyDBXSz.db3"); // "IDBDBXZ.db3");
//
//         // Crypted Data
//         // string SQLitePath =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDBXXcCc.db3");
//
//
//
//         SqList(SQLitePath,SubeVerisi);
//
//      }
//      public override void ViewDidUnload ()
//      {
//         base.ViewDidUnload ();
//      }
//
//      public void SqList(string databaseFile,string opinion)
//      {
//         try 
//         {
//            if (!File.Exists (databaseFile)) 
//            {
//
//               return;
//
//            }
//            //end if
//
//            // Connect to database
//            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile))) 
//            {
//
//               sqlCon.Open ();
//
//               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon)) 
//               {
//                  sqlCom.CommandText="SELECT * FROM Personel";
//
////                       if(opinion=="Z")
////                     sqlCom.CommandText = "SELECT * FROM ZSUBE";
////
////                  else if(opinion=="Y")
////                     sqlCom.CommandText = "SELECT * FROM YSUBE";
////
//                  // Execute the SELECT statement and retrieve the data
//                  using (SqliteDataReader dbReader = sqlCom.ExecuteReader ())
//                  {
//                     if (dbReader.HasRows)
//                     {
//                        int i;
//                        // Advance through each row
//                        tasks = new List<TaskX> ();
//                        while (dbReader.Read ())
//                        {     
//                           TaskX dtask= new TaskX() {Id = Convert.ToInt16( dbReader["ID"]), 
//                              Name = String.Format (Convert.ToString (dbReader["UserName"])),
//                              Notes=String.Format ( Convert.ToString (dbReader["Password"])),
//                              Done=false};
//                           tasks.Add(dtask);
//                        };
//                     }
//                  };
//                  TableView.Source = new RootTableSource(tasks.ToArray ());
//               }
//               sqlCon.Close ();
//            }
//         } catch (Exception ex) 
//         { }
//      }
//
//      public override void ViewWillAppear (bool animated)
//      {
//         base.ViewWillAppear (animated);
//         if(tasks!=null)
//            TableView.Source = new RootTableSource(tasks.ToArray ());
//      }
//      public override void ViewDidAppear (bool animated)
//      {
//         base.ViewDidAppear (animated);
//      }
//
//      public override void ViewWillDisappear (bool animated)
//      {
//         base.ViewWillDisappear (animated);
//      }
//
//      public override void ViewDidDisappear (bool animated)
//      {
//         base.ViewDidDisappear (animated);
//      }
//
//   }
//}
//
//



using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using Mono.Data.Sqlite;

namespace StoryboardTables
{
   public partial class SubeViewListController : UITableViewController
   {   
      List<TaskX> tasks;

      public string namex;
      public string notesx;
      public string SubeVerisi { get; set;}

      public async void Yukle()
      { 
         tasks = new List<TaskX> 
         {

            new TaskX() {Name= namex, Notes=notesx, Done=false},
            new TaskX() {Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}

         };
         TableView.Source = new RootTableSource(tasks.ToArray ());
      }

      public SubeViewListController (IntPtr handle) : base (handle)
      {

      }

  

      public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
      {
         if (segue.Identifier == "subeVerileriGonder") { // set in Storyboard
            var navctlr = segue.DestinationViewController as SubeVerileriTaskControllerList;
            if (navctlr != null) {
               var row = TableView.IndexPathForSelectedRow;
               var source = TableView.Source as RootTableSource;
               var item = source.GetItem(row.Row);
               navctlr.SetTask(this, item);
            }
         }
      }


      public void CreateTask () {
         var newId = tasks[tasks.Count - 1].Id + 1;
         var newTask = new TaskX(){Id=newId};
         tasks.Add (newTask);

         var detail = Storyboard.InstantiateViewController("subedetail") as SubeVerileriTaskControllerList;
         detail.SetTask (this, newTask);
         NavigationController.PushViewController (detail, true);


      }
      public void SaveTask (TaskX task) {
         Console.WriteLine("Save "+task.Name);
         var oldTask = tasks.Find(t => t.Id == task.Id);
         oldTask = task;
         NavigationController.PopViewControllerAnimated(true);
      }
      public void DeleteTask (TaskX task) {
         Console.WriteLine("Delete "+task.Name);
         var oldTask = tasks.Find(t => t.Id == task.Id);
         tasks.Remove (oldTask);
         NavigationController.PopViewControllerAnimated(true);
      }
      public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
      {
         // Return true for supported orientations
         return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
      }

      public override void DidReceiveMemoryWarning ()
      {
         // Releases the view if it doesn't have a superview.
         base.DidReceiveMemoryWarning ();

         // Release any cached data, images, etc that aren't in use.
      }








      public override void ViewDidLoad ()
      {
         base.ViewDidLoad ();
         //  Yukle();
         if (SubeVerisi != null)
            this.Title = SubeVerisi;
         else
            this.Title = "BB King";
         AddButton.Clicked += (sender, e) => {
            CreateTask ();
         };
         //Non Crypted Data
         //  string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDBXS.db3"); // "IDBDBXZ.db3");

         // Crypted Data
         string SQLitePath =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDBXSz.db3");



         SqList(SQLitePath,SubeVerisi);

      }
      public override void ViewDidUnload ()
      {
         base.ViewDidUnload ();
      }

      public void SqList(string databaseFile,string opinion)
      {
         try 
         {
            if (!File.Exists (databaseFile)) 
            {

               return;

            }
            //end if

            // Connect to database
            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile))) 
            {

               sqlCon.Open ();

               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon)) 
               {
                  sqlCom.CommandText="SELECT * FROM Personel";

//                       if(opinion=="Z")
//                     sqlCom.CommandText = "SELECT * FROM ZSUBE";
//
//                  else if(opinion=="Y")
//                     sqlCom.CommandText = "SELECT * FROM YSUBE";
//
                  // Execute the SELECT statement and retrieve the data
                  using (SqliteDataReader dbReader = sqlCom.ExecuteReader ())
                  {
                     if (dbReader.HasRows)
                     {
                        int i;
                        // Advance through each row
                        tasks = new List<TaskX> ();
                        while (dbReader.Read ())
                        {     
                           TaskX dtask= new TaskX() {Id = Convert.ToInt16( dbReader["ID"]), 
                              Name = String.Format (Convert.ToString (dbReader["UserName"])),
                              Notes=String.Format ( Convert.ToString (dbReader["Password"])),
                              Done=false};
                           tasks.Add(dtask);
                        };
                     }
                  };
                  TableView.Source = new RootTableSource(tasks.ToArray ());
               }
               sqlCon.Close ();
            }
         } catch (Exception ex) 
         { }
      }

      public override void ViewWillAppear (bool animated)
      {
         base.ViewWillAppear (animated);
         if(tasks!=null)
            TableView.Source = new RootTableSource(tasks.ToArray ());
      }
      public override void ViewDidAppear (bool animated)
      {
         base.ViewDidAppear (animated);
      }

      public override void ViewWillDisappear (bool animated)
      {
         base.ViewWillDisappear (animated);
      }

      public override void ViewDidDisappear (bool animated)
      {
         base.ViewDidDisappear (animated);
      }

   }
}
