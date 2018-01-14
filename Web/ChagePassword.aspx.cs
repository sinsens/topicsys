using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web
{
    public partial class ChagePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var msg = new BLL.Message();
            if (Session["login_name"] == null)
            {
                Response.Write("请先<a href='/'>登录</a>");
                Response.End();
            }
            if (Request["pwd"] != null)
            {
                if (Request["pwd"].Length < 6)
                {
                    msg.Msg = "密码长度必须大于等于6个字符！";
                    Response.Write(BLL.Utils.toJson(msg));
                    Response.End();
                }
                try
                {
                    string pwd = BLL.Utils.HashPasswd(Request["pwd"]); // 预先加密
                    switch (Session["type"].ToString())
                    {
                        case "admin":
                            var bll_admin = new BLL.t_admin();
                            var admin = bll_admin.GetModel(Session["login_name"].ToString());
                            admin.pwd = pwd;
                            msg.Msg = (bll_admin.Update(admin)) ? "修改密码成功！" : "发生错误！";
                            break;

                        case "student":
                            var bll_student = new BLL.t_student();
                            var student = bll_student.GetModel(Session["login_name"].ToString());
                            student.student_pwd = pwd;
                            msg.Msg = (bll_student.Update(student)) ? "修改密码成功！" : "发生错误！";
                            break;

                        case "teacher":
                            var bll_teacher = new BLL.t_teacher();
                            var teacher = bll_teacher.GetModel(Session["login_name"].ToString());
                            teacher.teacher_pwd = pwd;
                            msg.Msg = (bll_teacher.Update(teacher)) ? "修改密码成功！" : "发生错误！";
                            break;

                        case "mteacher":
                            goto case "teacher";//直接调用teacher块
                    }
                    if (msg.Msg.Equals("修改密码成功！"))
                    {
                        /// 写入日志
                        BLL.Utils.Log(this, "修改密码");
                        // 注销登录
                        Session.Clear();
                        msg.Body = "/";
                    }
                }
                finally
                {
                    Response.Write(BLL.Utils.toJson(msg));
                    Response.End();
                }
            }
        }
    }
}