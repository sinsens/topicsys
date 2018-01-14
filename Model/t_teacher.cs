using System;

namespace Topicsys.Model
{
    /// <summary>
    /// t_teacher:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_teacher
    {
        public t_teacher()
        { }

        #region Model

        private int _id;
        private string _teacher_gh;
        private string _teacher_name;
        private string _teacher_dept_id;
        private string _teacher_major_id;
        private string _teacher_pwd;
        private string _teacher_pwd_q;
        private string _teacher_pwd_a;
        private int _teacher_stat = 0;
        private string _teacher_note;
        private int _teacher_type = 0;

        /// <summary>
        /// auto_increment
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string teacher_gh
        {
            set { _teacher_gh = value; }
            get { return _teacher_gh; }
        }

        /// <summary>
        ///
        /// </summary>
        public string teacher_name
        {
            set { _teacher_name = value; }
            get { return _teacher_name; }
        }

        /// <summary>
        ///
        /// </summary>
        public string teacher_dept_id
        {
            set { _teacher_dept_id = value; }
            get { return _teacher_dept_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string teacher_major_id
        {
            set { _teacher_major_id = value; }
            get { return _teacher_major_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string teacher_pwd
        {
            set { _teacher_pwd = value; }
            get { return _teacher_pwd; }
        }

        /// <summary>
        ///
        /// </summary>
        public string teacher_pwd_q
        {
            set { _teacher_pwd_q = value; }
            get { return _teacher_pwd_q; }
        }

        /// <summary>
        ///
        /// </summary>
        public string teacher_pwd_a
        {
            set { _teacher_pwd_a = value; }
            get { return _teacher_pwd_a; }
        }

        /// <summary>
        ///
        /// </summary>
        public int teacher_stat
        {
            set { _teacher_stat = value; }
            get { return _teacher_stat; }
        }

        /// <summary>
        ///
        /// </summary>
        public string teacher_note
        {
            set { _teacher_note = value; }
            get { return _teacher_note; }
        }

        /// <summary>
        ///
        /// </summary>
        public int teacher_type
        {
            set { _teacher_type = value; }
            get { return _teacher_type; }
        }

        #endregion Model
    }
}