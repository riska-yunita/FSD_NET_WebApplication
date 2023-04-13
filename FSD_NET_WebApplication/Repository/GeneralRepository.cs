using FSD_NET_WebApplication.Context;
using FSD_NET_WebApplication.Models;
using FSD_NET_WebApplication.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FSD_NET_WebApplication.Repository;

public class GeneralRepository<Context, Entity, Key> : IGeneralRepository<Entity, Key>
    where Entity : class
    where Context : MyContext
{
    protected MyContext _context;
    private readonly DbSet<Entity> entities;

    public GeneralRepository(Context context)
    {
        _context = context;
        entities = _context.Set<Entity>();
    }

    public IEnumerable<Entity> GetAll()
    {
        return entities.ToList();
    }

    public Entity? GetByKey(Key key)
    {
        return entities.Find(key);
    }

    public IEnumerable<Entity> Search(Key key)
    {
        return GetAll();
    }

    public int Insert(Entity entity)
    {
        entities.Add(entity);
        return _context.SaveChanges();
    }

    public int Update(Entity entity)
    {
        entities.Update(entity);
        return _context.SaveChanges();
    }

    public int Delete(Key key)
    {
        var entity = GetByKey(key);
        if (entity == null)
        {
            return 0;
        }
        entities.Remove(entity);
        return _context.SaveChanges();
    }
}
