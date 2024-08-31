using DOTSessions.Common;
using Unity.Entities;

namespace DOTSessions.CodeRain
{
    public struct CodeRainSharedData : IComponentData
    {
        public uint randomSeed;

        public MinMax<float> characterChangeDurationRange;
    }
}
