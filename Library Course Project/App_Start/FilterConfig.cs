﻿using System.Web;
using System.Web.Mvc;

namespace Library_Course_Project
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
