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

namespace Topicsys.Web.t_major
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.DDL.DeptDLL(txtmajor_dept_id);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.txtmajor_name.Text.Trim().Length == 0)
            {
                strErr += "专业名称不能为空！\\n";
            }
            if (this.txtmajor_dept_id.Text.Trim().Length == 0)
            {
                strErr += "必须选择系别！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }
            string major_name = this.txtmajor_name.Text;
            string major_dept_id = this.txtmajor_dept_id.Text;
            string major_note = this.txtmajor_note.Text;

            var model = new Topicsys.Model.t_major
            {
                major_name = major_name,
                major_dept_id = major_dept_id,
                major_note = major_note,
            };

            Topicsys.BLL.t_major bll = new Topicsys.BLL.t_major();
            
            /// 写入日志
            BLL.Utils.Log(this, "添加专业:" + model.major_name);
            BLL.Utils.ShowMessage(this, bll.Add(model)?"保存成功！":"保存失败！");
        }
    }
}