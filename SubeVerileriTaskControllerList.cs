//using System;       Şifrelenmemiş detail verisi

//
//using MonoTouch.Foundation;
//using MonoTouch.UIKit;
//using Mono.Data.Sqlite;
//using System.IO;
//
//namespace StoryboardTables
//{
// public partial class SubeVerileriTaskControllerList : UITableViewController
// {
//      TaskX currentTask {get;set;}
//      public SubeViewListController Delegate {get;set;}
//
//    public SubeVerileriTaskControllerList (IntPtr handle) : base (handle)
//    {
//    }
//
//      public override void ViewDidLoad ()
//      {
//         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "IDBDBXZ.db3");
//
//         base.ViewDidLoad();
//
//         SaveButton.TouchUpInside += (sender, e) =>
//         {
//            currentTask.Name = TitleText.Text;
//            currentTask.Notes = NotesText.Text;
//            currentTask.Done = DoneSwitch.On;
//
//
//            Delegate.SaveTask(currentTask);
//
//            UpdateData(SQLitePath);
//         };
//
//         DeleteButton.TouchUpInside += (sender, e) =>
//         {
//            Delegate.DeleteTask(currentTask);
//
//            DeleteData(SQLitePath);
//         };
//      }
//      private void CreateData (string databaseFile)
//      {
//         try
//         {
//            if (!File.Exists (databaseFile))
//            {
//               return;
//            }
//            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile)))
//            {
//               sqlCon.Open ();
//               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon))
//               {
//                  sqlCom.CommandText = "INSERT INTO Personel (UserName, Password) VALUES (@username, @password)";
//                  sqlCom.Parameters.Add (new SqliteParameter ("@username",TitleText.Text ));
//                  sqlCom.Parameters.Add (new SqliteParameter ("@password", NotesText.Text));
//                  sqlCom.ExecuteNonQuery ();
//               }
//               sqlCon.Close ();
//
//            }
//
//         } catch (Exception ex)
//         { } 
//
//      }
//      private void UpdateData (string databaseFile)
//      {
//
//         try
//         {
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
//               if(idX.Text=="")
//               {
//                  using (SqliteCommand sqlCom = new SqliteCommand (sqlCon))
//                  {
//
//                     sqlCom.CommandText = "INSERT INTO Personel (UserName, Password) VALUES (@username, @password)";
//                     sqlCom.Parameters.Add (new SqliteParameter ("@username",TitleText.Text ));
//                     sqlCom.Parameters.Add (new SqliteParameter ("@password", NotesText.Text));
//
//
//
//
//                     sqlCom.ExecuteNonQuery ();
//
//                  }
//               }
//               if (idX.Text!=null)
//               {
//                  using (SqliteCommand sqlCom = new SqliteCommand (sqlCon)) 
//                  {
//
//                     sqlCom.CommandText = "UPDATE Personel SET UserName = @username , Password = @pass WHERE ID = @id";
//                     sqlCom.Parameters.Add (new SqliteParameter ("@username", TitleText.Text));
//                     sqlCom.Parameters.Add (new SqliteParameter ("@pass", NotesText.Text));
//
//                     sqlCom.Parameters.Add (new SqliteParameter ("@id",currentTask.Id));
//
//                     sqlCom.ExecuteNonQuery ();
//
//                  }
//                  //end using sqlCom
//
//                  sqlCon.Close ();
//
//               }
//            }
//
//            //end using sqlCon
//
//
//         } catch (Exception ex) 
//         {
//
//
//         }
//         //end try catch
//
//
//      }//end void UpdateData
//
//
//
//      private void DeleteData (string databaseFile)
//      {
//
//         try
//         {
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
//                  sqlCom.CommandText = "DELETE FROM Personel WHERE ID = @id";
//                  sqlCom.Parameters.Add (new SqliteParameter ("@id",currentTask.Id));
//
//
//
//
//                  sqlCom.ExecuteNonQuery ();
//
//               }
//               //end using sqlCom
//
//               sqlCon.Close ();
//
//            }
//            //end using sqlCon
//
//            new UIAlertView("silindi","tamam",null,"OK",null);
//         } catch (Exception ex)
//         {
//
//            new UIAlertView("hata",ex.Message,null,"OK",null);
//
//         }//end try catch
//
//      }//end void InsertData
//
//      public void SetTask (SubeViewListController d, TaskX task) 
//      {
//         Delegate = d;
//         currentTask = task;
//      }
//      public override void ViewWillAppear (bool animated)
//      {
//         base.ViewWillAppear (animated);
//         TitleText.Text = currentTask.Name;
//         NotesText.Text = currentTask.Notes;
//         DoneSwitch.On = currentTask.Done;
//         idX.Text = TitleText.Text;
//
//
//      }
//
//
//   }
//}


