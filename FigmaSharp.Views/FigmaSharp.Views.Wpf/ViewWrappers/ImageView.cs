﻿// Authors:
//   Jose Medrano <josmed@microsoft.com>
//
// Copyright (C) 2018 Microsoft, Corp
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to permit
// persons to whom the Software is furnished to do so, subject to the
// following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
// OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN
// NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR
// OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE
// USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Windows.Controls;
using System.Windows.Media;

using FigmaSharp.Models;
using FigmaSharp.Views; 

namespace FigmaSharp.Views.Wpf
{
    public class ImageView : View, IImageView
    {
        readonly System.Windows.Controls.Image imageView;
         
        public ImageView(System.Windows.Controls.Image imageView) : base(imageView)
        {
        }

        public ImageView() : this(new System.Windows.Controls.Image())
        {
            imageView = new System.Windows.Controls.Image();
        }

        IImage image;
        public IImage Image 
        {
            get => image;
            set
            {
                image = value;
                var nativeImage = (ImageSource)Image.NativeObject;
                imageView.Source = nativeImage;
                imageView.Width = 100;
                imageView.Height = 100;
            }
        }
    }
}
