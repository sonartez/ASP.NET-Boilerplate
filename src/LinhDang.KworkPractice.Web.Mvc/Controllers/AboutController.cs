﻿using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using LinhDang.KworkPractice.Controllers;

namespace LinhDang.KworkPractice.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : KworkPracticeControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
