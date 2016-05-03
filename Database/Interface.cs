using System.Linq;

namespace Database
{
    public interface Interface<Entity>
    {
        TestContext BaseContext();
        IQueryable<Entity> Get();
        Entity Get(int id);
        void Insert(Entity entity);
        void Update(Entity entity, int id);
        void Delete(int id);
    }
}
