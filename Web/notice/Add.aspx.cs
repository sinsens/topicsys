using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;

namespace Topicsys.Web.notice
{
    /// <summary>
    /// 发布公告
    /// </summary>
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["fname"] != null && Request["fname"].Length > 4 && Request["ftype"] != null)
            {
                var model = new Model.t_notice
                {
                    notice_user_name = Session["login_name"].ToString(),
                    notice_title = Request["fname"],
                    notice_body = Request["fbody"],
                    notice_type = int.Parse(Request["ftype"]),
                };
                var bll = new BLL.t_notice();
                /// 权限判定
                Response.Write(bll.Add(model)?"发布成功！":"发生错误！");
                BLL.Utils.Log(this, "发布公告 " + model.notice_title);
                Response.End();
            }
        }
    }
}