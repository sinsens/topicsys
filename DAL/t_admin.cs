using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:t_admin
    /// </summary>
    public partial class t_admin
    {
        public t_admin()
        { }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "t_admin");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string user_name, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_admin");
            strSql.Append(" where user_name=@user_name and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@user_name", MySqlDbType.VarChar,32),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = user_name;
            parameters[1].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.t_admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_admin(");
            strSql.Append("user_name,pwd,user_stat)");
            strSql.Append(" values (");
            strSql.Append("@user_name,@pwd,@user_stat)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@user_name", MySqlDbType.VarChar,32),
                    new MySqlParameter("@pwd", MySqlDbType.VarChar,60),
                    new MySqlParameter("@user_stat", MySqlDbType.Int32,1)};
            parameters[0].Value = model.user_name;
            parameters[1].Value = model.pwd;
            parameters[2].Value = model.user_stat;

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
            model.user_stat = 9;
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
            model.user_stat = action;
            return Update(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Topicsys.Model.t_admin model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_admin set ");
            strSql.Append("pwd=@pwd,");
            strSql.Append("user_stat=@user_stat");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@pwd", MySqlDbType.VarChar,60),
                    new MySqlParameter("@user_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@user_name", MySqlDbType.VarChar,32)};
            parameters[0].Value = model.pwd;
            parameters[1].Value = model.user_stat;
            parameters[2].Value = model.id;
            parameters[3].Value = model.user_name;

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
            strSql.Append("delete from t_admin ");
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
        public bool Delete(string user_name, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_admin ");
            strSql.Append(" where user_name=@user_name and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@user_name", MySqlDbType.VarChar,32),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = user_name;
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
            strSql.Append("delete from t_admin ");
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
        public Topicsys.Model.t_admin GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,user_name,pwd,user_stat from t_admin ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_admin model = new Topicsys.Model.t_admin();
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
        public Topicsys.Model.t_admin GetModel(string user_name)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,user_name,pwd,user_stat from t_admin ");
            strSql.Append(" where user_name=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.VarChar)
            };
            parameters[0].Value = user_name;

            Topicsys.Model.t_admin model = new Topicsys.Model.t_admin();
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
        public Topicsys.Model.t_admin DataRowToModel(DataRow row)
        {
            Topicsys.Model.t_admin model = new Topicsys.Model.t_admin();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["user_name"] != null)
                {
                    model.user_name = row["user_name"].ToString();
                }
                if (row["pwd"] != null)
                {
                    model.pwd = row["pwd"].ToString();
                }
                if (row["user_stat"] != null && row["user_stat"].ToString() != "")
                {
                    model.user_stat = int.Parse(row["user_stat"].ToString());
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
            strSql.Append("select id,user_name,pwd,user_stat ");
            strSql.Append(" FROM t_admin ");
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
            strSql.Append("select count(1) FROM t_admin ");
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
            strSql.Append(")AS Row, T.*  from t_admin T ");
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
			parameters[0].Value = "t_admin";
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