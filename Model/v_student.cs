using System;
namespace Topicsys.Model
{
	/// <summary>
	/// v_student:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_student
	{
		public v_student()
		{}
		#region Model
		private int _id=0;
		private string _student_xh;
		private string _student_name;
		private string _student_class_id;
		private int _student_stat=0;
		private string _student_note;
		private string _class_id;
		private string _class_name;
		private string _class_major_id;
		private string _class_note;
		private int _class_stat=0;
		private string _dept_name;
		private string _major_name;
		private string _dept_id;
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
		/// <summary>
		/// 
		/// </summary>
		public string class_id
		{
			set{ _class_id=value;}
			get{return _class_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string class_name
		{
			set{ _class_name=value;}
			get{return _class_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string class_major_id
		{
			set{ _class_major_id=value;}
			get{return _class_major_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string class_note
		{
			set{ _class_note=value;}
			get{return _class_note;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int class_stat
		{
			set{ _class_stat=value;}
			get{return _class_stat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dept_name
		{
			set{ _dept_name=value;}
			get{return _dept_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string major_name
		{
			set{ _major_name=value;}
			get{return _major_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string dept_id
		{
			set{ _dept_id=value;}
			get{return _dept_id;}
		}
		#endregion Model

	}
}

