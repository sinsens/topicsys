using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web.select
{
    /// <summary>
    /// 发布学生选题结果
    /// </summary>
    public partial class dist : System.Web.UI.Page
    {
        private BLL.t_select bll = new BLL.t_select();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Session["type"].ToString().Equals("admin"))
            {
                BLL.Utils.ShowMessage(this, "该功能仅教务管理员可用！");
                return;
            }

            txtSNum_ok.Text = bll.GetRecordCount("select_stat=1").ToString();///显示选题成功学生数量
            txtSNum.Text = bll.GetRecordCount("select_stat NOT IN (1,9)").ToString();///显示未选题成功数量
        }

        protected void btnDist_Click(object sender, EventArgs e)
        {
            if (!Session["type"].ToString().Equals("admin"))
            {
                BLL.Utils.ShowMessage(this, "该功能仅教务管理员可用！");
                return;
            }
            BLL.Utils.ShowMessage(this, bll.Dist());/// 提示处理结果
        }
    }
}