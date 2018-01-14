﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Topicsys.Model;

namespace Topicsys.BLL
{
    /// <summary>
    /// t_topic
    /// </summary>
    public partial class t_topic
    {
        private readonly Topicsys.DAL.t_topic dal = new Topicsys.DAL.t_topic();

        public t_topic()
        { }

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
        public bool Exists(string topic_id, int id)
        {
            return dal.Exists(topic_id, id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public string Add(Topicsys.Model.t_topic model)
        {
            if(dal.Add(model))
                return "添加成功！";
            else
                return "添加失败";
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Topicsys.Model.t_topic model)
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
        public bool Delete(string topic_id, int id)
        {
            return dal.Delete(topic_id, id);
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
        public Topicsys.Model.t_topic GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Topicsys.Model.t_topic GetModel(string id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public Topicsys.Model.t_topic GetModelByCache(int id)
        {
            string CacheKey = "t_topicModel-" + id;
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
            return (Topicsys.Model.t_topic)objModel;
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
        public List<Topicsys.Model.t_topic> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Topicsys.Model.t_topic> DataTableToList(DataTable dt)
        {
            List<Topicsys.Model.t_topic> modelList = new List<Topicsys.Model.t_topic>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Topicsys.Model.t_topic model;
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

        #region ExtensionMethod

        /// <summary>
        /// 动作
        /// </summary>
        /// <param name="id"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public bool DoAction(string id, int action)
        {
            return dal.DoAction(id, action);
        }

        #endregion ExtensionMethod
    }
}