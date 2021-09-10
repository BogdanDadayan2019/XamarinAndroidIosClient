﻿// This file has been autogenerated from a class added in the UI designer.

using System.Collections.Generic;
using Foundation;
using SharedProject;
using UIKit;

namespace XamarinIOS
{
    internal class ClothesDelegate : UITableViewDelegate
    {
        private SharedData<UIImage> shared = new SharedData<UIImage>();
        private _TshirtViewController tshirtviewcontroller;
        private SocsViewController socsViewController;
        private HoodieViewController hoodieViewController;
        private _CapViewController capViewController;

        public ClothesDelegate(SharedData<UIImage> shared)
        {
            this.shared.clothes = shared.clothes;
        }

        public ClothesDelegate(SharedData<UIImage> shared, _TshirtViewController tshirtviewcontroller) : this(shared)
        {
            this.tshirtviewcontroller = tshirtviewcontroller;
        }

        public ClothesDelegate(SharedData<UIImage> shared, SocsViewController socsViewController) : this(shared)
        {
            this.socsViewController = socsViewController;
        }

        public ClothesDelegate(SharedData<UIImage> shared, HoodieViewController hoodieViewController) : this(shared)
        {
            this.hoodieViewController = hoodieViewController;
        }

        public ClothesDelegate(SharedData<UIImage> shared, _CapViewController capViewController) : this(shared)
        {
            this.capViewController = capViewController;
        }

        [Export("tableView:editActionsForRowAtIndexPath:")]
        public UITableViewRowAction[] EditActionsForRow(UITableView tableView, NSIndexPath indexPath)
        {
            var action = UITableViewRowAction.Create(UITableViewRowActionStyle.Default, "delete", (arg1, arg2) =>
            {

                var selected = shared.clothes[indexPath.Row];

                shared.clothes.Remove(selected);

                tableView.ReloadData();
            });

            var action1 = UITableViewRowAction.Create(UITableViewRowActionStyle.Normal, "change", (arg1, arg2) =>
            {
                UIAlertController alert = UIAlertController.Create("Alert", "Change", UIAlertControllerStyle.Alert);
                UITextField field = null;


                alert.AddTextField((textField) =>
                {

                    field = textField;

                    var selected = shared.clothes[indexPath.Row];


                    field.Placeholder = "placeholder";
                    field.Text = selected.NameClothes;
                    field.AutocorrectionType = UITextAutocorrectionType.No;
                    field.KeyboardType = UIKeyboardType.Default;
                    field.ReturnKeyType = UIReturnKeyType.Done;
                    field.ClearButtonMode = UITextFieldViewMode.WhileEditing;

                });


                alert.AddAction(UIAlertAction.Create("Cancel", UIAlertActionStyle.Cancel, (actionCancel) =>
                {


                }));

                alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, (actionOK) =>
                {
                    var selected = shared.clothes[indexPath.Row];
                    selected.NameClothes = field.Text;
                    tableView.ReloadData();

                }));

                if (tshirtviewcontroller != null)
                {
                    tshirtviewcontroller.PresentViewController(alert, true, null);
                } else if (hoodieViewController != null)
                {
                    hoodieViewController.PresentViewController(alert, true, null);
                } else if (capViewController != null)
                {
                    capViewController.PresentViewController(alert, true, null);
                } else
                {
                    socsViewController.PresentViewController(alert, true, null);
                }


            });


            return new UITableViewRowAction[] { action, action1 };

        }
    }
}
