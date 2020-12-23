using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigmaSharp.Views.Wpf.ViewWrappers
{
    public class ImageButton : Button, IImageButton
    {
        //public ImageButton()
        //{
        //    Text = "";
        //}

        //public ImageButton(Button button) : base(button)
        //{

        //}
    }

    public class Button : View, IButton
    {
        //public event EventHandler Clicked;

        //Button button;

        //public bool Border { get => button.Border; set => button.Border = value; }

        //public Button() : this(new Button())
        //{

        //}

        //public Button(Button button) : base(button)
        //{
        //    this.button = button;
        //    this.button.TranslatesAutoresizingMaskIntoConstraints = false;
        //    this.button.Activated += Button_Activated;
        //}

        //private void Button_Activated(object sender, EventArgs e)
        //{
        //    Clicked?.Invoke(this, EventArgs.Empty);
        //}

        //IImage image;
        //public IImage Image
        //{
        //    get => image;
        //    set
        //    {
        //        this.image = value;
        //        button.Image = value.NativeObject as NSImage;
        //    }
        //}

        //public string Text
        //{
        //    get => button.Title;
        //    set
        //    {
        //        button.Title = value ?? "";
        //    }
        //}

        //public bool Enabled
        //{
        //    get => button.Enabled;
        //    set => button.Enabled = value;
        //}

        //public override void Dispose()
        //{
        //    this.button.Activated -= Button_Activated;
        //    base.Dispose();
        //}
        public bool Border { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Text { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IImage Image { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event EventHandler Clicked;
    }
}
