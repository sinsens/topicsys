using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web
{
    public partial class import : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["type"] != null && myFile.HasFile)
            {
                // 验证文件大小
                if (myFile.FileContent.Length < 256)
                {
                    BLL.Utils.ShowMessage(this, "文件大小不正确!默认小于256Bytes的文件不进行导入处理。");
                    return;
                }

                // 验证文件后缀名
                if (!myFile.FileName.Trim().ToLower().EndsWith(".csv"))
                {
                    BLL.Utils.ShowMessage(this, "文件格式不正确!必须是CSV表格文件！");
                    return;
                }

                /// 映射本地文件名
                string type = Request["type"].ToLower();//获取文件类型
                string tick = DateTime.Now.Ticks.ToString();
                string ext_name = ".csv"; //默认文件后缀名
                string filename = type + "_" + tick + ext_name;//默认文件名
                string file_dir = "/uploads/";//默认上传路径
                string server_filepath = Server.MapPath("~" + file_dir + filename);//保存路径
                try
                {
                    /// 保存文件
                    myFile.SaveAs(server_filepath);
                    /// 导入数据
                    /// 写入日志
                    BLL.Utils.Log(this, "导入数据文件到系统,数据类型:" + type + ",文件路径" + server_filepath);
                    BLL.Utils.ShowMessage(this, BLL.Data.ImportFromCsvFile(type, server_filepath));
                }
                catch (Exception)
                {
                    BLL.Utils.ShowMessage(this, "发生错误！");
                }
                btnUpload.Enabled = true;
            }
        }
    }
}