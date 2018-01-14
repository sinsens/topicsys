using System;

namespace Topicsys.Model
{
    /// <summary>
    /// t_class:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_class
    {
        public t_class()
        { }

        #region Model

        private int _id;
        private string _class_id = System.Guid.NewGuid().ToString();
        private string _class_name;
        private string _class_major_id;
        private string _class_note;
        private int _class_stat = 0;

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
        public string class_id
        {
            set { _class_id = value; }
            get { return _class_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string class_name
        {
            set { _class_name = value; }
            get { return _class_name; }
        }

        /// <summary>
        ///
        /// </summary>
        public string class_major_id
        {
            set { _class_major_id = value; }
            get { return _class_major_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string class_note
        {
            set { _class_note = value; }
            get { return _class_note; }
        }

        /// <summary>
        ///
        /// </summary>
        public int class_stat
        {
            set { _class_stat = value; }
            get { return _class_stat; }
        }

        #endregion Model
    }
}