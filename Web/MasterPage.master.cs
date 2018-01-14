using System;
using System.Collections.Generic;

namespace Topicsys.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            ///判断登录
            if (Session["login_name"] == null)
            {
                Response.Write("请先<a href='/'>登录</a>");
                Response.End();
            }
            var url = Request.Url.AbsoluteUri.ToLower();
            /// 权限判定

            switch (Session["type"].ToString())
            {
                case "student":
                    /// 学生禁止访问
                    var deny3 = new List<string>() { "dist", "topic", "notice", "log", "major", "teacher", "student", "admin", "dept", "allocate", "ResetPassword", "audit" };
                    foreach (var item in deny3)
                    {
                        url = url.Replace(item.ToLower(), "");
                    }

                    break;

                case "teacher":
                    /// 导师禁止访问
                    var deny2 = new List<string>() { "dist", "notice", "log", "major", "teacher", "student", "admin", "dept", "allocate", "ResetPassword" };
                    foreach (var item in deny2)
                    {
                        url = url.Replace(item.ToLower(), "");
                    }
                    break;
            }
            /// 权限提示
            if (!url.Equals(Request.Url.AbsoluteUri.ToLower()))
            {
                Response.Write("无权访问该模块！");
                Response.End();
            }
        }
    }
}