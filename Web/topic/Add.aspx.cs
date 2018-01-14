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

namespace Topicsys.Web.t_topic
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["role"].ToString()) > 3)
            {
                BLL.Utils.ShowMessage(this, "该功能仅导师和教研室主任可用！");
                Response.End();
            }
            if (!IsPostBack)
            {
                BLL.DDL.ClassDLL(txtstudent_class_id, Session["major_id"].ToString());
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtstudent_class_id.Text.Trim().Length == 0)
            {
                strErr += "可选班级不能为空！\\n";
            }
            if (this.txttopic_name.Text.Trim().Length == 0)
            {
                strErr += "论文题目不能为空！\\n";
            }
            if (!PageValidate.IsNumber(txttopic_num.Text))
            {
                strErr += "可选人数上限格式错误！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }
            string topic_teacher_gh = Session["login_name"].ToString();
            string topic_name = this.txttopic_name.Text;
            string topic_note = this.txttopic_note.Text;
            int topic_num = int.Parse(this.txttopic_num.Text);
            if (topic_num > 200)
            {
                BLL.Utils.ShowMessage(this, "可选人数上限超过200！");
            }
            Topicsys.Model.t_topic model = new Topicsys.Model.t_topic();
            model.topic_teacher_gh = topic_teacher_gh;
            model.topic_name = topic_name;
            model.topic_note = topic_note;
            model.topic_num = topic_num;
            model.topic_class_id = txtstudent_class_id.SelectedValue;

            Topicsys.BLL.t_topic bll = new Topicsys.BLL.t_topic();
            /// 写入日志
            BLL.Utils.Log(this, "添加出题:" + topic_name);
            BLL.Utils.ShowMessage(this, bll.Add(model));
        }
    }
}