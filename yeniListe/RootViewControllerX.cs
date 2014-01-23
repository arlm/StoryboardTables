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
//using System.Xml;
//
//
//namespace StoryboardTables
//{
//   public partial class RootViewControllerX : UITableViewController
//   {
//      public string SubeVerisi {get;set;}
//
//      List<TaskX> tasks;
//      public string namex;
//      public string notesx;
//
//
//      public string c;
//
//      public RootViewControllerX (IntPtr handle) : base (handle)
//      {
//
//
//
//
//
//      }
//    
//
//      /// <summary>
//      /// Prepares for segue.
//      /// </summary>
//      /// <remarks>
//      /// The prepareForSegue method is invoked whenever a segue is about to take place. 
//      //The new view controller has been loaded from the storyboard at this point but it’s not visible yet, and we can use this opportunity to send data to it.
//      /// </remarks>
//      public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
//      {
//         if (segue.Identifier == "task2X") { // set in Storyboard
//            var navctlr = segue.DestinationViewController as TaskDetailViewControllerX;
//            if (navctlr != null) {
//               var row = TableView.IndexPathForSelectedRow;
//               var source = TableView.Source as RootTableSource;
//               var item = source.GetItem(row.Row);
//               navctlr.SetTask(this, item);
//            }
//         }
//      }
//
//      public void CreateTask () {
//         var newId = tasks[tasks.Count - 1].Id + 1;
//         var newTask = new TaskX(){Id=newId};
//         tasks.Add (newTask);
//         
//         var detail = Storyboard.InstantiateViewController("detail") as TaskDetailViewControllerX;
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
//
//
//
//
//
//
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
//      #region View lifecycle
//      
//      public override void ViewDidLoad ()
//      {
//         base.ViewDidLoad ();
//         
//         //  Yukle();
//
//
//         this.Title = SubeVerisi;
//
//
//         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "IDBDBXZ.db3");
//         SqList(SQLitePath,SubeVerisi);
//
//
//         // Perform any additional setup after loading the view, typically from a nib.
//         AddButton.Clicked += (sender, e) => {
//            CreateTask ();
//         };
//
//
//      }
//      
//      public override void ViewDidUnload ()
//      {
//         base.ViewDidUnload ();
//         
//      
//
//      }
//
//
//      public void SqList(string databaseFile,string opinion)
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
//                  if(opinion=="Z")
//                  sqlCom.CommandText = "SELECT * FROM ZSUBE";
//                  else if(opinion=="Y")
// sqlCom.CommandText = "SELECT * FROM YSUBE";
//
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
//                              Name = String.Format (Convert.ToString (dbReader["Title"])),
//
//                              Notes=String.Format ( Convert.ToString (dbReader["Subject"])),
//
//                              Date = String.Format(Convert.ToString(dbReader["PostDate"])),
//
//                              ImgUrl = String.Format(Convert.ToString(dbReader["ImgUrl"])),
//
//                              DocUrl = String.Format(Convert.ToString(dbReader["DocAdress"])),
//
//
//                              Done = false};
//                           tasks.Add(dtask);
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
//      public override void ViewWillAppear (bool animated)
//      {
//         base.ViewWillAppear (animated);
//         if(tasks!=null)
//         TableView.Source = new RootTableSource(tasks.ToArray ());
//               
//            }
//      
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
//      #endregion
//   }
//}
