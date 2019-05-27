﻿using System.Collections.Generic;
using FigmaSharp;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace FigmaSharp.Services
{
    public class FigmaViewRendererDistributionService
    {
        public ProcessedNode[] MainViews { get; private set; }
        protected FigmaViewRendererService figmaFileService;

        public FigmaViewRendererDistributionService(FigmaViewRendererService figmaFileService)
        {
            this.figmaFileService = figmaFileService;
        }

        public void Start ()
        {
            var mainNodes = figmaFileService.NodesProcessed.Where(s => s.ParentView == null)
                .ToArray();

            MainViews = new ProcessedNode[mainNodes.Length];

            for (int i = 0; i < mainNodes.Length; i++)
            {
                MainViews[i] = mainNodes[i];
                Recursively(mainNodes[i]);
            }

            //loading views
            Task.Run(() =>
            {
                foreach (var vector in figmaFileService.ImageVectors)
                {
                    var processedNode = figmaFileService.NodesProcessed.FirstOrDefault(s => s.FigmaNode == vector.Key);
                    if (!string.IsNullOrEmpty(vector.Value))
                    {
                        var image = AppContext.Current.GetImage(vector.Value);
                        var wrapper = processedNode.View as IImageViewWrapper;

						AppContext.Current.BeginInvoke (() => {
							try {
							    wrapper.SetImage (image);
							} catch (Exception ex) {
								Console.WriteLine (ex);
							}
						});
                    }
                }
            });
        }

        void Recursively(ProcessedNode parentNode)
        {
            var children = figmaFileService.NodesProcessed.Where(s => s.ParentView == parentNode);
            foreach (var child in children)
            {
                if (child.FigmaNode is IAbsoluteBoundingBox absoluteBounding && parentNode.FigmaNode is IAbsoluteBoundingBox parentAbsoluteBoundingBox)
                {
                    parentNode.View.AddChild(child.View);

                    var x = absoluteBounding.absoluteBoundingBox.x -  parentAbsoluteBoundingBox.absoluteBoundingBox.x;
                    float y;
                    if (AppContext.Current.IsYAxisFlipped)
                    {
                        var parentY = parentAbsoluteBoundingBox.absoluteBoundingBox.y + parentAbsoluteBoundingBox.absoluteBoundingBox.height;
                        var actualY = absoluteBounding.absoluteBoundingBox.y + absoluteBounding.absoluteBoundingBox.height;
                        y = parentY - actualY;
                    }
                    else
                    {
                        y = absoluteBounding.absoluteBoundingBox.y - parentAbsoluteBoundingBox.absoluteBoundingBox.y;
                    }

                    child.View.SetPosition(x, y);
                }

                Recursively(child);
            }
        }
    }
}