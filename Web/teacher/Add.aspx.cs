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

namespace Topicsys.Web.t_teacher
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.DDL.DeptDLL(txtteacher_dept_id);
                BLL.DDL.MajorDLL(txtteacher_major_id);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtteacher_gh.Text.Trim().Length == 0)
            {
                strErr += "工号不能为空！\\n";
            }
            if (this.txtteacher_name.Text.Trim().Length == 0)
            {
                strErr += "姓名不能为空！\\n";
            }
            if (this.txtteacher_dept_id.Text.Trim().Length == 0)
            {
                strErr += "系别不能为空！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }
            string teacher_gh = this.txtteacher_gh.Text;
            string teacher_name = this.txtteacher_name.Text;
            string teacher_dept_id = this.txtteacher_dept_id.SelectedValue;
            string teacher_major_id = this.txtteacher_major_id.SelectedValue;
            string teacher_note = this.txtteacher_note.Text;
            int teacher_type = int.Parse(this.txtteacher_type.SelectedValue);

            Topicsys.Model.t_teacher model = new Topicsys.Model.t_teacher
            {
                teacher_gh = teacher_gh,
                teacher_name = teacher_name,
                teacher_dept_id = teacher_dept_id,
                teacher_major_id = teacher_major_id,
                teacher_pwd = BLL.Utils.HashPasswd("abc" + teacher_gh), // 生成默认密码
                teacher_note = teacher_note,
                teacher_type = teacher_type,
            };

            Topicsys.BLL.t_teacher bll = new Topicsys.BLL.t_teacher();
            
            /// 写入日志
            BLL.Utils.Log(this, "添加导师:" + teacher_gh);
            BLL.Utils.ShowMessage(this, bll.Add(model));
        }

        protected void txtteacher_dept_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.DDL.MajorDLL(txtteacher_major_id, txtteacher_major_id.SelectedValue);
        }
    }
}