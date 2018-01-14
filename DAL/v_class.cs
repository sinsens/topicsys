using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Topicsys.DAL
{
	/// <summary>
	/// 数据访问类:v_class
	/// </summary>
	public partial class v_class
	{
		public v_class()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(Topicsys.Model.v_class model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into v_class(");
			strSql.Append("id,class_id,class_name,class_major_id,class_note,class_stat,dept_name,major_name,dept_id)");
			strSql.Append(" values (");
			strSql.Append("@id,@class_id,@class_name,@class_major_id,@class_note,@class_stat,@dept_name,@major_name,@dept_id)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@class_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@class_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@class_major_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@class_note", MySqlDbType.VarChar,255),
					new MySqlParameter("@class_stat", MySqlDbType.Int32,1),
					new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@major_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@dept_id", MySqlDbType.VarChar,40)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.class_id;
			parameters[2].Value = model.class_name;
			parameters[3].Value = model.class_major_id;
			parameters[4].Value = model.class_note;
			parameters[5].Value = model.class_stat;
			parameters[6].Value = model.dept_name;
			parameters[7].Value = model.major_name;
			parameters[8].Value = model.dept_id;

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
		public bool Update(Topicsys.Model.v_class model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update v_class set ");
			strSql.Append("id=@id,");
			strSql.Append("class_id=@class_id,");
			strSql.Append("class_name=@class_name,");
			strSql.Append("class_major_id=@class_major_id,");
			strSql.Append("class_note=@class_note,");
			strSql.Append("class_stat=@class_stat,");
			strSql.Append("dept_name=@dept_name,");
			strSql.Append("major_name=@major_name,");
			strSql.Append("dept_id=@dept_id");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@id", MySqlDbType.Int32,11),
					new MySqlParameter("@class_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@class_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@class_major_id", MySqlDbType.VarChar,40),
					new MySqlParameter("@class_note", MySqlDbType.VarChar,255),
					new MySqlParameter("@class_stat", MySqlDbType.Int32,1),
					new MySqlParameter("@dept_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@major_name", MySqlDbType.VarChar,64),
					new MySqlParameter("@dept_id", MySqlDbType.VarChar,40)};
			parameters[0].Value = model.id;
			parameters[1].Value = model.class_id;
			parameters[2].Value = model.class_name;
			parameters[3].Value = model.class_major_id;
			parameters[4].Value = model.class_note;
			parameters[5].Value = model.class_stat;
			parameters[6].Value = model.dept_name;
			parameters[7].Value = model.major_name;
			parameters[8].Value = model.dept_id;

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
			strSql.Append("delete from v_class ");
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
		public Topicsys.Model.v_class GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,class_id,class_name,class_major_id,class_note,class_stat,dept_name,major_name,dept_id from v_class ");
			strSql.Append(" where ");
			MySqlParameter[] parameters = {
			};

			Topicsys.Model.v_class model=new Topicsys.Model.v_class();
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
		public Topicsys.Model.v_class DataRowToModel(DataRow row)
		{
			Topicsys.Model.v_class model=new Topicsys.Model.v_class();
			if (row != null)
			{
				if(row["id"]!=null && row["id"].ToString()!="")
				{
					model.id=int.Parse(row["id"].ToString());
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
				if(row["class_note"]!=null)
				{
					model.class_note=row["class_note"].ToString();
				}
				if(row["class_stat"]!=null && row["class_stat"].ToString()!="")
				{
					model.class_stat=int.Parse(row["class_stat"].ToString());
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
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select id,class_id,class_name,class_major_id,class_note,class_stat,dept_name,major_name,dept_id ");
			strSql.Append(" FROM v_class ");
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
			strSql.Append("select count(1) FROM v_class ");
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
			strSql.Append(")AS Row, T.*  from v_class T ");
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
			parameters[0].Value = "v_class";
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

