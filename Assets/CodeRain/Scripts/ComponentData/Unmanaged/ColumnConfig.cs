using Unity.Entities;

namespace DOTSessions.CodeRain.ComponentData.Unmanaged
{
    public struct ColumnConfig : IComponentData
    {
        public int startIndex;
        public int endIndex;
    }
}
