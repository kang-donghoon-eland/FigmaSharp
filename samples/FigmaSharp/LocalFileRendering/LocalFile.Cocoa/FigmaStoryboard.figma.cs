﻿using System;
using FigmaSharp;

namespace LocalFile.Shared
{
    public class FigmaStoryboard : FigmaFile
	{
        public FigmaStoryboard(ViewConverter[] figmaViewConverters = null, ViewPropertyNodeConfigureBase propertySetter = null) : base ("FigmaStoryboard.figma", figmaViewConverters, propertySetter)
        {
            InitializeComponent();
        }
	}
}
