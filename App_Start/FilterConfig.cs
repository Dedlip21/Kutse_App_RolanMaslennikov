﻿using System.Web;
using System.Web.Mvc;

namespace Kutse_App_RolanMaslennikov
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
