using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["fbody"] != null)
            {
                var msg = new BLL.Message();
                string str = "原始大小:" + Request["fbody"].Length;
                str += "\\n压缩后大小:" + BLL.Compression.CompressString(Request["fbody"]).Length;
                msg.Msg = str;
                Response.Write(BLL.Utils.toJson(str));
                Response.End();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var str = TextBox1.Text;
            var str2 = "abc" + str.Substring(str.Length - 4);
            Response.Write(str2);
        }
    }
}