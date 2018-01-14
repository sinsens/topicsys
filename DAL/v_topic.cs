using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references

namespace Topicsys.DAL
{
    /// <summary>
    /// 数据访问类:v_topic
    /// </summary>
    public partial class v_topic
    {
        public v_topic()
        { }

        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.v_topic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into v_topic(");
            strSql.Append("id,topic_id,topic_teacher_gh,topic_class_id,topic_name,topic_note,topic_stat,topic_num,teacher_name,dept_name,class_name,select_sum,teacher_dept_id)");
            strSql.Append(" values (");
            strSql.Append("@id,@topic_id,@topic_teacher_gh,@topic_class_id,@topic_name,@topic_note,@topic_stat,@topic_num,@teacher_name,@dept_name,@class_name,@select_sum,@teacher_dept_id)");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@topic_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@topic_teacher_gh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@topic_class_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@topic_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@topic_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@topic_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@topic_num", MySqlDbType.Int32,3),
                    new MySqlParameter("@teacher_name", MySqlDbType.VarChar,10),
                    new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@class_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@select_sum", MySqlDbType.Int32,3),
                    new MySqlParameter("@teacher_dept_id", MySqlDbType.VarChar,40)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.topic_id;
            parameters[2].Value = model.topic_teacher_gh;
            parameters[3].Value = model.topic_class_id;
            parameters[4].Value = model.topic_name;
            parameters[5].Value = model.topic_note;
            parameters[6].Value = model.topic_stat;
            parameters[7].Value = model.topic_num;
            parameters[8].Value = model.teacher_name;
            parameters[9].Value = model.dept_name;
            parameters[10].Value = model.class_name;
            parameters[11].Value = model.select_sum;
            parameters[12].Value = model.teacher_dept_id;

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
        public bool Update(Topicsys.Model.v_topic model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update v_topic set ");
            strSql.Append("id=@id,");
            strSql.Append("topic_id=@topic_id,");
            strSql.Append("topic_teacher_gh=@topic_teacher_gh,");
            strSql.Append("topic_class_id=@topic_class_id,");
            strSql.Append("topic_name=@topic_name,");
            strSql.Append("topic_note=@topic_note,");
            strSql.Append("topic_stat=@topic_stat,");
            strSql.Append("topic_num=@topic_num,");
            strSql.Append("teacher_name=@teacher_name,");
            strSql.Append("dept_name=@dept_name,");
            strSql.Append("class_name=@class_name,");
            strSql.Append("select_sum=@select_sum,");
            strSql.Append("teacher_dept_id=@teacher_dept_id");
            strSql.Append(" where ");
            MySqlParameter[] parameters = {
                    new MySqlParameter("@id", MySqlDbType.Int32,11),
                    new MySqlParameter("@topic_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@topic_teacher_gh", MySqlDbType.VarChar,20),
                    new MySqlParameter("@topic_class_id", MySqlDbType.VarChar,40),
                    new MySqlParameter("@topic_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@topic_note", MySqlDbType.VarChar,255),
                    new MySqlParameter("@topic_stat", MySqlDbType.Int32,1),
                    new MySqlParameter("@topic_num", MySqlDbType.Int32,3),
                    new MySqlParameter("@teacher_name", MySqlDbType.VarChar,10),
                    new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@class_name", MySqlDbType.VarChar,64),
                    new MySqlParameter("@select_sum", MySqlDbType.Int32,3),
                    new MySqlParameter("@teacher_dept_id", MySqlDbType.VarChar,40)};
            parameters[0].Value = model.id;
            parameters[1].Value = model.topic_id;
            parameters[2].Value = model.topic_teacher_gh;
            parameters[3].Value = model.topic_class_id;
            parameters[4].Value = model.topic_name;
            parameters[5].Value = model.topic_note;
            parameters[6].Value = model.topic_stat;
            parameters[7].Value = model.topic_num;
            parameters[8].Value = model.teacher_name;
            parameters[9].Value = model.dept_name;
            parameters[10].Value = model.class_name;
            parameters[11].Value = model.select_sum;
            parameters[12].Value = model.teacher_dept_id;

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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from v_topic ");
            strSql.Append(" where ");
            MySqlParameter[] parameters = {
            };

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
        /// 得到一个对象实体
        /// </summary>
        public Topicsys.Model.v_topic GetModel(string id)
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,topic_id,topic_teacher_gh,topic_class_id,topic_name,topic_note,topic_stat,topic_num,teacher_name,dept_name,class_name,select_sum,teacher_dept_id from v_topic ");
            strSql.Append(" where topic_id=@id");
            MySqlParameter[] parameters = {
                new MySqlParameter("@id", MySqlDbType.VarChar),
            };
            parameters[0].Value = id;

            Topicsys.Model.v_topic model = new Topicsys.Model.v_topic();
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
        public Topicsys.Model.v_topic DataRowToModel(DataRow row)
        {
            Topicsys.Model.v_topic model = new Topicsys.Model.v_topic();
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
                if (row["teacher_name"] != null)
                {
                    model.teacher_name = row["teacher_name"].ToString();
                }
                if (row["dept_name"] != null)
                {
                    model.dept_name = row["dept_name"].ToString();
                }
                if (row["class_name"] != null)
                {
                    model.class_name = row["class_name"].ToString();
                }
                if (row["select_sum"] != null && row["select_sum"].ToString() != "")
                {
                    model.select_sum = long.Parse(row["select_sum"].ToString());
                }
                if (row["teacher_dept_id"] != null)
                {
                    model.teacher_dept_id = row["teacher_dept_id"].ToString();
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
            strSql.Append("select id,topic_id,topic_teacher_gh,topic_class_id,topic_name,topic_note,topic_stat,topic_num,teacher_name,dept_name,class_name,select_sum,teacher_dept_id ");
            strSql.Append(" FROM v_topic ");
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
            strSql.Append("select count(1) FROM v_topic ");
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
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from v_topic T ");
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
			parameters[0].Value = "v_topic";
			parameters[1].Value = "";
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