using System;
using System.Management;  //在项目-》添加引用....里面引用System.Management
using System.Net;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.IO;
using Newtonsoft.Json;
using Topicsys.Model;
using System.Text;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace Topicsys.BLL
{
    /// <summary>
    /// Web工具
    /// </summary>
    public static class Utils
    {
        /// <summary>
        /// 判断是否为手机端访问
        /// 默认返回false
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static bool IsMobile(HttpRequest request)
        {
            #region 判断是否为手机端访问

            var ua = request.Headers["user-agent"].ToString().ToLower();
            var mobile = new List<string> {
                "iPad", "Android", "iPhone", "iPod", "Mobile", "mobi", "uc", "Windows Phone"
            };
            foreach (var item in mobile)
            {
                if (ua.IndexOf(item.ToLower()) > -1)
                {
                    return true;
                }
            }
            return false;

            #endregion 判断是否为手机端访问
        }

        /// <summary>
        /// 登录处理
        /// </summary>
        /// <param name="page">请求登录页面</param>
        /// <returns></returns>
        public static void Login(Page page)
        {
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login_name">登录名</param>
        /// <param name="pwd">密码</param>
        /// <param name="type">类型:student,admin,mteacher,teacher
        /// 默认student</param>
        /// <returns></returns>
        public static bool Login(string login_name, string pwd, string type = "student")
        {
            switch (type)
            {
                #region 学生登录

                case "student"://学生
                    var bll_student = new BLL.t_student();
                    var student = bll_student.GetModel(login_name);
                    if (student == null || (!student.student_stat.Equals(0)))
                    {
                        return false;
                    }
                    if (!chkPasswd(pwd, student.student_pwd))
                    {
                        return false;
                    }
                    break;

                #endregion 学生登录

                #region 教务管理员登录

                case "admin":
                    var bll_admin = new BLL.t_admin();
                    var admin = bll_admin.GetModel(login_name);
                    if (admin == null || (!admin.user_stat.Equals(0)))
                    {
                        return false;
                    }
                    if (!chkPasswd(pwd, admin.pwd))
                    {
                        return false;
                    }
                    break;

                #endregion 教务管理员登录

                #region 教务室主任登录

                case "mteacher":
                    var bll_mteacher = new BLL.t_teacher();
                    var mteacher = bll_mteacher.GetModel(login_name);
                    if (mteacher == null || (!mteacher.teacher_stat.Equals(0)))
                    {
                        return false;
                    }
                    if (!mteacher.teacher_type.Equals(1))
                    {
                        return false;
                    }
                    if (!chkPasswd(pwd, mteacher.teacher_pwd))
                    {
                        return false;
                    }
                    break;

                #endregion 教务室主任登录

                #region 导师登录

                case "teacher":
                    var bll_teacher = new BLL.t_teacher();
                    var teacher = bll_teacher.GetModel(login_name);
                    if (teacher == null || (!teacher.teacher_stat.Equals(0)))
                    {
                        return false;
                    }
                    if (!teacher.teacher_type.Equals(0))
                    {
                        return false;
                    }
                    if (!chkPasswd(pwd, teacher.teacher_pwd))
                    {
                        return false;
                    }
                    break;

                    #endregion 导师登录
            }

            return true;
        }

        #region 日志

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="rizhi"></param>
        public static void Log(Model.t_log rizhi)
        {
            var log = new DAL.t_log();
            rizhi.log_date = DateTime.Now;
            log.Add(rizhi);
        }

        /// <summary>
        /// 记录日志
        /// </summary>
        /// <param name="login_name">登录名</param>
        /// <param name="ip">IP</param>
        /// <param name="note">日志信息</param>
        public static void Log(string login_name, string ip, string note)
        {
            var log = new BLL.t_log();
            var rizhi = new Model.t_log
            {
                log_ip = ip,
                user_name = login_name,
                log_info = note,
            };
            log.Add(rizhi);
        }

        /// <summary>
        /// 记录日志-登录后操作
        /// </summary>
        /// <param name="page">this</param>
        /// <param name="note">日志信息</param>
        public static void Log(Page page, string note)
        {
            var log = new BLL.t_log();
            var rizhi = new Model.t_log
            {
                log_ip = page.Request.UserHostAddress,
                user_name = page.Session["login_name"].ToString(),
                log_info = note,
            };
            log.Add(rizhi);
        }

        #endregion 日志

        /// <summary>
        /// 把Object转换为Json序列
        /// </summary>
        /// <param name="obj">Message</param>
        /// <returns></returns>
        public static object toJson(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }

        /// <summary>
        /// 显示提示框
        /// </summary>
        /// <param name="page">this</param>
        /// <param name="msg">提示内容</param>
        public static void ShowMessage(Page page, string msg)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), null, "mui.alert(\"" + msg + "\");", true);
        }

        #region 密码

        /// <summary>
        /// 加密密码
        /// </summary>
        /// <param name="passwd"></param>
        /// <returns></returns>
        public static string HashPasswd(string passwd)
        {
            return BCrypt.Net.BCrypt.HashPassword(passwd);
        }

        /// <summary>
        /// 检测密码
        /// </summary>
        /// <param name="pwd"></param>
        /// <param name="passwdhash"></param>
        /// <returns></returns>
        public static bool chkPasswd(string pwd, string passwdhash)
        {
            return BCrypt.Net.BCrypt.Verify(pwd, passwdhash);
        }

        /// <summary>
        /// Md5加密
        /// fork from http://www.cnblogs.com/fanlu/articles/2094289.html
        /// </summary>
        /// <param name="str">要加密的string</param>
        /// <returns>密文</returns>
        public static string MD5Encrypt(string str)
        {
            string pwd = null;
            MD5 m = MD5.Create();
            byte[] s = m.ComputeHash(Encoding.Unicode.GetBytes(str));
            for (int i = 0; i < s.Length; i++)
            {
                pwd = pwd + s[i].ToString("X");
            }
            return pwd;
        }

        /// <summary>
        /// 采用Bcrypt+MD5加密
        /// </summary>
        /// <param name="pwd">密码文本</param>
        /// <returns></returns>
        public static string BcryptMD5(string pwd)
        {
            return HashPasswd(MD5Encrypt(pwd));
        }

        #endregion 密码
    }
}