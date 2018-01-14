using System;

namespace Topicsys.Web
{
    /// <summary>
    /// 登录处理
    /// </summary>
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["login_name"] != null && Request["pwd"] != null && Request["type"] != null)
            {
                var msg = new BLL.Message();
                /// 验证输入长度
                if (Request["login_name"].Length < 3 || Request["pwd"].Length < 6 || Request["login_name"].Length > 32 || Request["pwd"].Length > 16)
                {
                    msg.Msg = "数据输入有误！";
                    Response.Write(BLL.Utils.toJson(msg));
                    Response.End();
                }
                /// 构建日志Model
                Model.t_log log = new Model.t_log
                {
                    log_ip = Request.UserHostAddress,
                    user_name = Request["login_name"],
                };

                try
                {
                    string url = null;
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
                        Session["role"] = 0; // 为了方便母版页判断权限和修改菜单,特设此变量，值越小权限越低：1学生,2导师,3教研室主任,4教务管理员
                        /// 获取附加信息
                        var bll_major = new BLL.t_major(); // 专业

                        switch (type)
                        {
                            #region 教务管理员登录

                            case "admin":
                                Session["role"] = 4;
                                var bll_admin = new BLL.t_admin();
                                var admin = bll_admin.GetModel(login_name);
                                Session["user_name"] = admin.user_name;
                                url = "/admin/";
                                break;

                            #endregion 教务管理员登录

                            #region 教务室主任登录

                            case "mteacher":
                                Session["role"] = 3;
                                var bll_mteacher = new BLL.t_teacher();
                                var mteacher = bll_mteacher.GetModel(login_name);
                                /// 获取专业信息
                                Session["major_id"] = mteacher.teacher_major_id;
                                /// 获取系别信息
                                Session["dept_id"] = mteacher.teacher_dept_id;
                                Session["user_name"] = mteacher.teacher_name;
                                url = "/admin/";
                                break;

                            #endregion 教务室主任登录

                            #region 导师登录

                            case "teacher":
                                Session["role"] = 2;
                                var bll_teacher = new BLL.t_teacher();
                                var teacher = bll_teacher.GetModel(login_name);
                                /// 获取专业信息
                                Session["major_id"] = teacher.teacher_major_id;
                                /// 获取系别信息
                                Session["dept_id"] = teacher.teacher_dept_id;
                                Session["user_name"] = teacher.teacher_name;
                                url = "/topic/";
                                break;

                            #endregion 导师登录

                            #region 学生登录

                            case "student"://学生
                                Session["role"] = 1;
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
                                url = "/select/list.aspx";
                                break;

                                #endregion 学生登录
                        }
                        msg.Msg = log.log_info = "登录成功！";
                    }
                    else
                    {
                        // 登录失败
                        log.log_info = msg.Msg = "用户名或密码错误！";
                    }

                    if (url != null)
                    {
                        msg.Body = (url);
                    }
                }
                catch
                {
                    msg.Msg = "发生错误！";
                }
                var bll_log = new BLL.t_log();
                bll_log.Add(log);
                Response.Write(BLL.Utils.toJson(msg));
                Response.End();
            }
            else
            {
                BLL.Utils.ShowMessage(this, "输入有误！");
            }
        }
    }
}