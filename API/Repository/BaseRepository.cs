namespace SharpApi.Repository;

public class BaseRepository<E,D>(D context) where E : BaseEntityId where D :DbContext
{
    private readonly D _context = context;

    //READ BY ID
    public async Task<E?> GetEntityById(int id)
    {
        return await _context.Set<E>().FirstOrDefaultAsync(E => E.Id == id);
    }

    //GET ALL
    public async Task<List<E>> GetAll()
    {
        return await _context.Set<E>().ToListAsync();
    }

    //INSERT ENTITY
    public async Task<E> InsertEntity(E entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    //INSERT RANGE OF DATA
    public async Task<List<E>> InsertRangeEntity(List<E> entities)
    {
        await _context.AddRangeAsync(entities);
        await _context.SaveChangesAsync();

        return entities;
    }
}