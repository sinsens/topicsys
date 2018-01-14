using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Maticsoft.Common;
using System.Drawing;
using LTP.Accounts.Bus;

namespace Topicsys.Web.v_topic
{
    public partial class status : Page
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
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere.AppendFormat("topic_stat!=9 AND concat(topic_name,class_name) like '%{0}%'", txtKeyword.Text.Trim());
            }
            else
            {
                strWhere.AppendFormat("topic_stat!=9", txtKeyword.Text.Trim());
            }
            ds = bll.GetList(strWhere.ToString());
            gridView.DataSource = ds;
            gridView.DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        #endregion gridView
    }
}