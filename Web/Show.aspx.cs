using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web
{
    public partial class ShowNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["id"] != null && Request["type"] != null)
            {
                var bll = new BLL.t_notice();
                try
                {
                    var notice = bll.GetModel(int.Parse(Request["id"].ToString()));
                    Response.Write(BLL.Utils.toJson(notice));
                }
                catch (Exception)
                {
                    BLL.Utils.ShowMessage(this, "发生错误！");
                }
                Response.End();
            }
        }
    }
}