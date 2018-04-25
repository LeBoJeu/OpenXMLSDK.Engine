﻿using System;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using MvvX.Plugins.OpenXMLSDK.Word.ReportEngine.BatchModels;
using MvvX.Plugins.OpenXMLSDK.Word.ReportEngine.Models;

namespace MvvX.Plugins.OpenXMLSDK.Platform.Word.ReportEngine
{
    public static class HyperlinkExtensions
    {
        /// <summary>
        /// Render a hyperlink.
        /// </summary>
        /// <param name="hyperlink"></param>
        /// <param name="parent"></param>
        /// <param name="context"></param>
        /// <param name="documentPart"></param>
        /// <param name="formatProvider"></param>
        /// <returns></returns>
        public static OpenXmlElement Render(this Hyperlink hyperlink, OpenXmlElement parent, ContextModel context, OpenXmlPart documentPart, IFormatProvider formatProvider)
        {
            context.ReplaceItem(hyperlink, formatProvider);

            if (hyperlink.Show)
            {
                DocumentFormat.OpenXml.Wordprocessing.Hyperlink fieldCodeXmlelement = new DocumentFormat.OpenXml.Wordprocessing.Hyperlink();
                fieldCodeXmlelement.Anchor = hyperlink.Anchor;

                parent.AppendChild(fieldCodeXmlelement);

                hyperlink.Text.Render(fieldCodeXmlelement, context, documentPart, formatProvider);

                return fieldCodeXmlelement;
            }

            return null;
        }
    }
}
