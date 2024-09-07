using Unity.Entities;

namespace DOTSessions.Common.Timer
{
    public struct TimerData : IComponentData
    {
        public float elapsed;
        public float duration;

        public bool HasExpired => elapsed >= duration;
        public float ElapsedNormalized => duration > 0 ? elapsed / duration : 0;
    }
}
