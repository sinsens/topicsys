using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading;

namespace Topicsys.BLL
{
    /// <summary>
    /// 数据导入导出类
    /// </summary>
    public static class Data
    {
        /// <summary>
        /// 导出选题结果
        /// </summary>
        /// <param name="type">按条件导出:dept,major,class,teacher,select</param>
        /// <param name="parms">*id</param>
        /// <param name="filename">文件路径</param>
        public static bool ExportSelectResult(string type, string parms, string filename)
        {
            var bll = new BLL.v_select();
            var dt = new DataTable();
            /// 获取数据
            switch (type)
            {
                case "dept":

                    #region 按系别导出

                    dt.Columns.Add(new DataColumn("专业"));
                    dt.Columns.Add(new DataColumn("班级"));
                    dt.Columns.Add(new DataColumn("姓名"));
                    dt.Columns.Add(new DataColumn("学号"));
                    dt.Columns.Add(new DataColumn("导师"));
                    dt.Columns.Add(new DataColumn("导师工号"));
                    dt.Columns.Add(new DataColumn("所选题目"));
                    var list_dept = bll.GetModelList(" select_stat=5 AND dept_id='" + parms + "'");
                    if (list_dept.Count == 0)
                        break;
                    foreach (var item in list_dept)
                    {
                        var dr = dt.NewRow();
                        dr["专业"] = item.major_name;
                        dr["班级"] = item.class_name;
                        dr["姓名"] = item.student_name;
                        dr["学号"] = item.select_student_xh;
                        dr["导师"] = item.teacher_name;
                        dr["导师工号"] = item.topic_teacher_gh;
                        dr["所选题目"] = item.topic_name;
                        dt.Rows.Add(dr);
                    }

                    #endregion 按系别导出

                    break;

                case "major":

                    #region 按专业导出

                    dt.Columns.Add(new DataColumn("班级"));
                    dt.Columns.Add(new DataColumn("姓名"));
                    dt.Columns.Add(new DataColumn("学号"));
                    dt.Columns.Add(new DataColumn("导师"));
                    dt.Columns.Add(new DataColumn("导师工号"));
                    dt.Columns.Add(new DataColumn("所选题目"));

                    var list_major = bll.GetModelList(" select_stat=5 AND class_major_id='" + parms + "'");
                    if (list_major.Count == 0)
                        break;
                    foreach (var item in list_major)
                    {
                        var dr = dt.NewRow();
                        dr["班级"] = item.class_name;
                        dr["姓名"] = item.student_name;
                        dr["学号"] = item.select_student_xh;
                        dr["导师"] = item.teacher_name;
                        dr["导师工号"] = item.topic_teacher_gh;
                        dr["所选题目"] = item.topic_name;
                        dt.Rows.Add(dr);
                    }

                    #endregion 按专业导出

                    break;

                case "class":

                    #region 按班级

                    dt.Columns.Add(new DataColumn("姓名"));
                    dt.Columns.Add(new DataColumn("学号"));
                    dt.Columns.Add(new DataColumn("导师"));
                    dt.Columns.Add(new DataColumn("导师工号"));
                    dt.Columns.Add(new DataColumn("所选题目"));

                    var list_class = bll.GetModelList(" select_stat=5 AND class_id='" + parms + "'");
                    if (list_class.Count == 0)
                        break;
                    foreach (var item in list_class)
                    {
                        var dr = dt.NewRow();
                        dr["姓名"] = item.student_name;
                        dr["学号"] = item.select_student_xh;
                        dr["导师"] = item.teacher_name;
                        dr["导师工号"] = item.topic_teacher_gh;
                        dr["所选题目"] = item.topic_name;
                        dt.Rows.Add(dr);
                    }

                    #endregion 按班级

                    break;

                case "teacher":

                    #region 按导师

                    dt.Columns.Add(new DataColumn("专业"));
                    dt.Columns.Add(new DataColumn("班级"));
                    dt.Columns.Add(new DataColumn("姓名"));
                    dt.Columns.Add(new DataColumn("学号"));
                    dt.Columns.Add(new DataColumn("所选题目"));

                    var list_teacher = bll.GetModelList(" select_stat=5 AND topic_teacher_gh='" + parms + "'");
                    if (list_teacher.Count == 0)
                        break;
                    foreach (var item in list_teacher)
                    {
                        var dr = dt.NewRow();
                        dr["专业"] = item.major_name;
                        dr["班级"] = item.class_name;
                        dr["姓名"] = item.student_name;
                        dr["学号"] = item.select_student_xh;
                        dr["所选题目"] = item.topic_name;
                        dt.Rows.Add(dr);
                    }

                    #endregion 按导师

                    break;

                case "select":

                    #region 按选题导出

                    dt.Columns.Add(new DataColumn("专业"));
                    dt.Columns.Add(new DataColumn("班级"));
                    dt.Columns.Add(new DataColumn("姓名"));
                    dt.Columns.Add(new DataColumn("学号"));

                    var list_topic = bll.GetModelList(" select_stat=5 AND select_topic_id='" + parms + "'");
                    if (list_topic.Count == 0)
                        break;
                    foreach (var item in list_topic)
                    {
                        var dr = dt.NewRow();
                        dr["专业"] = item.major_name;
                        dr["班级"] = item.class_name;
                        dr["姓名"] = item.student_name;
                        dr["学号"] = item.select_student_xh;
                        dt.Rows.Add(dr);
                    }

                    #endregion 按选题导出

                    break;
            }

            /// 没有数据,添加提示信息
            if (dt.Rows.Count == 0)
            {
                var dr = dt.NewRow();
                dr[0] = "没有相关数据！";
                dt.Rows.Add(dr);
            }
            /// 写入文件
            return CsvHelper.dt2csv(filename, dt);
        }

