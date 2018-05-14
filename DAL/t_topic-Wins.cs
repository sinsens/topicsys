using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:t_topic
    /// </summary>
    public partial class t_topic
    {
        public t_topic()
        { }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DoAction(string id, int action)
        {
            var model = GetModel(id);
            model.topic_stat = action;
            return Update(model);
        }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "t_topic");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string topic_id, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_topic");
            strSql.Append(" where topic_id=@topic_id and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@topic_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = topic_id;
            parameters[1].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.t_topic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_topic(");
            strSql.Append("topic_id,topic_teacher_gh,topic_class_id,topic_name,topic_note,topic_stat,topic_num)");
            strSql.Append(" values (");
            strSql.Append("@topic_id,@topic_teacher_gh,@topic_class_id,@topic_name,@topic_note,@topic_stat,@topic_num)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@topic_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@topic_teacher_gh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@topic_class_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@topic_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@topic_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@topic_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@topic_num", MySqlDbType.Int32,3)};
            parameters[0].Value = model.topic_id;
            parameters[1].Value = model.topic_teacher_gh;
            parameters[2].Value = model.topic_class_id;
            parameters[3].Value = model.topic_name;
            parameters[4].Value = model.topic_note;
            parameters[5].Value = model.topic_stat;
            parameters[6].Value = model.topic_num;

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
        public bool Update(Topicsys.Model.t_topic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_topic set ");
            strSql.Append("topic_teacher_gh=@topic_teacher_gh,");
            strSql.Append("topic_class_id=@topic_class_id,");
            strSql.Append("topic_name=@topic_name,");
            strSql.Append("topic_note=@topic_note,");
            strSql.Append("topic_stat=@topic_stat,");
            strSql.Append("topic_num=@topic_num");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@topic_teacher_gh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@topic_class_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@topic_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@topic_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@topic_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@topic_num", MySqlDbType.Int32,3),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@topic_id", MySqlDbType.VarChar,40)};
            parameters[0].Value = model.topic_teacher_gh;
            parameters[1].Value = model.topic_class_id;
            parameters[2].Value = model.topic_name;
            parameters[3].Value = model.topic_note;
            parameters[4].Value = model.topic_stat;
            parameters[5].Value = model.topic_num;
            parameters[6].Value = model.id;
            parameters[7].Value = model.topic_id;

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
            strSql.Append("delete from t_topic ");
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
        /// 删除一条数据
        /// </summary>
        public bool Delete(string topic_id, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_topic ");
            strSql.Append(" where topic_id=@topic_id and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@topic_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = topic_id;
            parameters[1].Value = id;

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
            strSql.Append("delete from t_topic ");
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
        public Topicsys.Model.t_topic GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,topic_id,topic_teacher_gh,topic_class_id,topic_name,topic_note,topic_stat,topic_num from t_topic ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_topic model = new Topicsys.Model.t_topic();
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
        public Topicsys.Model.t_topic GetModel(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,topic_id,topic_teacher_gh,topic_class_id,topic_name,topic_note,topic_stat,topic_num from t_topic ");
            strSql.Append(" where topic_id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.VarChar)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_topic model = new Topicsys.Model.t_topic();
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
        public Topicsys.Model.t_topic DataRowToModel(DataRow row)
        {
            Topicsys.Model.t_topic model = new Topicsys.Model.t_topic();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["topic_id"] != null)
                {
                    model.topic_id = row["topic_id"].ToString();
                }
                if (row["topic_teacher_gh"] != null)
                {
                    model.topic_teacher_gh = row["topic_teacher_gh"].ToString();
                }
                if (row["topic_class_id"] != null)
                {
                    model.topic_class_id = row["topic_class_id"].ToString();
                }
                if (row["topic_name"] != null)
                {
                    model.topic_name = row["topic_name"].ToString();
                }
                if (row["topic_note"] != null)
                {
                    model.topic_note = row["topic_note"].ToString();
                }
                if (row["topic_stat"] != null && row["topic_stat"].ToString() != "")
                {
                    model.topic_stat = int.Parse(row["topic_stat"].ToString());
                }
                if (row["topic_num"] != null && row["topic_num"].ToString() != "")
                {
                    model.topic_num = int.Parse(row["topic_num"].ToString());
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
            strSql.Append("select id,topic_id,topic_teacher_gh,topic_class_id,topic_name,topic_note,topic_stat,topic_num ");
            strSql.Append(" FROM t_topic ");
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
            strSql.Append("select count(1) FROM t_topic ");
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
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.id desc");
            }
            strSql.Append(")AS Row, T.*  from t_topic T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
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
			parameters[0].Value = "t_topic";
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