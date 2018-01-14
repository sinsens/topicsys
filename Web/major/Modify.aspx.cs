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

namespace Topicsys.Web.t_major
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
            Topicsys.BLL.t_major bll = new Topicsys.BLL.t_major();
            Topicsys.Model.t_major model = bll.GetModel(id);
            BLL.DDL.DeptDLL(txtmajor_dept_id);
            this.lblid.Text = model.id.ToString();
            this.txtmajor_name.Text = model.major_name;
            this.txtmajor_dept_id.Text = model.major_dept_id;
            this.txtmajor_stat.Text = model.major_stat.ToString();
            this.txtmajor_note.Text = model.major_note;
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtmajor_name.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }
            string major_name = this.txtmajor_name.Text;
            string major_dept_id = this.txtmajor_dept_id.Text;
            int major_stat = int.Parse(this.txtmajor_stat.Text);
            string major_note = this.txtmajor_note.Text;
            Topicsys.BLL.t_major bll = new Topicsys.BLL.t_major();

            Topicsys.Model.t_major model = bll.GetModel(int.Parse(Request.Params["id"]));
            model.major_name = major_name;
            model.major_dept_id = major_dept_id;
            model.major_stat = major_stat;
            model.major_note = major_note;

            /// 写入日志
            BLL.Utils.Log(this, "修改专业:" + model.major_id);
            BLL.Utils.ShowMessage(this, bll.Update(model)?"保存成功！":"发生错误！");
        }
    }
}