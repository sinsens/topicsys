using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Topicsys.DAL
{
	/// <summary>
	/// 数据访问类:v_select
	/// </summary>
	public partial class v_select
	{
		public v_select()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Topicsys.Model.v_select model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into v_select(");
			strSql.Append("student_name,class_id,class_name,class_major_id,dept_name,major_name,dept_id,id,select_id,select_student_xh,select_topic_id,select_stat,topic_teacher_gh,teacher_name,topic_num,topic_name)");
			strSql.Append(" values (");
			strSql.Append("@student_name,@class_id,@class_name,@class_major_id,@dept_name,@major_name,@dept_id,@id,@select_id,@select_student_xh,@select_topic_id,@select_stat,@topic_teacher_gh,@teacher_name,@topic_num,@topic_name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@student_name", MySqlDbType.VarChar,10),
					new MySqlParameter("@class_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@class_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@class_major_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@major_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@dept_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@select_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@select_student_xh", MySqlDbType.VarChar,20),
					new MySqlParameter("@select_topic_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@select_stat", MySqlDbType.Int32,1),
					new MySqlParameter("@topic_teacher_gh", MySqlDbType.VarChar,20),
					new MySqlParameter("@teacher_name", MySqlDbType.VarChar,10),
					new MySqlParameter("@topic_num", MySqlDbType.Int32,3),
					new MySqlParameter("@topic_name", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.student_name;
			parameters[1].Value = model.class_id;
			parameters[2].Value = model.class_name;
			parameters[3].Value = model.class_major_id;
			parameters[4].Value = model.dept_name;
			parameters[5].Value = model.major_name;
			parameters[6].Value = model.dept_id;
			parameters[7].Value = model.id;
			parameters[8].Value = model.select_id;
			parameters[9].Value = model.select_student_xh;
			parameters[10].Value = model.select_topic_id;
			parameters[11].Value = model.select_stat;
			parameters[12].Value = model.topic_teacher_gh;
			parameters[13].Value = model.teacher_name;
			parameters[14].Value = model.topic_num;
			parameters[15].Value = model.topic_name;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Update(Topicsys.Model.v_select model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_select set ");
			strSql.Append("student_name=@student_name,");
			strSql.Append("class_id=@class_id,");
			strSql.Append("class_name=@class_name,");
			strSql.Append("class_major_id=@class_major_id,");
			strSql.Append("dept_name=@dept_name,");
			strSql.Append("major_name=@major_name,");
			strSql.Append("dept_id=@dept_id,");
			strSql.Append("id=@id,");
			strSql.Append("select_id=@select_id,");
			strSql.Append("select_student_xh=@select_student_xh,");
			strSql.Append("select_topic_id=@select_topic_id,");
			strSql.Append("select_stat=@select_stat,");
			strSql.Append("topic_teacher_gh=@topic_teacher_gh,");
			strSql.Append("teacher_name=@teacher_name,");
			strSql.Append("topic_num=@topic_num,");
			strSql.Append("topic_name=@topic_name");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@student_name", MySqlDbType.VarChar,10),
					new MySqlParameter("@class_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@class_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@class_major_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@major_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@dept_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@select_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@select_student_xh", MySqlDbType.VarChar,20),
					new MySqlParameter("@select_topic_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@select_stat", MySqlDbType.Int32,1),
					new MySqlParameter("@topic_teacher_gh", MySqlDbType.VarChar,20),
					new MySqlParameter("@teacher_name", MySqlDbType.VarChar,10),
					new MySqlParameter("@topic_num", MySqlDbType.Int32,3),
					new MySqlParameter("@topic_name", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.student_name;
			parameters[1].Value = model.class_id;
			parameters[2].Value = model.class_name;
			parameters[3].Value = model.class_major_id;
			parameters[4].Value = model.dept_name;
			parameters[5].Value = model.major_name;
			parameters[6].Value = model.dept_id;
			parameters[7].Value = model.id;
			parameters[8].Value = model.select_id;
			parameters[9].Value = model.select_student_xh;
			parameters[10].Value = model.select_topic_id;
			parameters[11].Value = model.select_stat;
			parameters[12].Value = model.topic_teacher_gh;
			parameters[13].Value = model.teacher_name;
			parameters[14].Value = model.topic_num;
			parameters[15].Value = model.topic_name;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from v_select ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
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
		public Topicsys.Model.v_select GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select student_name,class_id,class_name,class_major_id,dept_name,major_name,dept_id,id,select_id,select_student_xh,select_topic_id,select_stat,topic_teacher_gh,teacher_name,topic_num,topic_name from v_select ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Topicsys.Model.v_select model=new Topicsys.Model.v_select();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
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
		public Topicsys.Model.v_select DataRowToModel(DataRow row)
		{
			Topicsys.Model.v_select model=new Topicsys.Model.v_select();
			if (row != null)
			{
				if(row["student_name"]!=null)
				{
					model.student_name=row["student_name"].ToString();
				}
				if(row["class_id"]!=null)
				{
					model.class_id=row["class_id"].ToString();
				}
				if(row["class_name"]!=null)
				{
					model.class_name=row["class_name"].ToString();
				}
				if(row["class_major_id"]!=null)
				{
					model.class_major_id=row["class_major_id"].ToString();
				}
				if(row["dept_name"]!=null)
				{
					model.dept_name=row["dept_name"].ToString();
				}
				if(row["major_name"]!=null)
				{
					model.major_name=row["major_name"].ToString();
				}
				if(row["dept_id"]!=null)
				{
					model.dept_id=row["dept_id"].ToString();
				}
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["select_id"]!=null)
				{
					model.select_id=row["select_id"].ToString();
				}
				if(row["select_student_xh"]!=null)
				{
					model.select_student_xh=row["select_student_xh"].ToString();
				}
				if(row["select_topic_id"]!=null)
				{
					model.select_topic_id=row["select_topic_id"].ToString();
				}
				if(row["select_stat"]!=null && row["select_stat"].ToString()!="")
				{
					model.select_stat=int.Parse(row["select_stat"].ToString());
				}
				if(row["topic_teacher_gh"]!=null)
				{
					model.topic_teacher_gh=row["topic_teacher_gh"].ToString();
				}
				if(row["teacher_name"]!=null)
				{
					model.teacher_name=row["teacher_name"].ToString();
				}
				if(row["topic_num"]!=null && row["topic_num"].ToString()!="")
				{
					model.topic_num=int.Parse(row["topic_num"].ToString());
				}
				if(row["topic_name"]!=null)
				{
					model.topic_name=row["topic_name"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select student_name,class_id,class_name,class_major_id,dept_name,major_name,dept_id,id,select_id,select_student_xh,select_topic_id,select_stat,topic_teacher_gh,teacher_name,topic_num,topic_name ");
			strSql.Append(" FROM v_select ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM v_select ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T. desc");
			}
			strSql.Append(")AS Row, T.*  from v_select T ");
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
			parameters[0].Value = "v_select";
			parameters[1].Value = "";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

