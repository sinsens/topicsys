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

namespace Topicsys.Web.t_class
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.DDL.DeptDLL(ddlDept_id);
                BLL.DDL.MajorDLL(ddlMajor_id);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (this.ddlDept_id.Text.Trim().Length == 0)
            {
                strErr += "系别不能为空！\\n";
            }
            if (this.txtclass_name.Text.Trim().Length == 0)
            {
                strErr += "名称不能为空！\\n";
            }
            if (this.ddlMajor_id.Text.Trim().Length == 0)
            {
                strErr += "专业不能为空！\\n";
            }

            if (strErr != "")
            {
                BLL.Utils.ShowMessage(this, strErr);
                return;
            }
            string class_name = this.txtclass_name.Text;
            string class_major_id = this.ddlMajor_id.Text;
            string class_note = this.txtclass_note.Text;

            Topicsys.Model.t_class model = new Topicsys.Model.t_class();
            model.class_name = class_name;
            model.class_major_id = class_major_id;
            model.class_note = class_note;

            Topicsys.BLL.t_class bll = new Topicsys.BLL.t_class();
            
            /// 写入日志
            BLL.Utils.Log(this, "添加班级:" + model.class_name);
            BLL.Utils.ShowMessage(this, bll.Add(model)?"保存成功！":"保存失败！");
        }

        protected void ddlDept_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL.DDL.MajorDLL(ddlMajor_id, ddlDept_id.SelectedValue);
        }
    }
}