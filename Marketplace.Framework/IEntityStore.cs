using System.Threading.Tasks;

namespace Marketplace.Framework
{
    public interface IEntityStore
    {
        /// <summary>
        /// Loads an entity by id
        /// </summary>
        /// <param name="entityId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<T> Load<T>(string entityId) where T : Entity;

        /// <summary>
        /// Persists an entity
        /// </summary>
        /// <param name="entity"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task Save<T>(T entity) where T : Entity;

        /// <summary>
        /// Check if entity with given id already exists
        /// </summary>
        /// <param name="entityId"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<bool> Exists<T>(string entityId);

    }
}