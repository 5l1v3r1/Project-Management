﻿using PM.DAL;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using PM.Model.Common;
using PM.Common;
using System;

namespace PM.Repository
{
    internal class UserRepository : GenericRepository<User, IUserPoco>, IUserRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserRepository"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="mapper">The mapper.</param>
        internal UserRepository(PMDatabaseEntities context, IMapper mapper)
            : base(context, mapper)
        {
        }

        /// <summary>
        /// Finds <see cref="IUser"/> the by user name asynchronous.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns><see cref="IUser"/>.</returns>
        public async System.Threading.Tasks.Task<IUserPoco> FindByUserNameAsync(string username)
        {
            var entity = await GetOneAsync(x => x.UserName == username);
            return mapper.Map<IUserPoco>(entity);
        }

        /// <summary>
        /// Gets <see cref="IUserPoco"/> the by user identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="IUser"/>.</returns>
        public async System.Threading.Tasks.Task<IUserPoco> GetByUserIdAsync(Guid id)
        {
            var entity = await GetOneAsync(i => i.UserId == id);
            return mapper.Map<IUserPoco>(entity);
        }

        /// <summary>
        /// Adds the <see cref="IUserPoco"/> asynchronous.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns>Task.</returns>
        public System.Threading.Tasks.Task AddAsync(IUserPoco model)
        {
            model.DateCreated = DateTime.UtcNow;
            model.DateUpdated = DateTime.UtcNow;
            var entity = mapper.Map<User>(model);
            return System.Threading.Tasks.Task.FromResult(dbSet.Add(entity));
        }

        /// <summary>
        /// Asynchronously deletes <see cref="IUserPoco"/> form the database.
        /// </summary>
        /// <param name="model">Model.</param>
        public System.Threading.Tasks.Task DeleteAsync(IUserPoco model)
        {
            var entity = mapper.Map<User>(model);
            dbSet.Remove(entity);
            return System.Threading.Tasks.Task.FromResult(true);
        }

        /// <summary>
        /// Asynchronously updates entity in the database.
        /// </summary>
        /// <param name="entity">Entity.</param>
        public System.Threading.Tasks.Task UpdateAsync(IUserPoco model)
        {
            model.DateUpdated = DateTime.UtcNow;
            var entity = mapper.Map<User>(model);
            dbSet.Attach(entity);
            ((IObjectContextAdapter)context).ObjectContext.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            return System.Threading.Tasks.Task.FromResult(true);
        }

        /// <summary>
        /// Creates the claim asynchronous.
        /// </summary>
        /// <returns><see cref="IClaim"/>.</returns>
        public System.Threading.Tasks.Task<IClaimPoco> CreateClaimAsync()
        {
            IClaimPoco claim = new Model.ClaimPoco();
            return System.Threading.Tasks.Task.FromResult(claim);
        }
    }
}