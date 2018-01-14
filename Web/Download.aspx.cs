using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web
{
    public partial class Download : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["action"] != null && Request["type"] != null)
            {
                try
                {
                    string type = Request["type"].ToLower();//获取文件类型
                    string tick = DateTime.Now.Ticks.ToString();
                    string ext_name = ".csv"; //默认文件后缀名
                    string filename = type + "_" + tick + ext_name;//默认文件名
                    string file_dir = "/downloads/";//默认下载路径
                    string server_filepath = Server.MapPath("~" + file_dir + filename);//保存路径
                    string target_fileurl = null;
                    switch (Request["action"].ToString().ToLower())
                    {
                        case "getuuid"://获取UUID数据
                            if (BLL.Data.GetUUID(type, server_filepath))
                            {
                                target_fileurl = (file_dir + filename);//发送文件给客户端
                            }
                            break;
                        case "gettemplate"://获取数据模板
                            if (BLL.Data.GetTemplate(type, server_filepath))
                            {
                                target_fileurl = (file_dir + filename);//发送文件给客户端
                            }

                            break;
                        case "getfile"://获取文件
                            break;
                    }

                    if (target_fileurl != null)
                    {
                        Response.Redirect(target_fileurl);
                    }
                    else
                    {
                        BLL.Utils.ShowMessage(this, "发生错误！");
                    }
                }
                catch
                {
                    BLL.Utils.ShowMessage(this, "发生错误！");
                }
            }
        }
    }
}