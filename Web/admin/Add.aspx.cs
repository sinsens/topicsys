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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtuser_name.Text.Trim().Length == 0)
            {
                strErr += "登录名不能为空！\\n";
            }

            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return;
            }
            string user_name = this.txtuser_name.Text;
            string pwd = BLL.Utils.HashPasswd(this.txtpwd.Text.Trim().Length > 5 ? txtpwd.Text.Trim() : "abc12345");

            Topicsys.Model.t_admin model = new Topicsys.Model.t_admin();
            model.user_name = user_name;
            model.pwd = pwd;

            Topicsys.BLL.t_admin bll = new Topicsys.BLL.t_admin();
            
            /// 写入日志
            BLL.Utils.Log(this, "添加系统角色:" + user_name);
            BLL.Utils.ShowMessage(this, bll.Add(model)?"保存成功！":"保存失败！");
        }
    }
}