// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace BillSplitter {
	
	
	// Base type probably should be MonoTouch.Foundation.NSObject or subclass
	[MonoTouch.Foundation.Register("AppDelegate")]
	public partial class AppDelegate {
		
		[MonoTouch.Foundation.Connect("window")]
		protected MonoTouch.UIKit.UIWindow window {
			get {
				return ((MonoTouch.UIKit.UIWindow)(this.GetNativeField("window")));
			}
			set {
				this.SetNativeField("window", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("pickerPax")]
		protected MonoTouch.UIKit.UIPickerView pickerPax {
			get {
				return ((MonoTouch.UIKit.UIPickerView)(this.GetNativeField("pickerPax")));
			}
			set {
				this.SetNativeField("pickerPax", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("textfieldTotal")]
		protected MonoTouch.UIKit.UITextField textfieldTotal {
			get {
				return ((MonoTouch.UIKit.UITextField)(this.GetNativeField("textfieldTotal")));
			}
			set {
				this.SetNativeField("textfieldTotal", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("labelSplit")]
		protected MonoTouch.UIKit.UILabel labelSplit {
			get {
				return ((MonoTouch.UIKit.UILabel)(this.GetNativeField("labelSplit")));
			}
			set {
				this.SetNativeField("labelSplit", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("buttonSplit")]
		protected MonoTouch.UIKit.UIButton buttonSplit {
			get {
				return ((MonoTouch.UIKit.UIButton)(this.GetNativeField("buttonSplit")));
			}
			set {
				this.SetNativeField("buttonSplit", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("textfieldWine")]
		protected MonoTouch.UIKit.UITextField textfieldWine {
			get {
				return ((MonoTouch.UIKit.UITextField)(this.GetNativeField("textfieldWine")));
			}
			set {
				this.SetNativeField("textfieldWine", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("labelSplit2")]
		protected MonoTouch.UIKit.UILabel labelSplit2 {
			get {
				return ((MonoTouch.UIKit.UILabel)(this.GetNativeField("labelSplit2")));
			}
			set {
				this.SetNativeField("labelSplit2", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("background")]
		protected MonoTouch.UIKit.UIButton background {
			get {
				return ((MonoTouch.UIKit.UIButton)(this.GetNativeField("background")));
			}
			set {
				this.SetNativeField("background", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("labelTotal")]
		protected MonoTouch.UIKit.UILabel labelTotal {
			get {
				return ((MonoTouch.UIKit.UILabel)(this.GetNativeField("labelTotal")));
			}
			set {
				this.SetNativeField("labelTotal", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("labelDrinkers")]
		protected MonoTouch.UIKit.UILabel labelDrinkers {
			get {
				return ((MonoTouch.UIKit.UILabel)(this.GetNativeField("labelDrinkers")));
			}
			set {
				this.SetNativeField("labelDrinkers", value);
			}
		}
		
		[MonoTouch.Foundation.Connect("labelNonDrinkers")]
		protected MonoTouch.UIKit.UILabel labelNonDrinkers {
			get {
				return ((MonoTouch.UIKit.UILabel)(this.GetNativeField("labelNonDrinkers")));
			}
			set {
				this.SetNativeField("labelNonDrinkers", value);
			}
		}
	}
}