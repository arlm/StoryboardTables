// //HalukYILMAZ IDB Genel Müdürlüğü İçin Hazırlamıştır
using System;
using System.Linq;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Dialog;
using MonoTouch.Foundation;
using MonoTouch.EventKit;

namespace takvimProjesi
{
   public class EventListController : DialogViewController
   {

      protected RootElement itemListRoot = new RootElement ( "Calendar/Reminder Items" );
      protected EKCalendarItem[] events;
      protected EKEntityType eventType;


      public EventListController ( EKCalendarItem[] events, EKEntityType eventType )
         : base ( UITableViewStyle.Plain, null, true)      {

         this.events = events;
         this.eventType = eventType;

         Section section;
         if (events == null) {
            section = new Section () { new StringElement ("No calendar events") };
         } else {
            section = new Section () { 
               from items in this.events
               select ( Element ) new StringElement ( items.Title )
            };
         } 
         itemListRoot.Add (section);
         // set our element root
         this.InvokeOnMainThread ( () => { this.Root = itemListRoot; } ); 
      }
   }
}
