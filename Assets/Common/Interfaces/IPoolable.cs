using UnityEngine;

namespace DOTSessions.Common.Interfaces
{
    public interface IPoolable
    {
        public bool IsAvailable { get; }
        public Object PooledObject { get; }
    }
}