using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Mono.Data.Sqlcipher;
using System.IO;

namespace StoryboardTables
{
   public partial class SubeVerileriTaskControllerList : UITableViewController
   {
      TaskX currentTask {get;set;}
      public SubeViewListController Delegate {get;set;}
      public cryptViewList CryptDelegate {get;set;}


      public SubeVerileriTaskControllerList (IntPtr handle) : base (handle)
      {
      }

      public override void ViewDidLoad ()
      {
         string SQLitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "cryptedDb.db3");

         base.ViewDidLoad();

         SaveButton.TouchUpInside += (sender, e) =>
         {
            currentTask.Name = TitleText.Text;
            currentTask.Notes = NotesText.Text;
            currentTask.Done = DoneSwitch.On;


            CryptDelegate.SaveTask(currentTask);

            UpdateData(SQLitePath);
         };

         DeleteButton.TouchUpInside += (sender, e) =>
         {
            CryptDelegate.DeleteTask(currentTask);

            DeleteData(SQLitePath);
         };
      }
      private void CreateData (string databaseFile)
      {
         try
         {
            if (!File.Exists (databaseFile))
            {
               return;
            }
            using (SqliteConnection sqlCon = new SqliteConnection (String.Format ("Data Source = {0}", databaseFile)))
            {
               sqlCon.SetPassword("haluk");

               sqlCon.Open ();


               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon))
               {
                  sqlCom.CommandText = "INSERT INTO Personel (UserName, Password) VALUES (@username, @password)";
                  sqlCom.Parameters.Add (new SqliteParameter ("@username",TitleText.Text ));
                  sqlCom.Parameters.Add (new SqliteParameter ("@password", NotesText.Text));
                  sqlCom.ExecuteNonQuery ();
               }
               sqlCon.Close ();

            }

         } catch (Exception ex)
         { } 

      }
      private void UpdateData (string databaseFile)
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
               sqlCon.SetPassword("haluk");

               sqlCon.Open ();

               if(idX.Text=="")
               {
                  using (SqliteCommand sqlCom = new SqliteCommand (sqlCon))
                  {

                     sqlCom.CommandText = "INSERT INTO Personel (UserName, Password) VALUES (@username, @password)";
                     sqlCom.Parameters.Add (new SqliteParameter ("@username",TitleText.Text ));
                     sqlCom.Parameters.Add (new SqliteParameter ("@password", NotesText.Text));




                     sqlCom.ExecuteNonQuery ();

                  }
               }
               if (idX.Text!=null)
               {
                  using (SqliteCommand sqlCom = new SqliteCommand (sqlCon)) 
                  {

                     sqlCom.CommandText = "UPDATE Personel SET UserName = @username , Password = @pass WHERE ID = @id";
                     sqlCom.Parameters.Add (new SqliteParameter ("@username", TitleText.Text));
                     sqlCom.Parameters.Add (new SqliteParameter ("@pass", NotesText.Text));

                     sqlCom.Parameters.Add (new SqliteParameter ("@id",currentTask.Id));

                     sqlCom.ExecuteNonQuery ();

                  }
                  //end using sqlCom

                  sqlCon.Close ();

               }
            }

            //end using sqlCon


         } catch (Exception ex) 
         {


         }
         //end try catch


      }//end void UpdateData



      private void DeleteData (string databaseFile)
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
               sqlCon.SetPassword("haluk");

               sqlCon.Open ();

               using (SqliteCommand sqlCom = new SqliteCommand (sqlCon))
               {
                  sqlCom.CommandText = "DELETE FROM Personel WHERE ID = @id";
                  sqlCom.Parameters.Add (new SqliteParameter ("@id",currentTask.Id));




                  sqlCom.ExecuteNonQuery ();

               }
               //end using sqlCom

               sqlCon.Close ();

            }
            //end using sqlCon

            new UIAlertView("silindi","tamam",null,"OK",null);
         } catch (Exception ex)
         {

            new UIAlertView("hata",ex.Message,null,"OK",null);

         }//end try catch

      }//end void InsertData

      public void SetTask (SubeViewListController d, TaskX task) 
      {
         Delegate = d;
         currentTask = task;
      }

      public void CryptedSetTask(cryptViewList d, TaskX task) 
      {
         CryptDelegate = d;
         currentTask = task;
      }

      public override void ViewWillAppear (bool animated)
      {
         base.ViewWillAppear (animated);
         TitleText.Text = currentTask.Name;
         NotesText.Text = currentTask.Notes;
         DoneSwitch.On = currentTask.Done;
         idX.Text = TitleText.Text;


      }


   }
}
