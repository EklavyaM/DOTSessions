using Unity.Entities;
using Unity.Mathematics;

namespace DOTSessions.CodeRain.ComponentData.Unmanaged
{
    public struct GridConfig : IComponentData
    {
        public int2 size;
    }
}
