using System;
namespace Topicsys.Model
{
	/// <summary>
	/// v_select:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class v_select
	{
		public v_select()
		{}
		#region Model
		private string _student_name;
		private string _class_id;
		private string _class_name;
		private string _class_major_id;
		private string _dept_name;
		private string _major_name;
		private string _dept_id;
		private int _id=0;
		private string _select_id;
		private string _select_student_xh;
		private string _select_topic_id;
		private int _select_stat=0;
		private string _topic_teacher_gh;
		private string _teacher_name;
		private int _topic_num=0;
		private string _topic_name;
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
		public string select_id
		{
			set{ _select_id=value;}
			get{return _select_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string select_student_xh
		{
			set{ _select_student_xh=value;}
			get{return _select_student_xh;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string select_topic_id
		{
			set{ _select_topic_id=value;}
			get{return _select_topic_id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int select_stat
		{
			set{ _select_stat=value;}
			get{return _select_stat;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string topic_teacher_gh
		{
			set{ _topic_teacher_gh=value;}
			get{return _topic_teacher_gh;}
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
		public int topic_num
		{
			set{ _topic_num=value;}
			get{return _topic_num;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string topic_name
		{
			set{ _topic_name=value;}
			get{return _topic_name;}
		}
		#endregion Model

	}
}

