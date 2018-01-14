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
    public partial class mgr : Page
    {
        private Topicsys.BLL.v_topic bll = new Topicsys.BLL.v_topic();
        private Topicsys.BLL.t_topic bll2 = new Topicsys.BLL.t_topic();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //gridView.BorderColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_bordercolorlight"].ToString());
                //gridView.HeaderStyle.BackColor = ColorTranslator.FromHtml(Application[Session["Style"].ToString() + "xtable_titlebgcolor"].ToString());
                //btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
                BindData();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idlist = GetSelIDlist();
            if (idlist.Trim().Length == 0)
                return;
            var li = GetSelIDlist().Split(',');
            foreach (string item in li)
            {
                Off(item);
                /// 写入日志
                BLL.Utils.Log(this, "注销出题:" + item);
            }
            BindData();
        }

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="id"></param>
        protected void Off(string id)
        {
            bll2.DoAction(id, 9);
        }

        #region gridView

        public void BindData()
        {
            DataSet ds = new DataSet();
            StringBuilder strWhere = new StringBuilder();
            if (txtKeyword.Text.Trim() != "")
            {
                strWhere.AppendFormat("topic_stat!=9 AND topic_stat!=5 AND concat(topic_name,class_name) like '%{0}%'", txtKeyword.Text.Trim());
            }
            else
            {
                strWhere.Append("topic_stat!=9");
            }
            gridView.DataSource = bll.GetList(strWhere.ToString());
            gridView.DataBind();
        }

        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridView.PageIndex = e.NewPageIndex;
            BindData();
        }

        protected void apply_MyCondition(object sender, EventArgs e)
        {
            StringBuilder strWhere = new StringBuilder();
            switch (myCondition.Text.Trim())
            {
                case "全部":
                    strWhere.Append("topic_stat!=9");
                    break;

                case "已审核":
                    strWhere.Append("topic_stat!=0 AND topic_stat!=9");
                    break;

                case "未审核":
                    strWhere.Append("topic_stat=0");
                    break;

                case "已通过审核":
                    strWhere.Append("topic_stat=2");
                    break;

                case "未通过审核":
                    strWhere.Append("topic_stat=1");
                    break;
            }
            gridView.DataSource = bll.GetList(strWhere.ToString());
            gridView.DataBind();
        }

        protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                //e.Row.Cells[0].Text = "<input id='Checkbox2' type='checkbox' onclick='CheckAll()'/><label></label>";
            }
        }

        protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Attributes.Add("style", "background:#FFF");
        }

        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridView.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl("OffThis");
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    //#warning 代码生成警告：请检查确认Cells的列索引是否正确
                    if (gridView.DataKeys[i].Value != null)
                    {
                        idlist += gridView.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }

        #endregion gridView
    }
}