using DOTSessions.CodeRain.ComponentData.Unmanaged;
using DOTSessions.CodeRain.Jobs;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;

namespace DOTSessions.CodeRain.Systems.Unmanaged
{
    [UpdateAfter(typeof(ColumnUpdateSystem))]
    public partial struct AlphaUpdateSystem : ISystem
    {
        private NativeArray<Entity> _columns;
        private bool _initialized;

        private void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate(state.EntityManager.CreateEntityQuery(typeof(CodeAlpha)));
        }

        private void OnDestroy()
        {
            if (_initialized)
            {
                _columns.Dispose();
            }
        }

        [BurstCompile]
        private void OnUpdate(ref SystemState state)
        {
            if (!_initialized)
            {
                EntityQuery query = SystemAPI.QueryBuilder().WithAll<Column>().Build();
                _columns = query.ToEntityArray(Allocator.Persistent);
                _initialized = true;
            }

            AlphaUpdateJob alphaUpdateJob = new()
            {
                activeColumns = _columns,
                deltaTime = SystemAPI.Time.DeltaTime,
                columnLookup = SystemAPI.GetComponentLookup<Column>(),
                configLookup = SystemAPI.GetComponentLookup<ColumnConfig>(),
                dissipationLookup = SystemAPI.GetComponentLookup<ColumnDissipation>()
            };

            state.Dependency = alphaUpdateJob.ScheduleParallel(state.Dependency);
        }
    }
}
