using DOTSessions.Common.Interfaces;
using System;
using UnityEngine;

namespace DOTSessions.Common.Patterns
{
    public class ObjectPool<T> where T : IPoolable
    {
        private readonly Func<GameObject, T> EntityFactory;
        private readonly int MaxCount;
        private readonly GameObject Prefab;
        private readonly Transform Root;

        protected T[] Pool;

        public ObjectPool(GameObject prefab, Func<GameObject, T> entityFactory, int maxCount = 10,
            Transform root = null)
        {
            MaxCount = maxCount;

            Root = GenerateHolder(root);
            Prefab = prefab;
            EntityFactory = entityFactory;
        }

        public event Action OnPoolInitialized;
        public event Action OnPoolReleased;

        private Transform GenerateHolder(Transform parent)
        {
            Transform holder = new GameObject(typeof(T).Name).transform;
            holder.parent = parent;
            return holder;
        }


        public void GeneratePool()
        {
            ReleasePool();

            Pool = new T[MaxCount];
            for (int i = 0; i < MaxCount; ++i)
            {
                GameObject entity = UnityEngine.Object.Instantiate(Prefab, Root);
                Pool[i] = EntityFactory(entity);
            }

            OnPoolInitialized?.Invoke();
        }

        public bool TryGet(out T entity)
        {
            for (int i = 0; i < MaxCount; ++i)
            {
                if (Pool[i].IsAvailable)
                {
                    entity = Pool[i];
                    return true;
                }
            }

            entity = default;
            return false;
        }

        public void ReleasePool()
        {
            for (int i = 0; i < MaxCount; ++i)
            {
                UnityEngine.Object.Destroy(Pool[i].PooledObject);
            }

            Pool = null;
            OnPoolReleased?.Invoke();
        }
    }
}
