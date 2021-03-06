﻿using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:t_major
    /// </summary>
    public partial class t_major
    {
        public t_major()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "t_major");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string major_id, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_major");
            strSql.Append(" where major_id=@major_id and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@major_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = major_id;
            parameters[1].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.t_major model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_major(");
            strSql.Append("major_id,major_name,major_dept_id,major_stat,major_note)");
            strSql.Append(" values (");
            strSql.Append("@major_id,@major_name,@major_dept_id,@major_stat,@major_note)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@major_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@major_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@major_dept_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@major_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@major_note", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.major_id;
            parameters[1].Value = model.major_name;
            parameters[2].Value = model.major_dept_id;
            parameters[3].Value = model.major_stat;
            parameters[4].Value = model.major_note;

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
        public bool Update(Topicsys.Model.t_major model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_major set ");
            strSql.Append("major_name=@major_name,");
            strSql.Append("major_dept_id=@major_dept_id,");
            strSql.Append("major_stat=@major_stat,");
            strSql.Append("major_note=@major_note");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@major_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@major_dept_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@major_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@major_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@major_id", MySqlDbType.VarChar,40)};
            parameters[0].Value = model.major_name;
            parameters[1].Value = model.major_dept_id;
            parameters[2].Value = model.major_stat;
            parameters[3].Value = model.major_note;
            parameters[4].Value = model.id;
            parameters[5].Value = model.major_id;

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
            strSql.Append("delete from t_major ");
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
        public bool Delete(string major_id, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_major ");
            strSql.Append(" where major_id=@major_id OR id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@major_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = major_id;
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
            strSql.Append("delete from t_major ");
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
        public Topicsys.Model.t_major GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,major_id,major_name,major_dept_id,major_stat,major_note from t_major ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_major model = new Topicsys.Model.t_major();
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
        public Topicsys.Model.t_major GetModel(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,major_id,major_name,major_dept_id,major_stat,major_note from t_major ");
            strSql.Append(" where major_id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.VarChar)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_major model = new Topicsys.Model.t_major();
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
        public Topicsys.Model.t_major DataRowToModel(DataRow row)
        {
            Topicsys.Model.t_major model = new Topicsys.Model.t_major();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["major_id"] != null)
                {
                    model.major_id = row["major_id"].ToString();
                }
                if (row["major_name"] != null)
                {
                    model.major_name = row["major_name"].ToString();
                }
                if (row["major_dept_id"] != null)
                {
                    model.major_dept_id = row["major_dept_id"].ToString();
                }
                if (row["major_stat"] != null && row["major_stat"].ToString() != "")
                {
                    model.major_stat = int.Parse(row["major_stat"].ToString());
                }
                if (row["major_note"] != null)
                {
                    model.major_note = row["major_note"].ToString();
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
            strSql.Append("select id,major_id,major_name,major_dept_id,major_stat,major_note ");
            strSql.Append(" FROM t_major ");
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
            strSql.Append("select count(1) FROM t_major ");
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
            strSql.Append(")AS Row, T.*  from t_major T ");
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
			parameters[0].Value = "t_major";
			parameters[1].Value = "id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

        #endregion BasicMethod

        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Off(int id)
        {
            var model = GetModel(id);
            model.major_stat = 9;
            return Update(model);
        }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DoAction(string id, int action)
        {
            var model = GetModel(id);
            model.major_stat = action;
            return Update(model);
        }
    }
}