using DOTSessions.Common.Timer;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace DOTSessions
{
    [BurstCompile]
    public partial struct TimerJob : IJobEntity
    {
        [ReadOnly] public float deltaTime;

        private void Execute(ref TimerData timer)
        {
            if (!timer.HasExpired)
            {
                timer.elapsed += deltaTime;
            }
        }
    }
}
