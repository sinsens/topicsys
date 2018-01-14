using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Topicsys.Model;

namespace Topicsys.BLL
{
    /// <summary>
    /// t_select
    /// </summary>
    public partial class t_select
    {
        private readonly Topicsys.DAL.t_select dal = new Topicsys.DAL.t_select();

        public t_select()
        { }

        /// <summary>
        /// 发布选题结果
        /// </summary>
        /// <returns>提示信息</returns>
        public string Dist()
        {
            string str = "发布成功！";
            /// 获取所有已审核通过数据
            var list = dal.GetModelList("select_stat=1");
            if (list == null)
                return str + "共有0个结果";

            /// 循环处理设置stat
            int i = 0;
            foreach (var item in list)
            {
                /// 发布结果
                DoAction(item.select_id, 5);
                i += 1;
            }
            str += "共有" + list.Count + "个结果，成功处理" + i + "个结果";
            return str;
        }

        /// <summary>
        /// 动作
        /// </summary>
        /// <param name="id">select_id</param>
        /// <param name="action">0待审核,1一审通过,2一审不通过,3二审不通过等待分配,5已发布结果,9已注销</param>
        /// <returns></returns>
        public bool DoAction(string id, int action)
        {
            return dal.DoAction(id, action);
        }

        /// <summary>
        /// 分配题目给学生
        /// </summary>
        /// <param name="topic_id">topic_id</param>
        /// <param name="student_xh">学号</param>
        /// <returns></returns>
        public string Allocate(string topic_id, string student_xh)
        {
            return ApplyFor(topic_id, student_xh, "分配成功！", true);
        }

        /// <summary>
        /// 申请选题
        /// </summary>
        /// <param name="topic_id">选题UUID</param>
        /// <param name="student_xh">学生学号</param>
        /// <returns>提示信息</returns>
        public string ApplyFor(string topic_id, string student_xh, string re_msg = "申请成功！", bool is_Allocate = false)
        {
            /// 检查学生和选题是否存在
            var bll_topic = new t_topic();
            var topic = bll_topic.GetModel(topic_id);
            if (topic == null)
                return "题目不存在！";
            var bll_stu = new t_student();
            var student = bll_stu.GetModel(student_xh);
            if (student == null)
                return "学号不存在！";

            /// 判断选题人数是否已满
            var bll_v_topic = new v_topic();
            var is_full = bll_v_topic.GetModelList("topic_id='" + topic_id + "'")[0];
            if (is_full != null)
            {
                if (is_full.select_sum >= is_full.topic_num)
                {
                    return "该题目选题人数已满！请选择其他题目";
                }
            }

            /// 检查学生是否已选择其他题目
            var bll_select = new DAL.t_select();
            /// 锁定
            lock (bll_select)
            {
                var is_select = bll_select.GetModelList("select_student_xh='" + student.student_xh + "'");

                if (is_select == null)
                {
                    /// 第一次选题
                    var model = new Model.t_select
                    {
                        select_stat = 0,
                        select_student_xh = student_xh,
                        select_topic_id = topic_id
                    };
                    bll_select.Add(model);
                    return re_msg;
                }
                else
                {
                    var model2 = is_select[0];
                    /// 等待审核状态
                    if (model2.select_stat.Equals(0))
                        return "你已提交过申请，请等待导师审核！";
                    /// 判断是否为二次被拒对象
                    if (model2.select_stat.Equals(3) && (is_Allocate.Equals(false)))
                        return "你已经被二次拒绝，请等待教研室主任为你分配题目!";
                    model2.select_topic_id = topic_id;
                    /// 更新结果
                    bll_select.Update(model2);
                    return re_msg;
                }
            }
        }

        /// <summary>
        /// 导师审核
        /// </summary>
        /// <param name="select_id">选题UUID</param>
        /// <param name="result">1为不通过，2为通过</param>
        /// <returns></returns>
        public bool AuditFor(string select_id, int result)
        {
            /// 检查UUID是否存在
            var bll_select = new t_select();
            var model = bll_select.GetModel(select_id);
            if (model == null)
            {
                return false;
            }
            /// 判断是否为二审
            if (model.select_stat.Equals(1))
            {
                if (result.Equals(1))
                    return DoAction(select_id, 3); // 二次被拒
                else
                    return DoAction(select_id, 2); // 第二次审核通过
            }
            else
                return DoAction(select_id, result);// 第一次审核，直接赋值
        }

        #region BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string select_id, string select_student_xh, int id)
        {
            return dal.Exists(select_id, select_student_xh, id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Topicsys.Model.t_select model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Topicsys.Model.t_select model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string select_id, string select_student_xh, int id)
        {
            return dal.Delete(select_id, select_student_xh, id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            return dal.DeleteList(Maticsoft.Common.PageValidate.SafeLongFilter(idlist, 0));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Topicsys.Model.t_select GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Topicsys.Model.t_select GetModel(string id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Topicsys.Model.t_select GetModelByCache(int id)
        {
            string CacheKey = "t_selectModel-" + id;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(id);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Topicsys.Model.t_select)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Topicsys.Model.t_select> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Topicsys.Model.t_select> DataTableToList(DataTable dt)
        {
            List<Topicsys.Model.t_select> modelList = new List<Topicsys.Model.t_select>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Topicsys.Model.t_select model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = dal.DataRowToModel(dt.Rows[n]);
                    if (model != null)
                    {
                        modelList.Add(model);
                    }
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion BasicMethod
    }
}