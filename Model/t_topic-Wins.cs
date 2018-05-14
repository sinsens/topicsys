using System;

namespace Topicsys.Model
{
    /// <summary>
    /// t_topic:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_topic
    {
        public t_topic()
        { }

        #region Model

        private int _id;
        private string _topic_id = System.Guid.NewGuid().ToString();
        private string _topic_teacher_gh;
        private string _topic_class_id;
        private string _topic_name;
        private string _topic_note;
        private int _topic_stat = 0;
        private int _topic_num = 0;

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
        public string topic_id
        {
            set { _topic_id = value; }
            get { return _topic_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string topic_teacher_gh
        {
            set { _topic_teacher_gh = value; }
            get { return _topic_teacher_gh; }
        }

        /// <summary>
        ///
        /// </summary>
        public string topic_class_id
        {
            set { _topic_class_id = value; }
            get { return _topic_class_id; }
        }

        /// <summary>
        ///
        /// </summary>
        public string topic_name
        {
            set { _topic_name = value; }
            get { return _topic_name; }
        }

        /// <summary>
        ///
        /// </summary>
        public string topic_note
        {
            set { _topic_note = value; }
            get { return _topic_note; }
        }

        /// <summary>
        ///
        /// </summary>
        public int topic_stat
        {
            set { _topic_stat = value; }
            get { return _topic_stat; }
        }

        /// <summary>
        ///
        /// </summary>
        public int topic_num
        {
            set { _topic_num = value; }
            get { return _topic_num; }
        }

        #endregion Model
    }
}