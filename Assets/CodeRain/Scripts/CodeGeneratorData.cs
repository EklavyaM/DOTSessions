using DOTSessions.Common;
using Unity.Entities;

namespace DOTSessions.CodeRain
{
    public struct CodeGeneratorData : IComponentData
    {
        public int entityCount;

        public MinMax<float> characterChangeDurationRange;
    }
}
