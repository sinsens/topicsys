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

namespace Topicsys.Web.t_class
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
                BLL.DDL.DeptDLL(ddlDept_id);
                BLL.DDL.MajorDLL(ddlMajor_id);
            }
        }

        private void ShowInfo(int id)
        {
            Topicsys.BLL.t_class bll = new Topicsys.BLL.t_class();
            Topicsys.Model.t_class model = bll.GetModel(id);
            this.txtclass_name.Text = model.class_name;
            this.ddlMajor_id.Text = model.class_major_id;
            this.txtclass_note.Text = model.class_note;
            this.ddlStat.Text = model.class_stat.ToString();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtclass_name.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！\\n";
            }
            if (this.ddlMajor_id.Text.Trim().Length == 0)
            {
                strErr += "专业不能为空！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }
            string class_name = this.txtclass_name.Text;
            string class_major_id = this.ddlMajor_id.Text;
            string class_note = this.txtclass_note.Text;
            int class_stat = int.Parse(this.ddlStat.Text);
            Topicsys.BLL.t_class bll = new Topicsys.BLL.t_class();
            Topicsys.Model.t_class model = bll.GetModel(int.Parse(Request.Params["id"]));
            model.class_name = class_name;
            model.class_major_id = class_major_id;
            model.class_note = class_note;
            model.class_stat = class_stat;

            /// 写入日志
            BLL.Utils.Log(this, "修改班级:" + model.class_id);
            BLL.Utils.ShowMessage(this, bll.Update(model)?"保存成功！":"发生错误！");
        }

        protected void ddlDept_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.DDL.MajorDLL(ddlMajor_id, ddlDept_id.SelectedValue);
        }
    }
}