using Unity.Entities;

namespace DOTSessions.CodeRain
{
    public struct CodeData : IComponentData
    {
        public int gridIndex;

        public int characterIndex;
        public float characterOpacity;

        public float characterChangeFrameCounter;
        public float characterChangeDuration;
    }
}
