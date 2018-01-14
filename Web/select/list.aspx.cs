using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;

namespace Topicsys.Web.select
{
    /// <summary>
    /// 查看可选题目列表,申请选题
    /// </summary>
    public partial class list : Page
    {
        private Topicsys.BLL.v_topic bll = new Topicsys.BLL.v_topic();
        private Topicsys.BLL.t_topic bll2 = new Topicsys.BLL.t_topic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            //strWhere.AppendFormat("topic_stat = 2 topic_class_id='{0}'", Session["class_id"]);
            strWhere.AppendFormat("topic_stat = 2 AND topic_class_id='{0}'", Session["class_id"]);
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere.AppendFormat(" AND concat(topic_name,class_name,teacher_name) like '%{0}%'", txtKeyword.Text.Trim());
            }
            ds = bll.GetList(strWhere.ToString());
            gridView.DataSource = ds;
            gridView.DataBind();
        }

        #endregion gridView

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void gridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = gridView.DataKeys[int.Parse(e.CommandArgument.ToString())].Value.ToString();
            if (e.CommandName.Equals("ApplyFor"))
            {
                //BLL.Utils.ShowMessage(this, id.ToString());
                ApplyFor(id);
            }
        }

        /// <summary>
        /// 申请
        /// </summary>
        /// <param name="id"></param>
        protected void ApplyFor(string id)
        {
            var bll_select = new BLL.t_select();
            /// 写入日志
            BLL.Utils.Log(this, "申请选题:" + id);
            BLL.Utils.ShowMessage(this, bll_select.ApplyFor(id, Session["login_name"].ToString()));
        }
    }
}