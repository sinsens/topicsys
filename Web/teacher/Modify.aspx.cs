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
            Topicsys.BLL.t_teacher bll = new Topicsys.BLL.t_teacher();
            Topicsys.Model.t_teacher model = bll.GetModel(id);
            this.txtteacher_gh.Text = model.teacher_gh;
            this.txtteacher_name.Text = model.teacher_name;
            this.txtteacher_dept_id.Text = model.teacher_dept_id;
            this.txtteacher_major_id.Text = model.teacher_major_id;
            this.ddlStat.Text = model.teacher_stat.ToString();
            this.txtteacher_note.Text = model.teacher_note;
            this.txtteacher_type.Text = model.teacher_type.ToString();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
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
            string teacher_dept_id = this.txtteacher_dept_id.Text;
            string teacher_major_id = this.txtteacher_major_id.Text;
            int teacher_type = int.Parse(this.txtteacher_type.SelectedValue);
            string teacher_note = this.txtteacher_note.Text;
            int teacher_stat = int.Parse(ddlStat.SelectedValue);
            Topicsys.BLL.t_teacher bll = new Topicsys.BLL.t_teacher();
            Topicsys.Model.t_teacher model = bll.GetModel(int.Parse(Request.Params["id"]));

            model.teacher_gh = teacher_gh;
            model.teacher_name = teacher_name;
            model.teacher_dept_id = teacher_dept_id;
            model.teacher_major_id = teacher_major_id;
            model.teacher_stat = teacher_stat;
            model.teacher_note = teacher_note;
            model.teacher_type = teacher_type;
            /// 写入日志
            BLL.Utils.Log(this, "修改导师:" + teacher_gh);
            BLL.Utils.ShowMessage(this, bll.Update(model)?"保存成功！":"保存失败！");
        }
    }
}