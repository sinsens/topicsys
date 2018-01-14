using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:t_dept
    /// </summary>
    public partial class t_dept
    {
        public t_dept()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "t_dept");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string dept_id, string dept_name, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_dept");
            strSql.Append(" where dept_id=@dept_id and dept_name=@dept_name and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@dept_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = dept_id;
            parameters[1].Value = dept_name;
            parameters[2].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.t_dept model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_dept(");
            strSql.Append("dept_id,dept_name,dept_note,dept_stat)");
            strSql.Append(" values (");
            strSql.Append("@dept_id,@dept_name,@dept_note,@dept_stat)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@dept_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@dept_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@dept_stat", MySqlDbType.Int32,1)};
            parameters[0].Value = model.dept_id;
            parameters[1].Value = model.dept_name;
            parameters[2].Value = model.dept_note;
            parameters[3].Value = model.dept_stat;

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
        public bool Update(Topicsys.Model.t_dept model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_dept set ");
            strSql.Append("dept_name=@dept_name,");
            strSql.Append("dept_note=@dept_note,");
            strSql.Append("dept_stat=@dept_stat");
            strSql.Append(" where id=@id");
            strSql.Append(" OR dept_id=@dept_id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@dept_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@dept_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@dept_id", MySqlDbType.VarChar,40)
            };
            parameters[0].Value = model.dept_name;
            parameters[1].Value = model.dept_note;
            parameters[2].Value = model.dept_stat;
            parameters[3].Value = model.id;
            parameters[4].Value = model.dept_id;

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
            strSql.Append("delete from t_dept ");
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
        /// 注销
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Off(int id)
        {
            var model = GetModel(id);
            model.dept_stat = 9;
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
            model.dept_stat = action;
            return Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string dept_id, string dept_name, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_dept ");
            strSql.Append(" where dept_id=@dept_id OR dept_name=@dept_name OR id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@dept_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = dept_id;
            parameters[1].Value = dept_name;
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
            strSql.Append("delete from t_dept ");
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
        public Topicsys.Model.t_dept GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,dept_id,dept_name,dept_note,dept_stat from t_dept ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_dept model = new Topicsys.Model.t_dept();
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
        public Topicsys.Model.t_dept GetModel(string id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,dept_id,dept_name,dept_note,dept_stat from t_dept ");
            strSql.Append(" where dept_id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.VarChar)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_dept model = new Topicsys.Model.t_dept();
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
        public Topicsys.Model.t_dept DataRowToModel(DataRow row)
        {
            Topicsys.Model.t_dept model = new Topicsys.Model.t_dept();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["dept_id"] != null)
                {
                    model.dept_id = row["dept_id"].ToString();
                }
                if (row["dept_name"] != null)
                {
                    model.dept_name = row["dept_name"].ToString();
                }
                if (row["dept_note"] != null)
                {
                    model.dept_note = row["dept_note"].ToString();
                }
                if (row["dept_stat"] != null && row["dept_stat"].ToString() != "")
                {
                    model.dept_stat = int.Parse(row["dept_stat"].ToString());
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
            strSql.Append("select id,dept_id,dept_name,dept_note,dept_stat ");
            strSql.Append(" FROM t_dept ");
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
            strSql.Append("select count(1) FROM t_dept ");
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
            strSql.Append(")AS Row, T.*  from t_dept T ");
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
			parameters[0].Value = "t_dept";
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