﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easy.Web.CMS
{
    public class PermissionDescriptor
    {
        public PermissionDescriptor()
        {

        }
        public PermissionDescriptor(string key,string module,string title,string description)
        {
            Key = key;
            Module = module;
            Title = title;
            Description = description;
        }
        public string Key { get; set; }
        public string Module { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool? Checked { get; set; }
    }
}
