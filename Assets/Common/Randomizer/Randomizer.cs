using Unity.Entities;
using Unity.Mathematics;

namespace DOTSessions.Common.Randomizer
{
    public struct Randomizer : IComponentData
    {
        public Random rng;
    }
}
