	
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace BillSplitter
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	// The name AppDelegate is referenced in the MainWindow.xib file.
	public partial class AppDelegate : UIApplicationDelegate
	{
	
		private int drinkers=0;
		private int nondrinkers=0;
		public int Drinkers {get {return drinkers;}
			set{
				drinkers = value; 
				if (drinkers > 0)
					labelDrinkers.Text = drinkers + " drinkers owe";
				else
					labelDrinkers.Text = "Drinkers owe";
				Calculate();
				UpdateButton();}
		}
		public int NonDrinkers {get {return nondrinkers;}
			set{
				nondrinkers = value; 
				if (nondrinkers > 0)
					labelNonDrinkers.Text = nondrinkers + " non-drinkers";
				else
					labelNonDrinkers.Text = "Non-drinkers";
				Calculate();
				UpdateButton();}
		}
		// This method is invoked when the application has loaded its UI and its ready to run
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			// If you have defined a view, add it here:
			// window.AddSubview (navigationController.View);

			CreatePicker ();
			textfieldTotal.Ended += delegate {
				Console.WriteLine("textfieldTotal.Ended");
				textfieldTotal.ResignFirstResponder();	
			};
			textfieldWine.Ended += delegate {
				Console.WriteLine("textfieldWine.Ended");
				textfieldWine.ResignFirstResponder();	
			};
			textfieldTotal.EditingDidEnd += delegate(object sender, EventArgs e) {
				Console.WriteLine("textfieldTotal.EditingDidEnd");
				UITextField tf = sender as UITextField;
				tf.ResignFirstResponder();
			};
			textfieldWine.EditingDidEnd += delegate(object sender, EventArgs e) {
				Console.WriteLine("textfieldWine.EditingDidEnd");
				UITextField tf = sender as UITextField;
				tf.ResignFirstResponder();	
			};
			background.TouchDown += delegate {
				Console.WriteLine("background.TouchDown");
				textfieldTotal.ResignFirstResponder();
				textfieldWine.ResignFirstResponder();
			};
			buttonSplit.TouchDown += delegate {
				Console.WriteLine("buttonSplit.TouchDown");
				textfieldTotal.ResignFirstResponder();
				textfieldWine.ResignFirstResponder();
				Calculate();
			};
			textfieldTotal.ValueChanged += delegate {
				Console.WriteLine("textfieldTotal.ValueChanged");
				Calculate();
			};
			textfieldTotal.EditingDidEnd += delegate {
				Console.WriteLine("textfieldTotal.EditingDidEnd");
				textfieldTotal.ResignFirstResponder();
				Calculate();
			};
				
			window.MakeKeyAndVisible ();

			return true;
		}

		private void UpdateButton()
		{
			int pax = drinkers + nondrinkers;
			if (pax > 0)
			{
				buttonSplit.TitleLabel.Text = String.Format("Split {0} ways", pax);
				buttonSplit.TitleLabel.SizeToFit();
			}
			else
				buttonSplit.TitleLabel.Text = "Split";
		}
		
		private void Calculate()
		{
			decimal total = 0.0m;
			decimal wine = 0.0m;
			
			int pax = drinkers + nondrinkers;
			
			labelSplit.Text = "-";
			labelSplit2.Text = "-";
			if (pax > 0)
			{
				string totalText = textfieldTotal.Text==""?"0":textfieldTotal.Text;
				string wineText = textfieldWine.Text==""?"0":textfieldWine.Text;
				
				if (decimal.TryParse(totalText, out total))
				{					
					if (decimal.TryParse(wineText, out wine))
					{
						decimal foodeach = (total - wine) / pax;
						if (foodeach > 0)
						{
							labelTotal.Text = "$ " + total.ToString("#.00");
							if (drinkers > 0)
							{
								labelSplit.Text = (foodeach + wine/drinkers).ToString("#.00");
							}
							else
							{  // if no drinkers, add the wine back into the bill
								foodeach = (total) / pax;
							}
							
							if (nondrinkers > 0)
							{
								labelSplit2.Text = (foodeach/nondrinkers).ToString("#.00");
							}
						}
						else Console.WriteLine("cannot be negative " + foodeach);
					}
				}	
			}
			
		}
		
		
		
		// This method is required in iPhoneOS 3.0
		public override void OnActivated (UIApplication application)
		{
		}
		
		
		
		
		
		#region People picker
		
		void CreatePicker ()
		{
			pickerPax.Model = new PeopleModel(this);
		}
			
		public class PeopleModel : UIPickerViewModel {
			static string [] names = new string [] {
				"0 drinkers",
				"1 drinker",
				"2 drinkers","3 drinkers","4 drinkers","5 drinkers","6 drinkers","7 drinkers","8 drinkers"
			};
			static string [] names2 = new string [] {
				"0 non-drinkers",
				"1 non-drinker",
				"2 non-drinkers","3 non-drinkers","4 non-drinkers","5 non-drinkers","6 non-drinkers","7 non-drinkers","8 non-drinkers"
			};
	
			AppDelegate pvc;
			public PeopleModel (AppDelegate pvc) {
				this.pvc = pvc;
			}
			
			public override int GetComponentCount (UIPickerView v)
			{
				return 2;
			}
	
			public override int GetRowsInComponent (UIPickerView pickerView, int component)
			{
				if (component == 0)
					return names.Length;
				else
					return names2.Length;
			}
	
			public override string GetTitle (UIPickerView picker, int row, int component)
			{
				if (component == 0)
					return names [row];
				else
					return names2[row];
			}
	
			public override void Selected (UIPickerView picker, int row, int component)
			{
				Console.WriteLine("picker changed" + row + " in " + component);
				if (component == 0)
					pvc.Drinkers = row;
				else
					pvc.NonDrinkers = row;
			}
			
			public override float GetComponentWidth (UIPickerView picker, int component)
			{
				if (component == 0)
					return 130f;
				else
					return 150f;
			}
	
			public override float GetRowHeight (UIPickerView picker, int component)
			{
				return 40f;
			}
		}
		#endregion
	}
}