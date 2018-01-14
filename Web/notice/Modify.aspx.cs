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
    public partial class Modify : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["fname"] != null && Request["fname"].Length > 4 && Request["id"] != null && Request["ftype"] != null)
            {
                var msg = new BLL.Message();
                var bll = new BLL.t_notice();

                var model = bll.GetModel(int.Parse(Request["id"].ToString()));
                model.notice_user_name = Session["login_name"].ToString();
                model.notice_title = Request["fname"];
                model.notice_body = Request["fbody"];
                model.notice_type = int.Parse(Request["ftype"]);
                model.notice_date = DateTime.Now;
                
                /// 写入日志
                BLL.Utils.Log(this, "修改公告:" + model.id);
                msg.Msg = bll.Update(model)?"保存成功！":"发生错误！";
                Response.Write(BLL.Utils.toJson(msg));
                Response.End();
            }
        }
    }
}