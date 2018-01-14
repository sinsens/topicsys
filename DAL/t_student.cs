using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:t_student
    /// </summary>
    public partial class t_student
    {
        public t_student()
        { }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DoAction(string id, int action)
        {
            var model = GetModel(id);
            model.student_stat = action;
            return Update(model);
        }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "t_student");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_student");
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
        public bool Add(Topicsys.Model.t_student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_student(");
            strSql.Append("student_xh,student_name,student_class_id,student_pwd,student_pwd_q,student_pwd_a,student_stat,student_note)");
            strSql.Append(" values (");
            strSql.Append("@student_xh,@student_name,@student_class_id,@student_pwd,@student_pwd_q,@student_pwd_a,@student_stat,@student_note)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@student_xh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@student_name", MySqlDbType.VarChar,10),
                    new MySqlParameter("@student_class_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@student_pwd", MySqlDbType.VarChar,60),
                    new MySqlParameter("@student_pwd_q", MySqlDbType.VarChar,64),
                    new MySqlParameter("@student_pwd_a", MySqlDbType.VarChar,64),
                    new MySqlParameter("@student_stat", MySqlDbType.Int32,11),
                    new MySqlParameter("@student_note", MySqlDbType.VarChar,255)};
            parameters[0].Value = model.student_xh;
            parameters[1].Value = model.student_name;
            parameters[2].Value = model.student_class_id;
            parameters[3].Value = model.student_pwd;
            parameters[4].Value = model.student_pwd_q;
            parameters[5].Value = model.student_pwd_a;
            parameters[6].Value = model.student_stat;
            parameters[7].Value = model.student_note;

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
        public bool Update(Topicsys.Model.t_student model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_student set ");
            strSql.Append("student_xh=@student_xh,");
            strSql.Append("student_name=@student_name,");
            strSql.Append("student_class_id=@student_class_id,");
            strSql.Append("student_pwd=@student_pwd,");
            strSql.Append("student_pwd_q=@student_pwd_q,");
            strSql.Append("student_pwd_a=@student_pwd_a,");
            strSql.Append("student_stat=@student_stat,");
            strSql.Append("student_note=@student_note");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@student_xh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@student_name", MySqlDbType.VarChar,10),
                    new MySqlParameter("@student_class_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@student_pwd", MySqlDbType.VarChar,60),
                    new MySqlParameter("@student_pwd_q", MySqlDbType.VarChar,64),
                    new MySqlParameter("@student_pwd_a", MySqlDbType.VarChar,64),
                    new MySqlParameter("@student_stat", MySqlDbType.Int32,11),
                    new MySqlParameter("@student_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)};
            parameters[0].Value = model.student_xh;
            parameters[1].Value = model.student_name;
            parameters[2].Value = model.student_class_id;
            parameters[3].Value = model.student_pwd;
            parameters[4].Value = model.student_pwd_q;
            parameters[5].Value = model.student_pwd_a;
            parameters[6].Value = model.student_stat;
            parameters[7].Value = model.student_note;
            parameters[8].Value = model.id;

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
            strSql.Append("delete from t_student ");
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
            strSql.Append("delete from t_student ");
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
        public Topicsys.Model.t_student GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,student_xh,student_name,student_class_id,student_pwd,student_pwd_q,student_pwd_a,student_stat,student_note from t_student ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_student model = new Topicsys.Model.t_student();
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
        public Topicsys.Model.t_student GetModel(string xh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,student_xh,student_name,student_class_id,student_pwd,student_pwd_q,student_pwd_a,student_stat,student_note from t_student ");
            strSql.Append(" where student_xh=@xh");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@xh", MySqlDbType.VarChar)
            };
            parameters[0].Value = xh;

            Topicsys.Model.t_student model = new Topicsys.Model.t_student();
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
        public Topicsys.Model.t_student DataRowToModel(DataRow row)
        {
            Topicsys.Model.t_student model = new Topicsys.Model.t_student();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["student_xh"] != null)
                {
                    model.student_xh = row["student_xh"].ToString();
                }
                if (row["student_name"] != null)
                {
                    model.student_name = row["student_name"].ToString();
                }
                if (row["student_class_id"] != null)
                {
                    model.student_class_id = row["student_class_id"].ToString();
                }
                if (row["student_pwd"] != null)
                {
                    model.student_pwd = row["student_pwd"].ToString();
                }
                if (row["student_pwd_q"] != null)
                {
                    model.student_pwd_q = row["student_pwd_q"].ToString();
                }
                if (row["student_pwd_a"] != null)
                {
                    model.student_pwd_a = row["student_pwd_a"].ToString();
                }
                if (row["student_stat"] != null && row["student_stat"].ToString() != "")
                {
                    model.student_stat = int.Parse(row["student_stat"].ToString());
                }
                if (row["student_note"] != null)
                {
                    model.student_note = row["student_note"].ToString();
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
            strSql.Append("select id,student_xh,student_name,student_class_id,student_pwd,student_pwd_q,student_pwd_a,student_stat,student_note ");
            strSql.Append(" FROM t_student ");
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
            strSql.Append("select count(1) FROM t_student ");
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
            strSql.Append(")AS Row, T.*  from t_student T ");
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
			parameters[0].Value = "t_student";
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