        /// <summary>
        /// 从CSV文件导入学生信息
        /// </summary>
        /// <param name="filename"></param>
        public static string ImportStudentFromCSVFile(string filename)
        {
            var dt = GetTemplate("student");
            var data = CsvHelper.csv2dt(filename, 1, dt);
            if (data.Rows.Count < 1)
            {
                return "没有数据或数据格式不正确";
            }
            var dal = new DAL.t_student();
            lock (dal)//锁定
            {
                int i = 0;
                int total = data.Rows.Count;
                var _start = DateTime.Now.Ticks; // 开始时间
                foreach (DataRow item in data.Rows)
                {
                    try
                    {
                        string xh = item["学号"].ToString();
                        dal.Add(new Model.t_student
                        {
                            student_class_id = item["班级UUID"].ToString(),
                            student_name = item["姓名"].ToString(),
                            student_xh = xh,
                            student_pwd = Utils.HashPasswd("abc" + xh.Substring(xh.Length - 4))//默认密码取abc学号后4四位
                        });
                        i += 1;
                    }
                    catch
                    {
                        continue;
                    }
                }
                string str = "总共" + total + "行数据,成功处理" + i + "行数据";
                str += "\\n" + "耗时:" + (DateTime.Now.Ticks - _start) / 1000 + "ms";
                return str;
            }
        }

        /// <summary>
        /// 从CSV文件导入导师信息
        /// </summary>
        /// <param name="filename"></param>
        public static string ImportTeacherFromCSVFile(string filename)
        {
            var dt = GetTemplate("teacher");
            var data = CsvHelper.csv2dt(filename, 1, dt);
            if (data.Rows.Count < 1)
            {
                return "没有数据或数据格式不正确";
            }
            var dal = new DAL.t_teacher();
            lock (dal)//锁定
            {
                int i = 0;
                int total = data.Rows.Count;
                var _start = DateTime.Now.Ticks; // 开始时间
                foreach (DataRow item in data.Rows)
                {
                    try
                    {
                        string gh = item["工号"].ToString();
                        dal.Add(new Model.t_teacher
                        {
                            teacher_dept_id = item["系别UUID"].ToString(),
                            teacher_major_id = item["专业UUID"].ToString(),
                            teacher_gh = gh,
                            teacher_name = item["姓名"].ToString(),
                            teacher_type = int.Parse(item["导师类型"].ToString()),
                            teacher_pwd = Utils.HashPasswd("abc" + gh.Substring(gh.Length - 4))//默认密码取abc工号后4四位
                        });
                        i += 1;
                    }
                    catch
                    {
                        continue;
                    }
                }
                string str = "总共" + total + "行数据,成功处理" + i + "行数据";
                str += "\\n" + "耗时:" + (DateTime.Now.Ticks - _start) / 1000 + "ms";
                return str;
            }
        }

