using System;
namespace Topicsys.Model
{
	/// <summary>
	/// v_teacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_teacher
	{
		public v_teacher()
		{}
		#region Model
		private int _id=0;
		private string _teacher_gh;
		private string _teacher_name;
		private string _teacher_dept_id;
		private string _teacher_major_id;
		private int _teacher_stat=0;
		private string _teacher_note;
		private int _teacher_type=0;
		private string _dept_name;
		/// <summary>
		/// 
		/// </summary>
		public int id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_gh
		{
			set{ _teacher_gh=value;}
			get{return _teacher_gh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_name
		{
			set{ _teacher_name=value;}
			get{return _teacher_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_dept_id
		{
			set{ _teacher_dept_id=value;}
			get{return _teacher_dept_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_major_id
		{
			set{ _teacher_major_id=value;}
			get{return _teacher_major_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int teacher_stat
		{
			set{ _teacher_stat=value;}
			get{return _teacher_stat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string teacher_note
		{
			set{ _teacher_note=value;}
			get{return _teacher_note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int teacher_type
		{
			set{ _teacher_type=value;}
			get{return _teacher_type;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dept_name
		{
			set{ _dept_name=value;}
			get{return _dept_name;}
		}
		#endregion Model

	}
}

