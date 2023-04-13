namespace FSD_NET_WebApplication.Repository.Contracts;

public interface IGeneralRepository<Entity, Key>
{
    IEnumerable<Entity> GetAll();
    Entity? GetByKey (Key key);
    int Insert(Entity entity);
    int Update(Entity entity);
    int Delete(Key Key);
}

