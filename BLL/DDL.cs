using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace Topicsys.BLL
{
    /// <summary>
    /// DropDownList专用控件
    /// </summary>
    public class DDL
    {
        /// <summary>
        /// 系别DDL
        /// </summary>
        /// <param name="dropDownList"></param>
        public static void DeptDLL(DropDownList dropDownList)
        {
            dropDownList.Items.Clear();
            var bll = new BLL.t_dept();
            var model = bll.GetModelList("dept_stat=0");
            foreach (var item in model)
            {
                dropDownList.Items.Add(new ListItem(item.dept_name, item.dept_id));
            }
        }

        /// <summary>
        /// 专业DDL
        /// </summary>
        /// <param name="dropDownList"></param>
        public static void MajorDLL(DropDownList dropDownList, string dept_id = null)
        {
            dropDownList.Items.Clear();
            var bll = new BLL.t_major();
            var model = dept_id == null ? bll.GetModelList("major_stat=0") : bll.GetModelList("major_stat=0 AND major_dept_id='" + dept_id + "'");
            foreach (var item in model)
            {
                dropDownList.Items.Add(new ListItem(item.major_name, item.major_id));
            }
        }

        /// <summary>
        /// 班级DDL
        /// </summary>
        /// <param name="dropDownList"></param>
        public static void ClassDLL(DropDownList dropDownList, string major_id = null)
        {
            dropDownList.Items.Clear();
            var bll = new BLL.t_class();
            var model = major_id == null ? bll.GetModelList("class_stat=0") : bll.GetModelList("class_stat=0 AND class_major_id='" + major_id + "'");
            foreach (var item in model)
            {
                dropDownList.Items.Add(new ListItem(item.class_name, item.class_id));
            }
        }

        /// <summary>
        /// 导师DDL
        /// </summary>
        /// <param name="dropDownList"></param>
        public static void TeacherDLL(DropDownList dropDownList, string major_id = null)
        {
            dropDownList.Items.Clear();
            var bll = new BLL.t_teacher();
            var model = major_id == null ? bll.GetModelList("teacher_stat=0 AND teacher_type=0") : bll.GetModelList("teacher_stat=0 AND teacher_type=0 AND teacher_major_id='" + major_id + "'");
            foreach (var item in model)
            {
                dropDownList.Items.Add(new ListItem(item.teacher_name, item.teacher_gh));
            }
        }

        /// <summary>
        /// 题目DDL
        /// </summary>
        /// <param name="dropDownList"></param>
        public static void TopicDLL(DropDownList dropDownList, string major_id = null)
        {
            dropDownList.Items.Clear();
            var bll = new BLL.t_topic();
            var model = major_id == null ? bll.GetModelList("topic_stat=5") : bll.GetModelList("topic_stat=5 AND topic_class_id='" + major_id + "'");
            foreach (var item in model)
            {
                dropDownList.Items.Add(new ListItem(item.topic_name, item.topic_id));
            }
        }
    }
}