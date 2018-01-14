using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web
{
    public partial class RegStudent : System.Web.UI.Page
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
            string pwd = this.txtpwd.Text.Trim();
            if (pwd.Length < 6)
            {
                BLL.Utils.ShowMessage(this, "密码长度应该大于等于6个字符！");
                return;
            }
            Topicsys.Model.t_student model = new Topicsys.Model.t_student();
            model.student_xh = student_xh;
            model.student_pwd = BLL.Utils.HashPasswd(pwd);
            model.student_name = student_name;
            model.student_class_id = student_class_id;

            /// 写入日志

            BLL.Utils.Log(new Model.t_log
            {
                log_info = "学生注册:" + student_xh,
                log_ip = Request.UserHostAddress,
                user_name = student_xh
            });
            Topicsys.BLL.t_student bll = new Topicsys.BLL.t_student();
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