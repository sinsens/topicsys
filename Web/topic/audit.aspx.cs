using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web.topic
{
    public partial class audit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (int.Parse(Session["role"].ToString()) < 3)
            {
                BLL.Utils.ShowMessage(this, "该功能仅教研室主任以上权限可用！");
                Response.End();
            }
            if (!IsPostBack)
            {
                initControl();
            }
            else
            {
                var bbl = new BLL.t_topic();
                var model = bbl.GetModel(Request["topic_id"]);
                model.topic_stat = int.Parse(ddlStat.SelectedValue);
                model.topic_note = txttopic_note.Text;
            }
        }

        protected void initControl()
        {
            var bll = new BLL.v_topic();
            var model = bll.GetModel(Request["topic_id"]);
            lblClass.Text = model.class_name;
            lblDept.Text = model.dept_name;
            lblName.Text = model.topic_name;
            lblGh.Text = model.topic_teacher_gh;
            lblNum.Text = model.topic_num.ToString();
            lblTName.Text = model.teacher_name;
            txttopic_note.Text = model.topic_note;
            ddlStat.Text = model.topic_stat.ToString();
        }

        /// <summary>
        /// 保存审核结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var bll = new BLL.t_topic();
            var model = bll.GetModel(Request["topic_id"]);
            model.topic_stat = int.Parse(ddlStat.SelectedValue);
            model.topic_note = txttopic_note.Text;
            
            /// 写入日志
            BLL.Utils.Log(this, "审核出题:" + Request["topic_id"]);
            BLL.Utils.ShowMessage(this, bll.Update(model)?"保存成功！":"发生错误！");
        }
    }
}