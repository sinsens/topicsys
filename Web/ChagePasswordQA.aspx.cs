using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web
{
    public partial class ChagePasswordQA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["type"] != null)
            {
                var msg = new BLL.Message();
                try
                {
                    string type = Request["type"].ToLower();
                    /// 判断是获取还是设置
                    if (type.Equals("update"))
                    {
                        /// 设置
                        string my_q = Request["my_q"].ToString();
                        string my_a = Request["my_a"].ToString();
                        switch (Session["type"].ToString())
                        {
                            case "student":
                                var bll_student = new BLL.t_student();
                                var student = bll_student.GetModel(Session["login_name"].ToString());
                                student.student_pwd_a = my_a;
                                student.student_pwd_q = my_q;
                                msg.Msg = (bll_student.Update(student)) ? "修改密保成功！" : "修改密保失败！";
                                break;

                            case "teacher":
                                var bll_teacher = new BLL.t_teacher();
                                var teacher = bll_teacher.GetModel(Session["login_name"].ToString());
                                teacher.teacher_pwd_q = my_q;
                                teacher.teacher_pwd_a = my_a;
                                msg.Msg = (bll_teacher.Update(teacher)) ? "修改密保成功！" : "修改密保失败！";
                                break;
                        }
                    }
                    else
                    {
                        switch (Session["type"].ToString())
                        {
                            case "student":
                                var bll_student = new BLL.t_student();
                                var student = bll_student.GetModel(Session["login_name"].ToString());
                                msg.Body = student;
                                msg.Code = 1;//标注学生
                                break;

                            case "teacher":
                                var bll_teacher = new BLL.t_teacher();
                                var teacher = bll_teacher.GetModel(Session["login_name"].ToString());
                                msg.Body = teacher;
                                msg.Code = 2; //标注教师
                                break;
                        }
                    }
                }
                finally
                {
                    /// 写入日志
                    BLL.Utils.Log(this, "修改密保问题");
                    Response.Write(BLL.Utils.toJson(msg));
                    Response.End();
                }
            }
        }
    }
}