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

namespace Topicsys.Web.t_student
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
            BLL.DDL.DeptDLL(ddlDept_id);
            BLL.DDL.MajorDLL(ddlMajor_id);
            Topicsys.BLL.t_student bll = new Topicsys.BLL.t_student();
            Topicsys.Model.t_student model = bll.GetModel(id);
            this.txtstudent_xh.Text = model.student_xh;
            this.txtstudent_name.Text = model.student_name;
            this.txtstudent_class_id.Text = model.student_class_id;
            this.ddlStat.Text = model.student_stat.ToString();
            this.txtstudent_note.Text = model.student_note;
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtstudent_xh.Text.Trim().Length == 0)
            {
                strErr += "学号不能为空！\\n";
            }
            if (this.txtstudent_name.Text.Trim().Length == 0)
            {
                strErr += "姓名不能为空！\\n";
            }
            if (this.txtstudent_class_id.Text.Trim().Length == 0)
            {
                strErr += "班级不能为空！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }
            string student_xh = this.txtstudent_xh.Text;
            string student_name = this.txtstudent_name.Text;
            string student_class_id = this.txtstudent_class_id.Text;
            int student_stat = int.Parse(this.ddlStat.Text);
            string student_note = this.txtstudent_note.Text;
            Topicsys.BLL.t_student bll = new Topicsys.BLL.t_student();

            var model = bll.GetModel(int.Parse(Request.Params["id"]));
            model.student_xh = student_xh;
            model.student_name = student_name;
            model.student_class_id = student_class_id;
            model.student_stat = student_stat;
            model.student_note = student_note;
            
            /// 写入日志
            BLL.Utils.Log(this, "修改学生:" + student_xh);
            BLL.Utils.ShowMessage(this, bll.Update(model)?"保存成功！":"发生错误");
        }
    }
}