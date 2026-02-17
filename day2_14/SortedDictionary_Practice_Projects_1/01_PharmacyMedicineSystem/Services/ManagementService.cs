using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, List<BaseEntity>> _data
            = new SortedDictionary<int, List<BaseEntity>>();

        public void AddEntity(int key, BaseEntity entity)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
                if (entity == null)
                {
                    throw new InventoryException("Entity cannot be null.");
                }
                if (!_data.ContainsKey(key))
                {
                    _data[key] = new List<BaseEntity>();
                }
                if (_data[key].Any(e => e.Id == entity.Id))
                {
                    throw new InventoryException($"Entity with ID {entity.Id} already exists under key {key}.");
                }
                _data[key].Add(entity);
        }

        public void UpdateEntity(int key, BaseEntity entity)
        {
            // TODO: Update entity logic
                    if (entity == null)
                    {
                        throw new InventoryException("Entity cannot be null.");
                    }
                    if (!_data.ContainsKey(key) || !_data[key].Any(e => e.Id == entity.Id))
                    {
                        throw new InventoryException($"Entity with ID {entity.Id} does not exist under key {key}.");
                    }
                    var existingEntity = _data[key].First(e => e.Id == entity.Id);
                    // Update properties of existingEntity based on the new entity
                    _data[key].Remove(existingEntity);
                    _data[key].Add(entity);

            
        }

        public void RemoveEntity(int key)
        {
            // TODO: Remove entity logic
                    if (!_data.ContainsKey(key))
                    {
                        throw new InventoryException($"No entities found under key {key}.");
                    }
                    _data.Remove(key);

        }

        public IEnumerable<BaseEntity> GetAll()
        {
            // TODO: Return sorted entities
            
            var allEntities = new List<BaseEntity>();
            foreach (var kvp in _data)
            {
                allEntities.AddRange(kvp.Value);
            }
            return allEntities;
        }
    }
}
