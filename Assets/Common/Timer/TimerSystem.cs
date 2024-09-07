using Unity.Burst;
using Unity.Entities;

namespace DOTSessions.Common.Timer
{
    public partial struct TimerSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<TimerData>();

        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            TimerJob timerJob = new()
            {
                deltaTime = SystemAPI.Time.DeltaTime,
            };

            state.Dependency = timerJob.ScheduleParallel(state.Dependency);
        }
    }
}
