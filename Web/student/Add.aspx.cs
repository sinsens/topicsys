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

namespace Topicsys.Web.t_student
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.DDL.DeptDLL(ddlDept_id);
                BLL.DDL.MajorDLL(ddlMajor_id);
                BLL.DDL.ClassDLL(txtstudent_class_id);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
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
            string student_note = this.txtstudent_note.Text;

            Topicsys.Model.t_student model = new Topicsys.Model.t_student();
            model.student_xh = student_xh;
            model.student_pwd = BLL.Utils.HashPasswd("abc12345");
            model.student_name = student_name;
            model.student_class_id = student_class_id;
            model.student_note = student_note;

            Topicsys.BLL.t_student bll = new Topicsys.BLL.t_student();
            
            /// 写入日志
            BLL.Utils.Log(this, "添加学生:" + student_xh);
            BLL.Utils.ShowMessage(this, bll.Add(model));
        }

        protected void ddlDept_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.DDL.MajorDLL(ddlMajor_id, ddlDept_id.SelectedValue);
            BLL.DDL.ClassDLL(txtstudent_class_id, ddlMajor_id.SelectedValue);
        }

        protected void ddlMajor_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.DDL.ClassDLL(txtstudent_class_id, ddlMajor_id.SelectedValue);
        }
    }
}