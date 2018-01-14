using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web.select
{
    public partial class export_teacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.DDL.DeptDLL(ddlParm);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            /// 映射本地文件名
            string type = ddlType.SelectedValue.ToLower();//获取文件类型
            string tick = DateTime.Now.Ticks.ToString();
            string ext_name = ".csv"; //默认文件后缀名
            string filename = type + "_" + tick + ext_name;//默认文件名
            string file_dir = "/uploads/";//默认上传路径
            string server_filepath = Server.MapPath("~" + file_dir + filename);//保存路径
            if (BLL.Data.ExportSelectResult(type, ddlParm.SelectedValue, server_filepath))
            {
                Response.Redirect(file_dir + filename);
            }
            else
            {
                BLL.Utils.ShowMessage(this, "发生错误！");
            }
            BLL.Utils.Log(this, "导出选题文件:" + server_filepath);
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlType.SelectedValue)
            {
                case "major":
                    BLL.DDL.MajorDLL(ddlParm);
                    break;

                case "class":
                    BLL.DDL.ClassDLL(ddlParm);
                    break;

                case "topic":
                    BLL.DDL.TopicDLL(ddlParm);
                    break;
            }
        }
    }
}