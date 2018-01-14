using System;
using System.Collections.Generic;

namespace Topicsys.Web
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /// 获取公告
            if (Request["type"] != null && Request["page"] != null)
            {
                var list = new List<Model.t_notice>();
                var bll = new BLL.t_notice();
                try
                {
                    list = bll.DataTableToList(bll.GetListByPage("", "id DESC", 10, int.Parse(Request["page"])).Tables[0]);
                    Response.Write(BLL.Utils.toJson(list));
                    Response.End();
                }
                finally
                {
                }
            }

            #region 登录处理,已移植到Login.aspx

            /*
            if (Request["login_name"] != null && Request["pwd"] != null && Request["type"] != null)
            {
                var msg = new BLL.Message();
                Model.t_log log = new Model.t_log
                {
                    log_ip = Request.UserHostAddress,
                    user_name = Request["login_name"],
                };
                if (Request["login_name"].Length < 3 || Request["pwd"].Length < 6)
                {
                    msg.Msg = "数据输入有误！";
                    Response.Write(BLL.Utils.toJson(msg));
                    Response.End();
                }
                var login_name = Request["login_name"];
                var pwd = Request["pwd"];
                var type = Request["type"];
                /// 登录验证
                if (BLL.Utils.Login(login_name, pwd, type))
                {
                    // 登录成功
                    Session["type"] = type;// 类型
                    Session["login_name"] = login_name;//登录,学号,工号
                    Session["user_name"] = null; // 显示名称(姓名)
                                                 /// 获取附加信息
                    var bll_major = new BLL.t_major(); // 专业

                    switch (type)
                    {
                        #region 教务管理员登录

                        case "admin":
                            var bll_admin = new BLL.t_admin();
                            var admin = bll_admin.GetModel(login_name);
                            msg.Body = "/admin/";
                            break;

                        #endregion 教务管理员登录

                        #region 学生登录

                        case "student"://学生
                            var bll_student = new BLL.t_student();
                            var student = bll_student.GetModel(login_name);
                            Session["user_name"] = student.student_name;
                            Session["class_id"] = student.student_class_id;
                            /// 获取班级信息
                            var bll_class = new BLL.t_class();
                            var myclass = bll_class.GetModel(student.student_class_id);
                            /// 获取专业信息
                            var major = bll_major.GetModel(myclass.class_major_id);
                            Session["major_id"] = major.major_id;
                            /// 获取系别信息
                            Session["dept_id"] = major.major_dept_id;
                            msg.Body = "/select/";
                            break;

                        #endregion 学生登录

                        #region 教务室主任登录

                        case "mteacher":
                            var bll_mteacher = new BLL.t_teacher();
                            var mteacher = bll_mteacher.GetModel(login_name);
                            /// 获取专业信息
                            Session["major_id"] = mteacher.teacher_major_id;
                            /// 获取系别信息
                            Session["dept_id"] = mteacher.teacher_dept_id;
                            msg.Body = "/admin/";
                            break;

                        #endregion 教务室主任登录

                        #region 导师登录

                        case "teacher":
                            var bll_teacher = new BLL.t_teacher();
                            var teacher = bll_teacher.GetModel(login_name);
                            /// 获取专业信息
                            Session["major_id"] = teacher.teacher_major_id;
                            /// 获取系别信息
                            Session["dept_id"] = teacher.teacher_dept_id;
                            msg.Body = "/select/";
                            break;

                            #endregion 导师登录
                    }

                    log.log_info = "登录成功！";
                    msg.Msg = "登录成功！";
                }
                else
                {
                    // 登录失败
                    msg.Msg = "用户名或密码错误！";
                    log.log_info = "登录失败！";
                }

                var bll_log = new BLL.t_log();
                bll_log.Add(log);
                Response.Write(BLL.Utils.toJson(msg));
                Response.End();
            }
            */

            #endregion 登录处理,已移植到Login.aspx
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            /*
            if (BLL.Utils.IsMobile(Request))
            {
                Server.Transfer("/m/login.aspx");
            }
            */
        }
    }
}