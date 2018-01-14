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

namespace Topicsys.Web.t_admin
{
    public partial class Modify : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    int id = (Convert.ToInt32(Request.Params["id"]));
                    ShowInfo(id);
                }
            }
        }

        private void ShowInfo(int id)
        {
            Topicsys.BLL.t_admin bll = new Topicsys.BLL.t_admin();
            Topicsys.Model.t_admin model = bll.GetModel(id);
            this.lblid.Text = model.id.ToString();
            this.lbluser_name.Text = model.user_name;
            this.ddlStat.Text = model.user_stat.ToString();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string pwd = this.txtpwd.Text;
            int user_stat = int.Parse(this.ddlStat.SelectedValue);
            Topicsys.BLL.t_admin bll = new Topicsys.BLL.t_admin();
            var model = bll.GetModel(Convert.ToInt32(Request.Params["id"]));
            if (pwd.Trim().Length > 5)
            {
                model.pwd = BLL.Utils.HashPasswd(pwd);
            }
            model.user_stat = user_stat;
            /// 写入日志
            BLL.Utils.Log(this, "修改系统角色:" + model.user_name);
            BLL.Utils.ShowMessage(this, bll.Update(model) ? "保存成功！" : "保存失败！");
        }
    }
}