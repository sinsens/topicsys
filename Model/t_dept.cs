using System;

namespace Topicsys.Model
{
    /// <summary>
    /// t_dept:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_dept
    {
        public t_dept()
        { }

        #region Model

        private int _id;
        private string _dept_id = System.Guid.NewGuid().ToString();
        private string _dept_name;
        private string _dept_note;
        private int _dept_stat = 0;

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
        public string dept_id
        {
            set { _dept_id = value; }
            get { return _dept_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string dept_name
        {
            set { _dept_name = value; }
            get { return _dept_name; }
        }

        /// <summary>
        ///
        /// </summary>
        public string dept_note
        {
            set { _dept_note = value; }
            get { return _dept_note; }
        }

        /// <summary>
        ///
        /// </summary>
        public int dept_stat
        {
            set { _dept_stat = value; }
            get { return _dept_stat; }
        }

        #endregion Model
    }
}