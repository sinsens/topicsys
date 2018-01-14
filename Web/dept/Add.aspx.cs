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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSave_Click(object sender, EventArgs e)
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

            Topicsys.Model.t_dept model = new Topicsys.Model.t_dept();
            model.dept_name = dept_name;
            model.dept_note = dept_note;

            Topicsys.BLL.t_dept bll = new Topicsys.BLL.t_dept();
            
            /// 写入日志
            BLL.Utils.Log(this, "添加系别:" + model.dept_name);
            BLL.Utils.ShowMessage(this, bll.Add(model)?"保存成功！":"保存失败！");
        }

        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}