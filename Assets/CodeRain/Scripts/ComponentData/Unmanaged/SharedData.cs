using DOTSessions.Common;
using Unity.Entities;
using Unity.Mathematics;

namespace DOTSessions.CodeRain.ComponentData.Unmanaged
{
    public struct SharedData : IComponentData
    {
        public Random rng;

        public MinMax<float> characterUpdateDurationRange;
        public MinMax<float> columnUpdateDurationRange;
        public MinMax<float> dissipationRateRange;

        public int maxCharacters;
    }
}
