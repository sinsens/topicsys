using System;

namespace Topicsys.Model
{
    /// <summary>
    /// t_major:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_major
    {
        public t_major()
        { }

        #region Model

        private int _id;
        private string _major_id = System.Guid.NewGuid().ToString();
        private string _major_name;
        private string _major_dept_id;
        private int _major_stat = 0;
        private string _major_note;

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
        public string major_id
        {
            set { _major_id = value; }
            get { return _major_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string major_name
        {
            set { _major_name = value; }
            get { return _major_name; }
        }

        /// <summary>
        ///
        /// </summary>
        public string major_dept_id
        {
            set { _major_dept_id = value; }
            get { return _major_dept_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public int major_stat
        {
            set { _major_stat = value; }
            get { return _major_stat; }
        }

        /// <summary>
        ///
        /// </summary>
        public string major_note
        {
            set { _major_note = value; }
            get { return _major_note; }
        }

        #endregion Model
    }
}