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

namespace Topicsys.Web.t_dept
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
            Topicsys.BLL.t_dept bll = new Topicsys.BLL.t_dept();
            Topicsys.Model.t_dept model = bll.GetModel(id);
            this.lblid.Text = model.id.ToString();
            this.txtdept_name.Text = model.dept_name;
            this.txtdept_note.Text = model.dept_note;
            this.txtdept_stat.Text = model.dept_stat.ToString();
        }

        public void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtdept_name.Text.Trim().Length == 0)
            {
                strErr += "系别名称不能为空！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }
            string dept_name = this.txtdept_name.Text;
            string dept_note = this.txtdept_note.Text;
            int dept_stat = int.Parse(this.txtdept_stat.SelectedValue);

            Topicsys.BLL.t_dept bll = new Topicsys.BLL.t_dept();
            var model = bll.GetModel(int.Parse(Request.Params["id"]));
            model.dept_name = dept_name;
            model.dept_note = dept_note;
            model.dept_stat = dept_stat;
            
            /// 写入日志
            BLL.Utils.Log(this, "修改系别:" + model.dept_id);
            BLL.Utils.ShowMessage(this, bll.Update(model)?"保存成功！":"发生错误！");
        }
    }
}