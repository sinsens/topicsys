using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:t_notice
    /// </summary>
    public partial class t_notice
    {
        /// <summary>
        /// 定义公告内容最大长度
        /// 2017年12月24日,sinsen
        /// </summary>
        private int body_size = 4096;

        public t_notice()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "t_notice");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_notice");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.t_notice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_notice(");
            strSql.Append("notice_type,notice_title,notice_body,notice_user_name,notice_date)");
            strSql.Append(" values (");
            strSql.Append("@notice_type,@notice_title,@notice_body,@notice_user_name,@notice_date)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@notice_type", MySqlDbType.Int32,1),
                    new MySqlParameter("@notice_title", MySqlDbType.VarChar,64),
                    new MySqlParameter("@notice_body", MySqlDbType.Text,body_size),
                    new MySqlParameter("@notice_user_name", MySqlDbType.VarChar,32),
                    new MySqlParameter("@notice_date", MySqlDbType.DateTime)};
            parameters[0].Value = model.notice_type;
            parameters[1].Value = model.notice_title;
            parameters[2].Value = model.notice_body;
            parameters[3].Value = model.notice_user_name;
            parameters[4].Value = model.notice_date;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Topicsys.Model.t_notice model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_notice set ");
            strSql.Append("notice_type=@notice_type,");
            strSql.Append("notice_title=@notice_title,");
            strSql.Append("notice_body=@notice_body,");
            strSql.Append("notice_user_name=@notice_user_name,");
            strSql.Append("notice_date=@notice_date");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@notice_type", MySqlDbType.Int32,1),
                    new MySqlParameter("@notice_title", MySqlDbType.VarChar,64),
                    new MySqlParameter("@notice_body", MySqlDbType.Text,body_size),
                    new MySqlParameter("@notice_user_name", MySqlDbType.VarChar,32),
                    new MySqlParameter("@notice_date", MySqlDbType.DateTime),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.notice_type;
            parameters[1].Value = model.notice_title;
            parameters[2].Value = model.notice_body;
            parameters[3].Value = model.notice_user_name;
            parameters[4].Value = model.notice_date;
            parameters[5].Value = model.id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_notice ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_notice ");
            strSql.Append(" where id in (" + idlist + ")  ");
            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Topicsys.Model.t_notice GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,notice_type,notice_title,notice_body,notice_user_name,notice_date from t_notice ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_notice model = new Topicsys.Model.t_notice();
            DataSet ds = DbHelperMySQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Topicsys.Model.t_notice DataRowToModel(DataRow row)
        {
            Topicsys.Model.t_notice model = new Topicsys.Model.t_notice();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["notice_type"] != null && row["notice_type"].ToString() != "")
                {
                    model.notice_type = int.Parse(row["notice_type"].ToString());
                }
                if (row["notice_title"] != null)
                {
                    model.notice_title = row["notice_title"].ToString();
                }
                if (row["notice_body"] != null)
                {
                    model.notice_body = row["notice_body"].ToString();
                }
                if (row["notice_user_name"] != null)
                {
                    model.notice_user_name = row["notice_user_name"].ToString();
                }
                if (row["notice_date"] != null && row["notice_date"].ToString() != "")
                {
                    model.notice_date = DateTime.Parse(row["notice_date"].ToString());
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,notice_type,notice_title,notice_body,notice_user_name,notice_date ");
            strSql.Append(" FROM t_notice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_notice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int num, int page)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT DISTINCT * FROM t_notice ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            if (!string.IsNullOrEmpty(orderby))
            {
                strSql.Append(" ORDER BY " + orderby);
            }
            num = Math.Abs(num);
            page = Math.Abs((page - 1) * num);
            strSql.AppendFormat(" LIMIT {0},{1}", page, num);
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "t_notice";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion BasicMethod
    }
}