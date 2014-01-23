using System;
using System.Collections.Generic;
using System.IO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace StoryboardTables {
	public class RootTableSource : UITableViewSource {
		// there is NO database or storage of Tasks in this example, just an in-memory List<>
      TaskX[] tableItems;
	    string cellIdentifier = "taskcell";
	 
      public RootTableSource (TaskX[] items)
		{
			tableItems = items; 
		}
	    
	    public override int RowsInSection (UITableView tableview, int section)
	    {
	        return tableItems.Length;
	    }
	    public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
	    {
			// in a Storyboard, Dequeue will ALWAYS return a cell, 
	        UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier);
	        cell.TextLabel.Text = tableItems[indexPath.Row].Name;
			
			if (tableItems[indexPath.Row].Done) 
				cell.Accessory = UITableViewCellAccessory.Checkmark;
			else
				cell.Accessory = UITableViewCellAccessory.None;

	        return cell;
	    }

      public TaskX GetItem(int id) {
			return tableItems[id];
		}
	}


}