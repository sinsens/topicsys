using System;

namespace Topicsys.Model
{
    /// <summary>
    /// t_select:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_select
    {
        public t_select()
        { }

        #region Model

        private int _id;
        private string _select_id = System.Guid.NewGuid().ToString();
        private string _select_student_xh;
        private string _select_topic_id;
        private int _select_stat = 0;

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
        public string select_id
        {
            set { _select_id = value; }
            get { return _select_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string select_student_xh
        {
            set { _select_student_xh = value; }
            get { return _select_student_xh; }
        }

        /// <summary>
        ///
        /// </summary>
        public string select_topic_id
        {
            set { _select_topic_id = value; }
            get { return _select_topic_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public int select_stat
        {
            set { _select_stat = value; }
            get { return _select_stat; }
        }

        #endregion Model
    }
}