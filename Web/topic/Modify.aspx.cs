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
    /// <summary>
    /// 修改论文出题
    /// </summary>
    public partial class Modify : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BLL.DDL.ClassDLL(txtstudent_class_id, Session["major_id"].ToString());
                //BLL.DDL.ClassDLL(txtstudent_class_id);
                if (Request.Params["topic_id"] != null && Request.Params["topic_id"].Trim() != "")
                {
                    ShowInfo(Request.Params["topic_id"]);
                }
            }
        }

        private void ShowInfo(string id)
        {
            Topicsys.BLL.t_topic bll = new Topicsys.BLL.t_topic();
            Topicsys.Model.t_topic model = bll.GetModel(id);
            this.txtstudent_class_id.Text = model.topic_class_id;
            this.txttopic_name.Text = model.topic_name;
            this.txttopic_note.Text = model.topic_note;
            this.ddlStat.Text = model.topic_stat.ToString();
            this.txttopic_num.Text = model.topic_num.ToString();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txttopic_name.Text.Trim().Length == 0)
            {
                strErr += "论文题目不能为空！\\n";
            }
            if (!PageValidate.IsNumber(txttopic_num.Text))
            {
                strErr += "可选人数格式错误！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }

            string topic_class_id = this.txtstudent_class_id.Text;
            string topic_name = this.txttopic_name.Text;
            string topic_note = this.txttopic_note.Text;
            int topic_stat = int.Parse(this.ddlStat.Text);
            /// 判断是否为违规操作
            if (topic_stat != 0 && topic_stat != 9)
            {
                BLL.Utils.ShowMessage(this, "请勿尝试注入！您已被注销！");
                BLL.Utils.Log(this, "非法修改出题状态！题目UUID:" + Request.Params["topic_id"]);
                Response.End();
            }
            int topic_num = int.Parse(this.txttopic_num.Text);
            Topicsys.BLL.t_topic bll = new Topicsys.BLL.t_topic();
            Topicsys.Model.t_topic model = bll.GetModel(Request.Params["topic_id"]);
            model.topic_class_id = topic_class_id;
            model.topic_name = topic_name;
            model.topic_note = topic_note;
            model.topic_stat = topic_stat;
            model.topic_num = topic_num;

            
            /// 写入日志
            BLL.Utils.Log(this, "修改出题:" + model.topic_id);
            BLL.Utils.ShowMessage(this,bll.Update(model)? "保存成功！":"发生错误！");
        }
    }
}