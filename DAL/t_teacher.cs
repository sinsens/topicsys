using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:t_teacher
    /// </summary>
    public partial class t_teacher
    {
        public t_teacher()
        { }

        /// <summary>
        /// 操作
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DoAction(string id, int action)
        {
            var model = GetModel(id);
            model.teacher_stat = action;
            return Update(model);
        }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperMySQL.GetMaxID("id", "t_teacher");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string teacher_gh, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from t_teacher");
            strSql.Append(" where teacher_gh=@teacher_gh and id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@teacher_gh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = teacher_gh;
            parameters[1].Value = id;

            return DbHelperMySQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.t_teacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_teacher(");
            strSql.Append("teacher_gh,teacher_name,teacher_dept_id,teacher_major_id,teacher_pwd,teacher_pwd_q,teacher_pwd_a,teacher_stat,teacher_note,teacher_type)");
            strSql.Append(" values (");
            strSql.Append("@teacher_gh,@teacher_name,@teacher_dept_id,@teacher_major_id,@teacher_pwd,@teacher_pwd_q,@teacher_pwd_a,@teacher_stat,@teacher_note,@teacher_type)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@teacher_gh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@teacher_name", MySqlDbType.VarChar,10),
                    new MySqlParameter("@teacher_dept_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@teacher_major_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@teacher_pwd", MySqlDbType.VarChar,60),
                    new MySqlParameter("@teacher_pwd_q", MySqlDbType.VarChar,64),
                    new MySqlParameter("@teacher_pwd_a", MySqlDbType.VarChar,64),
                    new MySqlParameter("@teacher_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@teacher_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@teacher_type", MySqlDbType.Int32,1)};
            parameters[0].Value = model.teacher_gh;
            parameters[1].Value = model.teacher_name;
            parameters[2].Value = model.teacher_dept_id;
            parameters[3].Value = model.teacher_major_id;
            parameters[4].Value = model.teacher_pwd;
            parameters[5].Value = model.teacher_pwd_q;
            parameters[6].Value = model.teacher_pwd_a;
            parameters[7].Value = model.teacher_stat;
            parameters[8].Value = model.teacher_note;
            parameters[9].Value = model.teacher_type;

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
        public bool Update(Topicsys.Model.t_teacher model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update t_teacher set ");
            strSql.Append("teacher_name=@teacher_name,");
            strSql.Append("teacher_dept_id=@teacher_dept_id,");
            strSql.Append("teacher_major_id=@teacher_major_id,");
            strSql.Append("teacher_pwd=@teacher_pwd,");
            strSql.Append("teacher_pwd_q=@teacher_pwd_q,");
            strSql.Append("teacher_pwd_a=@teacher_pwd_a,");
            strSql.Append("teacher_stat=@teacher_stat,");
            strSql.Append("teacher_note=@teacher_note,");
            strSql.Append("teacher_type=@teacher_type");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@teacher_name", MySqlDbType.VarChar,10),
                    new MySqlParameter("@teacher_dept_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@teacher_major_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@teacher_pwd", MySqlDbType.VarChar,60),
                    new MySqlParameter("@teacher_pwd_q", MySqlDbType.VarChar,64),
                    new MySqlParameter("@teacher_pwd_a", MySqlDbType.VarChar,64),
                    new MySqlParameter("@teacher_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@teacher_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@teacher_type", MySqlDbType.Int32,1),
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@teacher_gh", MySqlDbType.VarChar,20)};
            parameters[0].Value = model.teacher_name;
            parameters[1].Value = model.teacher_dept_id;
            parameters[2].Value = model.teacher_major_id;
            parameters[3].Value = model.teacher_pwd;
            parameters[4].Value = model.teacher_pwd_q;
            parameters[5].Value = model.teacher_pwd_a;
            parameters[6].Value = model.teacher_stat;
            parameters[7].Value = model.teacher_note;
            parameters[8].Value = model.teacher_type;
            parameters[9].Value = model.id;
            parameters[10].Value = model.teacher_gh;

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
            strSql.Append("delete from t_teacher ");
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
        public bool Delete(string teacher_gh, int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from t_teacher ");
            strSql.Append(" where teacher_gh=@teacher_gh OR id=@id ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@teacher_gh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@id", MySqlDbType.Int32,11)         };
            parameters[0].Value = teacher_gh;
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
            strSql.Append("delete from t_teacher ");
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
        public Topicsys.Model.t_teacher GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,teacher_gh,teacher_name,teacher_dept_id,teacher_major_id,teacher_pwd,teacher_pwd_q,teacher_pwd_a,teacher_stat,teacher_note,teacher_type from t_teacher ");
            strSql.Append(" where id=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32)
            };
            parameters[0].Value = id;

            Topicsys.Model.t_teacher model = new Topicsys.Model.t_teacher();
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
        public Topicsys.Model.t_teacher GetModel(string gh)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,teacher_gh,teacher_name,teacher_dept_id,teacher_major_id,teacher_pwd,teacher_pwd_q,teacher_pwd_a,teacher_stat,teacher_note,teacher_type from t_teacher ");
            strSql.Append(" where teacher_gh=@id");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.VarChar)
            };
            parameters[0].Value = gh;

            Topicsys.Model.t_teacher model = new Topicsys.Model.t_teacher();
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
        public Topicsys.Model.t_teacher DataRowToModel(DataRow row)
        {
            Topicsys.Model.t_teacher model = new Topicsys.Model.t_teacher();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["teacher_gh"] != null)
                {
                    model.teacher_gh = row["teacher_gh"].ToString();
                }
                if (row["teacher_name"] != null)
                {
                    model.teacher_name = row["teacher_name"].ToString();
                }
                if (row["teacher_dept_id"] != null)
                {
                    model.teacher_dept_id = row["teacher_dept_id"].ToString();
                }
                if (row["teacher_major_id"] != null)
                {
                    model.teacher_major_id = row["teacher_major_id"].ToString();
                }
                if (row["teacher_pwd"] != null)
                {
                    model.teacher_pwd = row["teacher_pwd"].ToString();
                }
                if (row["teacher_pwd_q"] != null)
                {
                    model.teacher_pwd_q = row["teacher_pwd_q"].ToString();
                }
                if (row["teacher_pwd_a"] != null)
                {
                    model.teacher_pwd_a = row["teacher_pwd_a"].ToString();
                }
                if (row["teacher_stat"] != null && row["teacher_stat"].ToString() != "")
                {
                    model.teacher_stat = int.Parse(row["teacher_stat"].ToString());
                }
                if (row["teacher_note"] != null)
                {
                    model.teacher_note = row["teacher_note"].ToString();
                }
                if (row["teacher_type"] != null && row["teacher_type"].ToString() != "")
                {
                    model.teacher_type = int.Parse(row["teacher_type"].ToString());
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
            strSql.Append("select id,teacher_gh,teacher_name,teacher_dept_id,teacher_major_id,teacher_pwd,teacher_pwd_q,teacher_pwd_a,teacher_stat,teacher_note,teacher_type ");
            strSql.Append(" FROM t_teacher ");
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
            strSql.Append("select count(1) FROM t_teacher ");
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
            strSql.Append(")AS Row, T.*  from t_teacher T ");
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
			parameters[0].Value = "t_teacher";
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