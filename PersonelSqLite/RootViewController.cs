
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
   public partial class RootViewController : UITableViewController
   {
      // The list of tasks is NOT persisted, even though you can add and delete tasks
      // in this sample, the changes are only in memory and will disappear when the app restarts
      List<TaskX> tasks;

      public string namex;
      public string notesx;
      public string SubeVerisi { get; set;}

      //

      public async void Yukle()
      {  
         try
         {


            //  xmldekiler = new List<TableItem> ();ƒsqlffff
            string url = "http://www.imsakiyesi.com/xml/gunluk/ANKARA.xml";

            var client = new WebClient ();
            string response = await client.DownloadStringTaskAsync (new Uri (url));

            XElement birimler = XElement.Parse (response);



            var verilerim = from i in birimler.Descendants("vakitler")
                            select new TaskX
            {
               Name  = i.Element ("imsak").Value,
               Notes =  i.Element ("ogle").Value,

            };


            foreach (var yok in verilerim)
            {

               namex  = yok.Name;
               notesx = yok.Notes;

            } 
         }
         catch (Exception ex)
         {
            namex = "e" + ex.Message;
         }

         tasks = new List<TaskX> {



            new TaskX() {Name= namex, Notes=notesx, Done=false},
            new TaskX() {Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}









         };
         TableView.Source = new RootTableSource(tasks.ToArray ());

      }

      public RootViewController (IntPtr handle) : base (handle)
      {

//         Yukle();
         Title = "GörevlerX";
         // Custom initialization


      }

      /// <summary>
      /// Prepares for segue.
      /// </summary>
      /// <remarks>
      /// The prepareForSegue method is invoked whenever a segue is about to take place. 
      //The new view controller has been loaded from the storyboard at this point but it’s not visible yet, and we can use this opportunity to send data to it.
      /// </remarks>
      public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
      {
         if (segue.Identifier == "TaskSegue") { // set in Storyboard
            var navctlr = segue.DestinationViewController as TaskDetailViewController;
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

         var detail = Storyboard.InstantiateViewController("detail") as TaskDetailViewController;
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

      #region View lifecycle

      public override void ViewDidLoad ()
      {
         base.ViewDidLoad ();

         //  Yukle();
         if (SubeVerisi != null)
            this.Title = SubeVerisi;
         else
            this.Title = "Iron Man";

         // Perform any additional setup after loading the view, typically from a nib.
         AddButton.Clicked += (sender, e) => {
            CreateTask ();
         };


         //Non Crypted Data
         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "IDBDBXZ.db3"); // "IDBDBXZ.db3");

         // Crypted Data
         // string SQLitePath =  Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDBXXcCc.db3");



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
//                  if(opinion=="Z")
//                  sqlCom.CommandText = "SELECT * FROM ZSUBE";
//
//                  else if(opinion=="Y")
//                     sqlCom.CommandText = "SELECT * FROM YSUBE";
//
                  if(opinion=="Z")
                  sqlCom.CommandText = "SELECT * FROM EMIRLERZ";
                  else if(opinion=="Y")
                     sqlCom.CommandText = "SELECT * FROM EMIRLERY";
                  else if(opinion=="X")
                     sqlCom.CommandText = "SELECT * FROM EMIRLERX";

                  //"XEMIRLER";



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
                           //  Task dtask= new Task();

                           ///            dtask.Name=String.Format (Convert.ToString (dbReader["UserName"]));
                           TaskX dtask= new TaskX() {Id = Convert.ToInt16( dbReader["ID"]), 

                              Name = String.Format (Convert.ToString (dbReader["Title"])),

                              Notes=String.Format ( Convert.ToString (dbReader["Subject"])),

                              Date = String.Format(Convert.ToString(dbReader["PostDate"])),

                              ImgUrl = String.Format(Convert.ToString(dbReader["ImgUrl"])),

                              DocUrl = String.Format(Convert.ToString(dbReader["DocAdress"])),

                              Sube =     String.Format(Convert.ToString(dbReader["Sube"])),


                              Done = false};
                           tasks.Add(dtask);
                        };
                     }





                  };
                  TableView.Source = new RootTableSource(tasks.ToArray ());


                  //end while

               }
               //end if

               //end using dbReader


               //end using sqlCom

               sqlCon.Close ();

            }
            //end using sqlCon

            //  this.durumGostericiT.Text += "Customer data retrieved.\n";

         } catch (Exception ex) 
         {


         }
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

      #endregion
   }
}



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
//
//
//namespace StoryboardTables
//{
// public partial class RootViewController : UITableViewController
// {
//    // The list of tasks is NOT persisted, even though you can add and delete tasks
//    // in this sample, the changes are only in memory and will disappear when the app restarts
//      List<TaskX> tasks;
//
//      public string namex;
//      public string notesx;
//
//      //
//
//      public async void Yukle()
//      {  
//         try
//         {
//
//
//            //  xmldekiler = new List<TableItem> ();
//            string url = "http://www.imsakiyesi.com/xml/gunluk/ANKARA.xml";
//
//            var client = new WebClient ();
//            string response = await client.DownloadStringTaskAsync (new Uri (url));
//
//            XElement birimler = XElement.Parse (response);
//
//
//
//            var verilerim = from i in birimler.Descendants("vakitler")
//                            select new TaskX
//            {
//               Name  = i.Element ("imsak").Value,
//               Notes =  i.Element ("ogle").Value,
// 
//            };
//
//
//            foreach (var yok in verilerim)
//            {
//
//               namex  = yok.Name;
//               notesx = yok.Notes;
//
//            } 
//         }
//         catch (Exception ex)
//         {
//            namex = "e" + ex.Message;
//         }
//
//         tasks = new List<TaskX> {
//
//
//
//            new TaskX() {Name= namex, Notes=notesx, Done=false},
//            new TaskX() {Name="Devices", Notes="Buy Nexus, Galaxy, Droid", Done=false}
//
//
//
//
//
//
//
//
//
//         };
//         TableView.Source = new RootTableSource(tasks.ToArray ());
//
//      }
//
//
//
//
//
//
//
//
//    public RootViewController (IntPtr handle) : base (handle)
//    {
//
////         Yukle();
//         Title = "GörevlerX";
//         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyDBX.db3");
//
//         SqList(SQLitePath);
//       // Custom initialization
//    
//    
//      }
//
//    /// <summary>
//    /// Prepares for segue.
//    /// </summary>
//    /// <remarks>
//    /// The prepareForSegue method is invoked whenever a segue is about to take place. 
//    //The new view controller has been loaded from the storyboard at this point but it’s not visible yet, and we can use this opportunity to send data to it.
//    /// </remarks>
//    public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
//    {
//       if (segue.Identifier == "TaskSegue") { // set in Storyboard
//          var navctlr = segue.DestinationViewController as TaskDetailViewController;
//          if (navctlr != null) {
//             var row = TableView.IndexPathForSelectedRow;
//             var source = TableView.Source as RootTableSource;
//             var item = source.GetItem(row.Row);
//             navctlr.SetTask(this, item);
//          }
//       }
//    }
//
//    public void CreateTask () {
//       var newId = tasks[tasks.Count - 1].Id + 1;
//         var newTask = new TaskX(){Id=newId};
//       tasks.Add (newTask);
//       
//       var detail = Storyboard.InstantiateViewController("detail") as TaskDetailViewController;
//       detail.SetTask (this, newTask);
//       NavigationController.PushViewController (detail, true);
//
//
//    }
//      public void SaveTask (TaskX task) {
//       Console.WriteLine("Save "+task.Name);
//       var oldTask = tasks.Find(t => t.Id == task.Id);
//       oldTask = task;
//       NavigationController.PopViewControllerAnimated(true);
//    }
//      public void DeleteTask (TaskX task) {
//       Console.WriteLine("Delete "+task.Name);
//       var oldTask = tasks.Find(t => t.Id == task.Id);
//       tasks.Remove (oldTask);
//       NavigationController.PopViewControllerAnimated(true);
//    }
//
//
//
//
//
//
//    public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
//    {
//       // Return true for supported orientations
//       return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
//    }
//    
//    public override void DidReceiveMemoryWarning ()
//    {
//       // Releases the view if it doesn't have a superview.
//       base.DidReceiveMemoryWarning ();
//       
//       // Release any cached data, images, etc that aren't in use.
//    }
//    
//    #region View lifecycle
//    
//    public override void ViewDidLoad ()
//    {
//       base.ViewDidLoad ();
//       
//         //  Yukle();
//
//
//
//       // Perform any additional setup after loading the view, typically from a nib.
//       AddButton.Clicked += (sender, e) => {
//          CreateTask ();
//       };
//
//
//    }
//    
//    public override void ViewDidUnload ()
//    {
//       base.ViewDidUnload ();
//       
//    
//
//       }
//
//
//      public void SqList(string databaseFile)
//      {
//         try 
//         {
//
//        
//
//
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
//
//                  sqlCom.CommandText = "SELECT * FROM Personel";
//
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
//                           //  Task dtask= new Task();
//
//                           ///            dtask.Name=String.Format (Convert.ToString (dbReader["UserName"]));
//                           TaskX dtask= new TaskX() {Id = Convert.ToInt16( dbReader["ID"]), 
//
//                                 Name = String.Format (Convert.ToString (dbReader["UserName"])),
//
//                              Notes=String.Format ( Convert.ToString (dbReader["Password"])),
//
//
//
//                              Done=false};
//                                       tasks.Add(dtask);
//                        };
//                        }
//
//                           
//
//                       
//
//                           };
//                     TableView.Source = new RootTableSource(tasks.ToArray ());
//
//
//                        //end while
//
//                     }
//                     //end if
//
//                  //end using dbReader
//
//             
//               //end using sqlCom
//
//               sqlCon.Close ();
//
//            }
//            //end using sqlCon
//
//            //  this.durumGostericiT.Text += "Customer data retrieved.\n";
//      
//      } catch (Exception ex) 
//         {
//
//
//         }
//      }
//
//
//
//
//
//
//
//    
//    public override void ViewWillAppear (bool animated)
//    {
//       base.ViewWillAppear (animated);
//         if(tasks!=null)
//         TableView.Source = new RootTableSource(tasks.ToArray ());
//               
//          }
//    
//    public override void ViewDidAppear (bool animated)
//    {
//       base.ViewDidAppear (animated);
//    }
//    
//    public override void ViewWillDisappear (bool animated)
//    {
//       base.ViewWillDisappear (animated);
//    }
//    
//    public override void ViewDidDisappear (bool animated)
//    {
//       base.ViewDidDisappear (animated);
//    }
//    
//    #endregion
// }
//}
//


