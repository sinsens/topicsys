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

namespace Topicsys.Web.t_major
{
    public partial class Show : Page
    {
        public string strid = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    strid = Request.Params["id"];
                    int id = (Convert.ToInt32(strid));
                    ShowInfo(id);
                }
            }
        }

        private void ShowInfo(int id)
        {
            Topicsys.BLL.t_major bll = new Topicsys.BLL.t_major();
            Topicsys.Model.t_major model = bll.GetModel(id);
            this.lblid.Text = model.id.ToString();
            var bll_dept = new BLL.t_dept();
            this.lblmajor_dept_id.Text = bll_dept.GetModel(model.major_dept_id).dept_name;
            this.lblmajor_name.Text = model.major_name;
            this.lblmajor_dept_id.Text = model.major_dept_id;
            this.lblmajor_stat.Text = model.major_stat.ToString();
            this.lblmajor_note.Text = model.major_note;
        }
    }
}