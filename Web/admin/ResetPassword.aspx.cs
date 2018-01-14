using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Topicsys.Web.admin
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var msg = new BLL.Message();
            if (!Session["type"].Equals("admin"))
            {
                BLL.Utils.ShowMessage(this, "该功能仅教务管理员可用！");
                Response.End();
            }

            /// 校验角色
            if (Request["login_name"] != null && Request["type"] != null)
            {
                try
                {
                    string type = Request["type"].ToLower();
                    string login_name = Request["login_name"];
                    string pwd = null;
                    if (Request["pwd"] != null)
                    {
                        if (Request["pwd"].Length < 6 || Request["pwd"].Length > 32)
                        {
                            msg.Msg = "密码长度必须大于5个字符小于32个字符！";
                            Response.Write(BLL.Utils.toJson(msg));
                            Response.End();
                        }
                        else
                        {
                            pwd = BLL.Utils.HashPasswd(Request["pwd"]); // 预先加密
                        }
                    }
                    switch (type)
                    {
                        case "student":
                            var bll_student = new BLL.t_student();
                            var model = bll_student.GetModel(login_name);
                            if (model == null)
                                msg.Msg = "该学生不存在！";
                            else if (!model.student_stat.Equals(0))
                                msg.Msg = "该角色处于异常状态！";
                            else
                                msg.Code = 1;
                            if (pwd != null)
                            {
                                model.student_pwd = pwd;
                                msg.Msg = (bll_student.Update(model)) ? "修改密码成功！" : "修改密码失败！";
                            }
                            break;

                        case "teacher":
                            var bll_teachert = new BLL.t_teacher();
                            var model2 = bll_teachert.GetModel(login_name);

                            if (model2 == null)
                                msg.Msg = "该导师或教研室主任不存在！";
                            else if (!model2.teacher_stat.Equals(0))
                                msg.Msg = "该角色处于异常状态！";
                            else
                                msg.Code = 1;
                            if (pwd != null)
                            {
                                model2.teacher_pwd = pwd;
                                msg.Msg = (bll_teachert.Update(model2)) ? "修改密码成功！" : "修改密码失败！";
                            }
                            break;
                    }
                }
                finally
                {
                    /// 写入日志
                    BLL.Utils.Log(this, "重置密码:" + Request["login_name"]);
                    Response.Write(BLL.Utils.toJson(msg));
                    Response.End();
                }
            }
        }
    }
}