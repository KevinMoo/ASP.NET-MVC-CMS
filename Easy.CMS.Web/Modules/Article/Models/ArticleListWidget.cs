﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Easy.Web.CMS.Widget;
using Easy.MetaData;
using Easy.Web.CMS.MetaData;
using Easy.CMS.Article.Service;
using Easy.Extend;
using Easy.Web.CMS;
using Easy.Web.CMS.Article.Service;
using Microsoft.Practices.ServiceLocation;

namespace Easy.CMS.Article.Models
{
    [DataConfigure(typeof(ArticleListWidgetMeta))]
    public class ArticleListWidget : WidgetBase
    {
        public int ArticleTypeID { get; set; }
        public string DetailPageUrl { get; set; }
        public bool IsPageable { get; set; }
        public int? PageSize { get; set; }
    }
    class ArticleListWidgetMeta : WidgetMetaData<ArticleListWidget>
    {
        protected override void ViewConfigure()
        {
            base.ViewConfigure();
            var articleTypeService = ServiceLocator.Current.GetInstance<IArticleTypeService>();
            ViewConfig(m => m.ArticleTypeID).AsDropDownList().Order(NextOrder()).DataSource(articleTypeService.Get().ToDictionary(m => m.ID.ToString(), m => m.Title)).Required();
            ViewConfig(m => m.DetailPageUrl).AsTextBox().Order(NextOrder()).AddClass("select").AddProperty("data-url", Urls.SelectPage);

            ViewConfig(m => m.PartialView).AsDropDownList().Order(NextOrder()).DataSource(() =>
            {
                var path = (ServiceLocator.Current.GetInstance<IApplicationContext>() as CMSApplicationContext).MapPath("~/Modules/Article/Views");
                Dictionary<string, string> templates = new Dictionary<string, string>();
                Directory.GetFiles(path, "Widget.ArticleList*.cshtml").Each(f =>
                {
                    string fileName = Path.GetFileNameWithoutExtension(f);
                    templates.Add(fileName, fileName.Replace("Widget.", ""));

                });
                return templates;
            });
        }
    }

}