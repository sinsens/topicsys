using System;
namespace Topicsys.Model
{
	/// <summary>
	/// t_student:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class t_student
	{
		public t_student()
		{}
		#region Model
		private int _id;
		private string _student_xh;
		private string _student_name;
		private string _student_class_id;
		private string _student_pwd;
		private string _student_pwd_q;
		private string _student_pwd_a;
		private int _student_stat=0;
		private string _student_note;
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
		public string student_xh
		{
			set{ _student_xh=value;}
			get{return _student_xh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_name
		{
			set{ _student_name=value;}
			get{return _student_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_class_id
		{
			set{ _student_class_id=value;}
			get{return _student_class_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_pwd
		{
			set{ _student_pwd=value;}
			get{return _student_pwd;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_pwd_q
		{
			set{ _student_pwd_q=value;}
			get{return _student_pwd_q;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_pwd_a
		{
			set{ _student_pwd_a=value;}
			get{return _student_pwd_a;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int student_stat
		{
			set{ _student_stat=value;}
			get{return _student_stat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string student_note
		{
			set{ _student_note=value;}
			get{return _student_note;}
		}
		#endregion Model

	}
}

