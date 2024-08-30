using Unity.Entities;

namespace DOTSessions.CodeRain
{
    public struct CodeData : IComponentData
    {
        public int characterSheetIndex;
        public float characterOpacity;

        public float characterChangeFrameCounter;
        public float characterChangeDuration;
    }
}
