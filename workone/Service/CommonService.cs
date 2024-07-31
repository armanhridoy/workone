using AutoMapper;
using Microsoft.EntityFrameworkCore;
using workone.StudentDBase;

namespace workone.Service;

public class CommonService <TEntity,IModel>:ICommonService<TEntity , IModel>
    where TEntity : class, new() where IModel : class
{
    private readonly IMapper _mapper;
    private readonly ApplicationSt _dbcontext;
    public CommonService(IMapper mapper, ApplicationSt dbcontext)
    {
        _mapper = mapper;
        _dbcontext = dbcontext;
        DbSet = _dbcontext.Set<TEntity>();
    }
    public DbSet<TEntity> DbSet { get; }
    public async Task<IEnumerable<IModel>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await DbSet.ToListAsync(cancellationToken);
        if (entities == null) return null;
        var data = _mapper.Map<IEnumerable<IModel>>(entities);
        return data;
    }
    public async Task<IModel> InsertAsync(IModel model, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<IModel, TEntity>(model);
        DbSet.Add(entity);
        await _dbcontext.SaveChangesAsync(cancellationToken);
        var insertedModel = _mapper.Map<TEntity, IModel>(entity);
        return insertedModel;
    }
    public async Task<IModel> UpDateAsync(int Id, IModel model, CancellationToken cancellationToken)
    {
        var entity = await DbSet.FindAsync(Id);
        if (entity == null)
        {
            return null;
        }
        _mapper.Map(model, entity);
        await _dbcontext.SaveChangesAsync(cancellationToken);
        var updatedModel = _mapper.Map<TEntity, IModel>(entity);
        return updatedModel;
    }
    public async Task<IModel> DeleteAsync(int Id, CancellationToken cancellationToken)
    {
        var entity = await DbSet.FindAsync(Id);
        if (entity == null) return null;

        DbSet.Remove(entity);
        await _dbcontext.SaveChangesAsync(cancellationToken);
        var deletedModel = _mapper.Map<TEntity, IModel>(entity);
        return deletedModel;
    }
    public async Task<IModel> GetByIdAsync(int Id, CancellationToken cancellationToken)
    {
        var entity = await DbSet.FindAsync(Id);
        if (entity == null) return null;
        var model = _mapper.Map<TEntity, IModel>(entity);
        return model;
    }
}

