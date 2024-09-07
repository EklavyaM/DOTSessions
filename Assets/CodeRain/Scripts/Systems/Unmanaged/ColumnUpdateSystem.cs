using DOTSessions.CodeRain.ComponentData.Unmanaged;
using Unity.Burst;
using Unity.Entities;

namespace DOTSessions.CodeRain.Systems.Unmanaged
{
    [UpdateAfter(typeof(CharacterUpdateSystem))]
    public partial struct ColumnUpdateSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate(state.EntityManager.CreateEntityQuery(typeof(Column)));
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            SharedData sharedData = SystemAPI.GetSingleton<SharedData>();

            ColumnUpdateJob job = new()
            {
                columnUpdateDurationRange = sharedData.columnUpdateDurationRange,
                dissipationRateRange = sharedData.dissipationRateRange,
            };

            state.Dependency = job.ScheduleParallel(state.Dependency);
        }
    }
}