        /// <summary>
        /// 从CSV文件导入班级信息
        /// </summary>
        /// <param name="filename"></param>
        public static string ImportClassFromCSVFile(string filename)
        {
            var dt = GetTemplate("class");
            var data = CsvHelper.csv2dt(filename, 1, dt);
            if (data.Rows.Count < 1)
            {
                return "没有数据或数据格式不正确";
            }
            var dal = new DAL.t_class();
            lock (dal)//锁定
            {
                int i = 0;
                int total = data.Rows.Count;
                var _start = DateTime.Now.Ticks; // 开始时间
                foreach (DataRow item in data.Rows)
                {
                    try
                    {
                        dal.Add(new Model.t_class
                        {
                            class_major_id = item["专业UUID"].ToString(),
                            class_name = item["姓名"].ToString(),
                        });
                        i += 1;
                    }
                    catch
                    {
                        continue;
                    }
                }
                string str = "总共" + total + "行数据,成功处理" + i + "行数据";
                str += "\\n" + "耗时:" + (DateTime.Now.Ticks - _start) / 1000 + "ms";
                return str;
            }
        }

        /// <summary>
        /// 从CSV文件导入数据
        /// </summary>
        /// <param name="type">student,teacher,class</param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static string ImportFromCsvFile(string type, string filename)
        {
            type = type.ToLower();
            if (type.Equals("student"))
                return ImportStudentFromCSVFile(filename);
            else if (type.Equals("teacher"))
                return ImportTeacherFromCSVFile(filename);
            else if (type.Equals("class"))
                return ImportClassFromCSVFile(filename);
            else
                return "参数不正确!";
        }

        /// <summary>
        /// 获取模板
        /// </summary>
        /// <param name="type">student,teacher,class</param>
        /// <returns></returns>
        public static DataTable GetTemplate(string type)
        {
            var dt = new DataTable();
            switch (type)
            {
                case "student":
                    dt.Columns.Add("班级UUID");
                    dt.Columns.Add("学号");
                    dt.Columns.Add("姓名");
                    break;

                case "teacher":
                    dt.Columns.Add("系别UUID");
                    dt.Columns.Add("专业UUID");
                    dt.Columns.Add("工号");
                    dt.Columns.Add("姓名");
                    dt.Columns.Add("导师类型");
                    break;

                case "class":
                    dt.Columns.Add("专业UUID");
                    dt.Columns.Add("名称");
                    break;
            }
            return dt;
        }

        /// <summary>
        /// 输出模板到文件
        /// </summary>
        /// <param name="type"></param>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool GetTemplate(string type, string filename)
        {
            var dt = GetTemplate(type);
            //new Thread(() => { CsvHelper.dt2csv(filename, dt); }).Start();
            return CsvHelper.dt2csv(filename, dt);
        }

        /// <summary>
        /// 获取UUID列表
        /// </summary>
        /// <param name="type">类型:class,dept,major</param>
        /// <param name="filename">文件名</param>
        public static bool GetUUID(string type, string filename)
        {
            var dt = new DataTable();
            dt.Columns.Add("名称");
            dt.Columns.Add("UUID");
            switch (type)
            {
                case "class"://班级UUID
                    var bll_class = new BLL.t_class();
                    var c_dt = bll_class.GetAllList().Tables[0];
                    if (c_dt == null)
                        break;
                    foreach (DataRow item in c_dt.Rows)
                    {
                        var dr = dt.NewRow();
                        dr["名称"] = item["class_name"];
                        dr["UUID"] = item["class_id"];
                        dt.Rows.Add(dr);
                    }
                    break;

                case "dept"://系别UUID
                    var bll_dept = new BLL.t_dept();
                    var d_dt = bll_dept.GetAllList().Tables[0];
                    if (d_dt == null)
                        break;
                    foreach (DataRow item in d_dt.Rows)
                    {
                        var dr = dt.NewRow();
                        dr["名称"] = item["dept_name"];
                        dr["UUID"] = item["dept_id"];
                        dt.Rows.Add(dr);
                    }
                    break;

                case "major"://专业UUID
                    var bll_major = new BLL.t_major();
                    var m_dt = bll_major.GetAllList().Tables[0];
                    if (m_dt == null)
                        break;
                    foreach (DataRow item in m_dt.Rows)
                    {
                        var dr = dt.NewRow();
                        dr["名称"] = item["major_name"];
                        dr["UUID"] = item["major_id"];
                        dt.Rows.Add(dr);
                    }
                    break;
            }
            //new Thread(() => { CsvHelper.dt2csv(filename, dt); }).Start();
            return CsvHelper.dt2csv(filename, dt);
        }
    }
}