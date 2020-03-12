/*
This file was auto-generated using
FigmaSharp 1.0.0.0 and Figma API 1.0.1 on 2020-03-12 at 03:52

Document title:   
Document version: 0.1f
Document Namespace:   FigmaSharp
Document URL:     FwVa4JS5QsohRhNEnEBKslFk

Changes to this file may cause incorrect behavior
and will be lost if the code is regenerated.
* 
*/
using AppKit;
namespace MonoDevelop.Figma.FigmaBundles
{
	partial class BundleUpdateWindow
	{
		NSButton updateButton, cancelButton;
		NSProgressIndicator versionSpinner;
		NSPopUpButton versionComboBox, bundlePopUp;

		private void InitializeComponent ()
		{
			this.StyleMask |= NSWindowStyle.Closable;
			this.StyleMask |= NSWindowStyle.Resizable;
			this.Title = "Update Figma Bundle";
			var frame = Frame;
			frame.Size = new CoreGraphics.CGSize (455f,171f);
			this.SetFrame (frame,true);
			
			// View:     updateButton
			// NodeName: "updateButton"
			// NodeType: INSTANCE
			// NodeId:   775:30
			
			updateButton = new AppKit.NSButton();
			updateButton.WantsLayer = true;
			updateButton.BezelStyle = NSBezelStyle.Rounded;
			updateButton.ControlSize = NSControlSize.Regular;
			updateButton.Title = "Update";
			updateButton.KeyEquivalent = "\r";
			updateButton.AccessibilityTitle = "Bundle";
			updateButton.AccessibilityHelp = "Starts bundling the document";
			
			
			this.ContentView.AddSubview (updateButton);
			updateButton.Frame = updateButton.GetFrameForAlignmentRect (new CoreGraphics.CGRect (352f,20f,84f,21f));;
			
			
			// View:     cancelButton
			// NodeName: "cancelButton"
			// NodeType: INSTANCE
			// NodeId:   775:45
			
			cancelButton = new AppKit.NSButton();
			cancelButton.WantsLayer = true;
			cancelButton.BezelStyle = NSBezelStyle.Rounded;
			cancelButton.ControlSize = NSControlSize.Regular;
			cancelButton.Title = "Cancel";
			cancelButton.AccessibilityTitle = "Cancel";
			cancelButton.AccessibilityHelp = "Cancel bundling";
			
			
			this.ContentView.AddSubview (cancelButton);
			cancelButton.Frame = cancelButton.GetFrameForAlignmentRect (new CoreGraphics.CGRect (257f,20f,84f,21f));;
			
			
			// View:     versionSpinner
			// NodeName: "versionSpinner"
			// NodeType: INSTANCE
			// NodeId:   772:40
			
			versionSpinner = new AppKit.NSProgressIndicator();
			versionSpinner.WantsLayer = true;
			versionSpinner.Style = NSProgressIndicatorStyle.Spinning;
			versionSpinner.Hidden = true;
			versionSpinner.ControlSize = NSControlSize.Small;
			
			this.ContentView.AddSubview (versionSpinner);
			versionSpinner.Frame = versionSpinner.GetFrameForAlignmentRect (new CoreGraphics.CGRect (383f,72f,18f,18f));;
			
			
			// View:     nativeViewCodeServiceView
			// NodeName: Generate:
			// NodeType: INSTANCE
			// NodeId:   772:120
			
			var nativeViewCodeServiceView = new AppKit.NSTextField() {    StringValue = "Figma Bundle:",
			Editable = false,
			Bordered = false,
			Bezeled = false,
			DrawsBackground = false,
			Alignment = NSTextAlignment.Left,
			};
			nativeViewCodeServiceView.WantsLayer = true;
			nativeViewCodeServiceView.Alignment = NSTextAlignment.Right;
			
			this.ContentView.AddSubview (nativeViewCodeServiceView);
			nativeViewCodeServiceView.Frame = nativeViewCodeServiceView.GetFrameForAlignmentRect (new CoreGraphics.CGRect (8f,104f,142f,20f));;
			
			
			// View:     nativeViewCodeServiceView1
			// NodeName: Generate:
			// NodeType: INSTANCE
			// NodeId:   772:124
			
			var nativeViewCodeServiceView1 = new AppKit.NSTextField() {    StringValue = "Update to:",
			Editable = false,
			Bordered = false,
			Bezeled = false,
			DrawsBackground = false,
			Alignment = NSTextAlignment.Left,
			};
			nativeViewCodeServiceView1.WantsLayer = true;
			nativeViewCodeServiceView1.Alignment = NSTextAlignment.Right;
			
			this.ContentView.AddSubview (nativeViewCodeServiceView1);
			nativeViewCodeServiceView1.Frame = nativeViewCodeServiceView1.GetFrameForAlignmentRect (new CoreGraphics.CGRect (8f,71f,142f,20f));;
			
			
			// View:     bundlePopUp
			// NodeName: "bundlePopUp"
			// NodeType: INSTANCE
			// NodeId:   765:0
			
			bundlePopUp = new AppKit.NSPopUpButton();
			bundlePopUp.WantsLayer = true;
			bundlePopUp.BezelStyle = NSBezelStyle.Rounded;
			bundlePopUp.ControlSize = NSControlSize.Regular;
			bundlePopUp.AddItem ("Breakpoints Dialog");
			
			this.ContentView.AddSubview (bundlePopUp);
			bundlePopUp.Frame = bundlePopUp.GetFrameForAlignmentRect (new CoreGraphics.CGRect (154f,103f,223f,21f));;
			
			
			// View:     versionPopUp
			// NodeName: "versionPopUp"
			// NodeType: INSTANCE
			// NodeId:   765:58
			
			versionComboBox = new AppKit.NSPopUpButton();
			versionComboBox.WantsLayer = true;
			versionComboBox.BezelStyle = NSBezelStyle.Rounded;
			versionComboBox.ControlSize = NSControlSize.Regular;
			versionComboBox.AddItem ("Current – 8.6");
			
			this.ContentView.AddSubview (versionComboBox);
			versionComboBox.Frame = versionComboBox.GetFrameForAlignmentRect (new CoreGraphics.CGRect (154f,70f,223f,21f));;
			
		}
	}
}
