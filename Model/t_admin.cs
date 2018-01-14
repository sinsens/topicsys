using System;
namespace Topicsys.Model
{
	/// <summary>
	/// t_admin:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_admin
	{
		public t_admin()
		{}
		#region Model
		private int _id;
		private string _user_name;
		private string _pwd;
		private int _user_stat=0;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string user_name
		{
			set{ _user_name=value;}
			get{return _user_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int user_stat
		{
			set{ _user_stat=value;}
			get{return _user_stat;}
		}
		#endregion Model

	}
}

