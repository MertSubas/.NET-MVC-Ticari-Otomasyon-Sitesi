﻿using System.Web;
using System.Web.Mvc;

namespace Online_Ticari_Otomasyon_1_MVC5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
