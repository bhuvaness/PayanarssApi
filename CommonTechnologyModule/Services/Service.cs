using AutoMapper;
using CommonTechnologyModule.DataModels;
using CommonTechnologyModule.Repositories;
using System.Numerics;

namespace CommonTechnologyModule.Services
{
    public interface IBaseService<TDto, TDataModel> where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync(string? search = null, int page = 1, int pageSize = 10);
        Task<TDto> GetByIdAsync(string id);
        Task<TDto> AddAsync(TDto entity);
        Task<TDto> UpdateAsync(TDto entity);
        Task<int> DeleteAsync(string id);
    }

    public class Service<TDto, TDataModel> : IBaseService<TDto, TDataModel> where TDto : class where TDataModel : NamedDataModel
    {
        protected readonly IRepository<TDataModel> _repository;
        protected readonly IMapper _mapper;

        public Service(IRepository<TDataModel> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync(string? search = null, int page = 1, int pageSize = 10)
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TDto>>(result);
        }

        public async Task<TDto> GetByIdAsync(string id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map<TDto>(result);
        }

        public async Task<TDto> AddAsync(TDto dto)
        {
            var entity = _mapper.Map<TDataModel>(dto);
            var result = await _repository.AddAsync(entity);
            return _mapper.Map<TDto>(result);
        }

        public async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TDataModel>(dto);
            var result = await _repository.UpdateAsync(entity);
            return _mapper.Map<TDto>(result);
        }

        public async Task<int> DeleteAsync(string id)
        {
            return await _repository.DeleteAsync(id);
        }
    }

    public class NamedSearchService<TDto, TDataModel> : Service<TDto, TDataModel>, IBaseService<TDto, TDataModel> where TDto : class where TDataModel : NamedDataModel
    {
        private readonly IMapper _mapper;
        public NamedSearchService(IRepository<TDataModel> repository, IMapper mapper) : base(repository, mapper)
        {
            _mapper = mapper;
        }
        public override async Task<IEnumerable<TDto>> GetAllAsync(string? search = null, int page = 1, int pageSize = 10)
        {
            var all = await _repository.GetAllAsync();
            if (!string.IsNullOrWhiteSpace(search))
            {
                all = all.Where(x => x.Name != null && x.Name.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            var results = all
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            return _mapper.Map<IEnumerable<TDto>>(results);
        }
    }
}
