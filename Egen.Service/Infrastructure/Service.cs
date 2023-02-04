using Egen.IRepository.Infrastructure;
using Egen.IService.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Egen.Service.Infrastructure
{
    public abstract class Service<T> : IGenericService<T> where T : class
    {
        protected IGenericRepository<T> _repository;
        protected IUnitOfWork _unitOfWork;
        public Service(IGenericRepository<T> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<int> AddAsync(T Entity)
        {
            await _repository.AddAsync(Entity);
            return await _unitOfWork.CommitAsync();
        }

        public virtual async Task<int> DeleteAsync(T Entity)
        {
            _repository.DeleteAsync(Entity);
            return await _unitOfWork.CommitAsync();
        }

        public virtual async Task<ICollection<T>> GetAsync()
        {
            return await _repository.GetAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<int> UpdateAsync(T Entity)
        {
            _repository.UpdateAsync(Entity);
            return await _unitOfWork.CommitAsync();
        }
    }
}
