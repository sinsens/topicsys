using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:t_select
    /// </summary>
    public partial class t_select
    {
        public t_select()
        { }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DoAction(string id, int action)
        {
            var model = GetModel(id);
            if (model == null)
            {
                return false;
            }
            model.select_stat = action;
            return Update(model);
        }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "t_select");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string select_id, string select_student_xh, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_select");
            strSql.Append(" where select_id=@select_id and select_student_xh=@select_student_xh and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@select_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@select_student_xh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = select_id;
            parameters[1].Value = select_student_xh;
            parameters[2].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.t_select model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_select(");
            strSql.Append("select_id,select_student_xh,select_topic_id,select_stat)");
            strSql.Append(" values (");
            strSql.Append("@select_id,@select_student_xh,@select_topic_id,@select_stat)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@select_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@select_student_xh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@select_topic_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@select_stat", MySqlDbType.Int32,1)};
            parameters[0].Value = model.select_id;
            parameters[1].Value = model.select_student_xh;
            parameters[2].Value = model.select_topic_id;
            parameters[3].Value = model.select_stat;

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
        public bool Update(Topicsys.Model.t_select model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_select set ");
            strSql.Append("select_topic_id=@select_topic_id,");
            strSql.Append("select_stat=@select_stat");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@select_topic_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@select_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@select_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@select_student_xh", MySqlDbType.VarChar,20)};
            parameters[0].Value = model.select_topic_id;
            parameters[1].Value = model.select_stat;
            parameters[2].Value = model.id;
            parameters[3].Value = model.select_id;
            parameters[4].Value = model.select_student_xh;

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
            strSql.Append("delete from t_select ");
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
        public bool Delete(string select_id, string select_student_xh, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_select ");
            strSql.Append(" where select_id=@select_id and select_student_xh=@select_student_xh and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@select_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@select_student_xh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = select_id;
            parameters[1].Value = select_student_xh;
            parameters[2].Value = id;

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
            strSql.Append("delete from t_select ");
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
        public Topicsys.Model.t_select GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,select_id,select_student_xh,select_topic_id,select_stat from t_select ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_select model = new Topicsys.Model.t_select();
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
        public Topicsys.Model.t_select GetModel(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,select_id,select_student_xh,select_topic_id,select_stat from t_select ");
            strSql.Append(" where select_id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.VarChar)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_select model = new Topicsys.Model.t_select();
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
        public Topicsys.Model.t_select DataRowToModel(DataRow row)
        {
            Topicsys.Model.t_select model = new Topicsys.Model.t_select();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["select_id"] != null)
                {
                    model.select_id = row["select_id"].ToString();
                }
                if (row["select_student_xh"] != null)
                {
                    model.select_student_xh = row["select_student_xh"].ToString();
                }
                if (row["select_topic_id"] != null)
                {
                    model.select_topic_id = row["select_topic_id"].ToString();
                }
                if (row["select_stat"] != null && row["select_stat"].ToString() != "")
                {
                    model.select_stat = int.Parse(row["select_stat"].ToString());
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
            strSql.Append("select id,select_id,select_student_xh,select_topic_id,select_stat ");
            strSql.Append(" FROM t_select ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperMySQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Model.t_select> GetModelList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,select_id,select_student_xh,select_topic_id,select_stat ");
            strSql.Append(" FROM t_select ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            var list = new List<Model.t_select>();
            var data = DbHelperMySQL.Query(strSql.ToString()).Tables[0];
            if (data.Rows.Count == 0)
                return null;
            for (int i = 0; i < data.Rows.Count; i++)
            {
                list.Add(DataRowToModel(data.Rows[i]));
            }
            return list;
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM t_select ");
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
            strSql.Append(")AS Row, T.*  from t_select T ");
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
			parameters[0].Value = "t_select";
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