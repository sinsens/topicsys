using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Topicsys.DAL
{
	/// <summary>
	/// 数据访问类:v_major
	/// </summary>
	public partial class v_major
	{
		public v_major()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Topicsys.Model.v_major model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into v_major(");
			strSql.Append("id,major_id,major_name,major_dept_id,major_stat,major_note,dept_name)");
			strSql.Append(" values (");
			strSql.Append("@id,@major_id,@major_name,@major_dept_id,@major_stat,@major_note,@dept_name)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@major_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@major_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@major_dept_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@major_stat", MySqlDbType.Int32,1),
					new MySqlParameter("@major_note", MySqlDbType.VarChar,255),
					new MySqlParameter("@dept_name", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.major_id;
			parameters[2].Value = model.major_name;
			parameters[3].Value = model.major_dept_id;
			parameters[4].Value = model.major_stat;
			parameters[5].Value = model.major_note;
			parameters[6].Value = model.dept_name;

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
		public bool Update(Topicsys.Model.v_major model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_major set ");
			strSql.Append("id=@id,");
			strSql.Append("major_id=@major_id,");
			strSql.Append("major_name=@major_name,");
			strSql.Append("major_dept_id=@major_dept_id,");
			strSql.Append("major_stat=@major_stat,");
			strSql.Append("major_note=@major_note,");
			strSql.Append("dept_name=@dept_name");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@major_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@major_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@major_dept_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@major_stat", MySqlDbType.Int32,1),
					new MySqlParameter("@major_note", MySqlDbType.VarChar,255),
					new MySqlParameter("@dept_name", MySqlDbType.VarChar,64)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.major_id;
			parameters[2].Value = model.major_name;
			parameters[3].Value = model.major_dept_id;
			parameters[4].Value = model.major_stat;
			parameters[5].Value = model.major_note;
			parameters[6].Value = model.dept_name;

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
			strSql.Append("delete from v_major ");
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
		public Topicsys.Model.v_major GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,major_id,major_name,major_dept_id,major_stat,major_note,dept_name from v_major ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Topicsys.Model.v_major model=new Topicsys.Model.v_major();
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
		public Topicsys.Model.v_major DataRowToModel(DataRow row)
		{
			Topicsys.Model.v_major model=new Topicsys.Model.v_major();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
				}
				if(row["major_id"]!=null)
				{
					model.major_id=row["major_id"].ToString();
				}
				if(row["major_name"]!=null)
				{
					model.major_name=row["major_name"].ToString();
				}
				if(row["major_dept_id"]!=null)
				{
					model.major_dept_id=row["major_dept_id"].ToString();
				}
				if(row["major_stat"]!=null && row["major_stat"].ToString()!="")
				{
					model.major_stat=int.Parse(row["major_stat"].ToString());
				}
				if(row["major_note"]!=null)
				{
					model.major_note=row["major_note"].ToString();
				}
				if(row["dept_name"]!=null)
				{
					model.dept_name=row["dept_name"].ToString();
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
			strSql.Append("select id,major_id,major_name,major_dept_id,major_stat,major_note,dept_name ");
			strSql.Append(" FROM v_major ");
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
			strSql.Append("select count(1) FROM v_major ");
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
			strSql.Append(")AS Row, T.*  from v_major T ");
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
			parameters[0].Value = "v_major";
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

