﻿using PM.Common.Filters;
using PM.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PM.Service.Common
{
    /// <summary>
    /// Task service contract.
    /// </summary>
    public interface ITaskService
    {
        /// <summary>
        /// Gets the task asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<ITaskPoco> GetTaskAsync(Guid id);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        System.Threading.Tasks.Task AddAsync(ITaskPoco model);

        /// <summary>
        /// Finds the list of tasks asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>List of <see cref="ITaskPoco"/>.</returns>
        Task<IList<ITaskPoco>> FindAsync(TaskFilter filter);
    }
}