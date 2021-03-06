﻿using Easy.MetaData;
using Easy.Models;

namespace Easy.Web.CMS.Setting
{
    [DataConfigure(typeof(ApplicationSettingMedaData))]
    public class ApplicationSetting : EditorEntity
    {
        public string SettingKey { get; set; }
        public string Value { get; set; }
    }

    class ApplicationSettingMedaData : DataViewMetaData<ApplicationSetting>
    {

        protected override void DataConfigure()
        {
            DataTable("ApplicationSetting");
            DataConfig(m => m.SettingKey).AsPrimaryKey();
        }

        protected override void ViewConfigure()
        {
            
        }
    }
}