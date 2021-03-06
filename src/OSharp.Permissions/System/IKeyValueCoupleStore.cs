﻿// -----------------------------------------------------------------------
//  <copyright file="IKeyValueCoupleStore.cs" company="OSharp开源团队">
//      Copyright (c) 2014-2018 OSharp. All rights reserved.
//  </copyright>
//  <site>http://www.osharp.org</site>
//  <last-editor>郭明锋</last-editor>
//  <last-date>2018-06-25 21:00</last-date>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using OSharp.Data;


namespace OSharp.System
{
    /// <summary>
    /// 定义键值对数据存储
    /// </summary>
    public interface IKeyValueCoupleStore
    {
        /// <summary>
        /// 获取 键值对数据查询数据集
        /// </summary>
        IQueryable<KeyValueCouple> KeyValueCouples { get; }

        /// <summary>
        /// 获取指定键名的数据项
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>数据项</returns>
        KeyValueCouple GetKeyValueCouple(string key);

        /// <summary>
        /// 检查键值对信息信息是否存在
        /// </summary>
        /// <param name="predicate">检查谓语表达式</param>
        /// <param name="id">更新的键值对信息编号</param>
        /// <returns>键值对信息是否存在</returns>
        Task<bool> CheckKeyValueCoupleExists(Expression<Func<KeyValueCouple, bool>> predicate, Guid id = default(Guid));

        /// <summary>
        /// 添加或更新键值对信息信息
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> CreateOrUpdateKeyValueCouple(string key, object value);

        /// <summary>
        /// 添加或更新键值对信息信息
        /// </summary>
        /// <param name="dtos">要添加的键值对信息DTO信息</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> CreateOrUpdateKeyValueCouples(params KeyValueCouple[] dtos);

        /// <summary>
        /// 删除键值对信息信息
        /// </summary>
        /// <param name="ids">要删除的键值对信息编号</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> DeleteKeyValueCouples(params Guid[] ids);

        /// <summary>
        /// 删除以根键路径为起始的所有字典项，如输入“System.User.”，所有键以此开头的项都会被删除
        /// </summary>
        /// <param name="rootKey">根键路径</param>
        /// <returns>业务操作结果</returns>
        Task<OperationResult> DeleteKeyValueCouples(string rootKey);
    }
}