// Authors:
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
using System.Windows;

using FigmaSharp.Converters;
using FigmaSharp.Models;
using FigmaSharp.Views;
using FigmaSharp.Services;
using FigmaSharp.Views.Wpf;
using System.Windows.Controls;
using System.Text;
using System.Diagnostics;

namespace FigmaSharp.Wpf.Converters
{
    /// <summary>
    /// 뷰레이아웃을 생성합니다.
    /// </summary>
    public class FrameConverter : FrameConverterBase
    {
        public override Type GetControlType(FigmaNode currentNode) => typeof(CanvasImage);

        public override IView ConvertToView(FigmaNode currentNode, ViewNode parent, ViewRenderService rendererService)
        {
            IView view;
            if (rendererService.NodeProvider.RendersAsImage(currentNode))
                view = new ImageView();
            else
                view = new View();

            var currengroupView = view.NativeObject as FrameworkElement;
            var figmaFrameEntity = (FigmaFrame)currentNode;
            currengroupView.Configure(currentNode);


           currengroupView.Opacity = figmaFrameEntity.opacity;

            // 프레임 노드에 있는 설정 처리
            if (figmaFrameEntity.HasFills)
            {
                Debug.WriteLine("프레임노드" + figmaFrameEntity.GetClassName());
                Debug.WriteLine(string.Format("{0} {1}", figmaFrameEntity.type, figmaFrameEntity.name));
                foreach (var fill in figmaFrameEntity.fills)
                {
                    if (fill.type == "IMAGE")
                    {
                        //we need to add this to our service
                    }
                    else if (fill.type == "SOLID")
                    {
                        if (fill.visible)
                        {
                           //((UserControl)currengroupView).Background = fill.color.ToColor();
                        }
                    }
                    else
                    {
                        Console.WriteLine($"NOT IMPLEMENTED FILL : {fill.type}");
                    }
                    //currengroupView.Layer.Hidden = !fill.visible;
                }
            }

            // 프레임 노드 하위에 있는 객체 처리
            foreach (FigmaNode node in figmaFrameEntity.children)
            {
                Debug.WriteLine("서브노드" + node.GetClassName());
                Debug.WriteLine(string.Format("{0} {1}", node.type, node.name));
                
            }
            //
            return view;
        }

        public override string ConvertToCode(CodeNode currentNode, CodeNode parentNode, CodeRenderService rendererService)
        {
            var FigmaFrame = (FigmaFrame)currentNode.Node;
            StringBuilder builder = new StringBuilder();

            var name = Resources.Ids.Conversion.NameIdentifier;

            
            return builder.ToString();
        }
    }
}
