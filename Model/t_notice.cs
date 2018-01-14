using System;
using System.Collections.Generic;

namespace Topicsys.Model
{
    /// <summary>
    /// t_notice:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class t_notice
    {
        public t_notice()
        { }

        #region Model

        private int _id;
        private int _notice_type = 0;
        private string _notice_title;
        private string _notice_body;
        private string _notice_user_name;
        private DateTime _notice_date = DateTime.Now;

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
        public int notice_type
        {
            set { _notice_type = value; }
            get { return _notice_type; }
        }

        /// <summary>
        ///
        /// </summary>
        public string notice_title
        {
            set { _notice_title = value; }
            get { return _notice_title; }
        }

        /// <summary>
        ///
        /// </summary>
        public string notice_body
        {
            set { _notice_body = value; }
            get { return _notice_body; }
        }

        /// <summary>
        ///
        /// </summary>
        public string notice_user_name
        {
            set { _notice_user_name = value; }
            get { return _notice_user_name; }
        }

        /// <summary>
        ///
        /// </summary>
        public DateTime notice_date
        {
            set { _notice_date = value; }
            get { return _notice_date; }
        }

        /*
        public static implicit operator List<object>(t_notice v)
        {
            throw new NotImplementedException();
        }*/

        #endregion Model
    }
}