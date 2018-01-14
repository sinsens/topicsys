using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web
{
    /// <summary>
    /// 通过密保问题重置密码
    /// </summary>
    public partial class ResetMyPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["login_name"] != null && Request["type"] != null)
            {
                var msg = new BLL.Message();
                try
                {
                    /// 设置重试次数上限
                    if (Session["try"] == null)
                        Session["try"] = 0;
                    else
                        Session["try"] = int.Parse(Session["try"].ToString()) + 1;
                    if (Session["try"].Equals(10))
                    {
                        msg.Msg = "重试次数已超过10次，系统拒绝操作！";
                        Response.Write(BLL.Utils.toJson(msg));
                        Response.End();
                    }

                    string type = Request["type"].ToLower();
                    string login_name = Request["login_name"];
                    string my_a = Request["a"] == null ? null : Request["a"];
                    switch (type)
                    {
                        case "student":
                            var bll_student = new BLL.t_student();
                            var model = bll_student.GetModel(login_name);
                            if (model == null)
                                msg.Msg = "该学生不存在！";
                            else if (!model.student_stat.Equals(0))
                                msg.Msg = "该角色处于异常状态！";
                            else if (model.student_pwd_q == null || model.student_pwd_q.Length < 1)
                                msg.Msg = "未设置密保问题，无法通过密保重置密码！";
                            else
                                msg.Body = model.student_pwd_q;
                            if (my_a != null && model.student_pwd_a.Equals(my_a))
                            {
                                /// 登录系统
                                Session["type"] = type;// 类型
                                Session["login_name"] = login_name;//登录,学号,工号
                                Session["user_name"] = model.student_name; // 显示名称(姓名)
                                msg.Body = "/ChagePassword.aspx";
                            }
                            else if (my_a != null && (!model.student_pwd_a.Equals(my_a)))
                            {
                                msg.Msg = "密保答案错误！";
                                msg.Body = null;
                            }
                            break;

                        case "teacher":
                            var bll_teachert = new BLL.t_teacher();
                            var model2 = bll_teachert.GetModel(login_name);

                            if (model2 == null)
                                msg.Msg = "该导师不存在！";
                            else if (!model2.teacher_stat.Equals(0))
                                msg.Msg = "该角色处于异常状态！";
                            else if (!model2.teacher_type.Equals(0))
                                msg.Msg = "教研室主任请联系教务管理员重置密码！";
                            else if (model2.teacher_pwd_q == null || model2.teacher_pwd_q.Length < 1)
                                msg.Msg = "未设置密保问题，无法通过密保重置密码！";
                            else
                                msg.Body = model2.teacher_pwd_q;
                            if (my_a != null && model2.teacher_pwd_a.Equals(my_a))
                            {
                                /// 登录系统
                                Session["type"] = type;// 类型
                                Session["login_name"] = login_name;//登录,学号,工号
                                Session["user_name"] = model2.teacher_name; // 显示名称(姓名)
                                msg.Body = "/ChagePassword.aspx";
                            }
                            else if (my_a != null && (!model2.teacher_pwd_a.Equals(my_a)))
                            {
                                msg.Msg = "密保答案错误！";
                                msg.Body = null;
                            }
                            break;
                    }
                }
                finally
                {
                    /// 写入日志
                    var log = new Model.t_log
                    {
                        log_info = "通过密保问题重置密码",
                        log_ip = Request.UserHostAddress,
                        user_name = Request["login_name"],
                    };
                    BLL.Utils.Log(log);
                    Response.Write(BLL.Utils.toJson(msg));
                    Response.End();
                }
            }
        }
    }
}