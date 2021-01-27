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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FigmaSharp.Models;
using FigmaSharp.Services;
using FigmaSharp.Views;
using FigmaSharp.Views.Wpf;
using FigmaSharp.Wpf.Converters;

namespace BasicRendering.Wpf
{
    public class ExampleViewManager
    {
        const string fileName = "qVIUSmz8AkK158q8pY3L23";// https://www.figma.com/file/qVIUSmz8AkK158q8pY3L23/NicoTest?node-id=0%3A1
        //const string fileName = "N48UVj8HUdQOTxn2hfqGHgld";
        //const string fileName = "RAlQol7RzxvtYUQj24xHlZ";

        readonly NodeProvider nodeProvider;

        public string WindowTitle => nodeProvider.Response.name;

        public ExampleViewManager(IScrollView scrollView)
        {
            //we get the default basic view converters from the current loaded toolkit
            var converters = FigmaSharp.AppContext.Current.GetFigmaConverters();

            //TIP: the render consist in 2 steps:
            //1) generate all the views, decorating and calculate sizes
            //2) with this views we generate the hierarchy and position all the views based in the native toolkit positioning system

            // 팁 : 렌더링은 2 단계로 구성됩니다.
            // 1) 모든 뷰 생성, 장식 및 크기 계산
            // 2)이 뷰를 사용하여 계층 구조를 생성하고 기본 툴킷 포지셔닝 시스템을 기반으로 모든 뷰를 배치합니다.

            //in this case we want use a remote file provider (figma url from our document)
            //이 경우 원격 파일 공급자 (문서의 figma url)를 사용하고 싶습니다.
            nodeProvider = new RemoteNodeProvider();

            //we initialize our renderer service, this uses all the converters passed and generate a collection of NodesProcessed which is basically contains <FigmaModel, IView, FigmaParentModel>
            // 렌더러 서비스를 초기화합니다. 이것은 전달 된 모든 변환기를 사용하고 기본적으로 <FigmaModel, IView, FigmaParentModel>을 포함하는 NodesProcessed 컬렉션을 생성합니다.
            var rendererService = new ViewRenderService(nodeProvider, converters);
            ViewRenderServiceOptions option = new ViewRenderServiceOptions();
            option.FrameInMainViews = true;
            option.GenerateMainView = false;
            option.ScanChildrenFromFigmaInstances = true;

            rendererService.Start(fileName, scrollView, option );

            // 이제 모든 뷰가 처리되었으며 모든 뷰를 원하는 기본 뷰로 배포 할 수있는 관계가 있습니다.
            //var distributionService = new FigmaViewRendererDistributionService(rendererService);
            //distributionService.Start();

            var layoutManager = new StoryboardLayoutManager();
            

            //We want know the background color of the figma canvas and apply to our scrollview
            var canvas = nodeProvider.Nodes.OfType<FigmaCanvas>().FirstOrDefault();
            if (canvas != null)
            {
                List<View> viewNodeList = new List<View>();
                layoutManager.Run( scrollView.ContentView, rendererService);
                //scrollView.NodeName = canvas.name;
                foreach (FigmaNode frame in canvas.children)
                {
                    FrameConverter convert = new FrameConverter();
                    
                    // 정의 : 프레임은 하나의 뷰 (Page)을 가진다. 
                    // 프레임 마다 탭을 생성한다.
                    if (frame.type == "FRAME")
                    {
                        View view = convert.ConvertToView(frame, null, rendererService) as View;
                        scrollView.ContentView.AddChild(view);
                        foreach (FigmaNode instance in (frame as FigmaFrame).children)
                        {


                            // 프레임 안에 컨트롤을 표현한다.
                            System.Diagnostics.Debug.WriteLine(instance.name);
                            //var canvas = nodeProvider.Nodes.OfType<FigmaCanvas>().FirstOrDefault();

                        }
                    }
                }
            }

            //NOTE: some toolkits requires set the real size of the content of the scrollview before position layers
            scrollView.AdjustToContent();
        }
    }
}
