using System;

namespace Topicsys.Model
{
    /// <summary>
    /// t_log:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_log
    {
        public t_log()
        { }

        #region Model

        private int _id;
        private string _user_name;
        private string _log_ip;
        private string _log_info;
        private DateTime _log_date = DateTime.Now;

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
        public string user_name
        {
            set { _user_name = value; }
            get { return _user_name; }
        }

        /// <summary>
        ///
        /// </summary>
        public string log_ip
        {
            set { _log_ip = value; }
            get { return _log_ip; }
        }

        /// <summary>
        ///
        /// </summary>
        public string log_info
        {
            set { _log_info = value; }
            get { return _log_info; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime log_date
        {
            set { _log_date = value; }
            get { return _log_date; }
        }

        #endregion Model
    }
}