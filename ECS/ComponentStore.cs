using System;

namespace FlyingFox.ECS
{
    // To hold the components, allowing them to be accessed, deleted and added.
    // Intermediate way to interact with components
    public interface IComponentStore
    {
        public bool Contains(uint entityId);

        void RemoveIfContains(Entity entity) => RemoveIfContains(entity.Id);

        void RemoveIfContains(uint entityId);

        public SparseSet Entities { get; }
    }

    public class ComponentStore<T> : IComponentStore
    {
        public event Action<uint>? OnAdd;
        public event Action<uint>? OnRemove;

        public SparseSet Set;
        public SparseSet Entities => Set;
        T[] instances;

        public uint Count => Set.Count;

        public ComponentStore(uint maxComponents)
        {
            Set = new SparseSet(maxComponents);
            instances = new T[maxComponents];
        }

        public void Add(Entity entity, T value)
        {
            Set.Add(entity.Id);
            instances[entity.Id] = value;
            OnAdd?.Invoke(entity.Id);
        }

        public ref T Get(uint entityId) => ref instances[entityId];

        public bool Contains(uint entityId) => Set.Contains(entityId);

        public void RemoveIfContains(uint entityId)
        {
            if (Set.Contains(entityId)) Remove(entityId);
        }

        void Remove(uint entityId)
        {
            Set.Remove(entityId);
            OnRemove?.Invoke(entityId);
        }
    }
}