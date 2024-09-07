using DOTSessions.CodeRain.ComponentData.Unmanaged;
using DOTSessions.CodeRain.Jobs;
using Unity.Burst;
using Unity.Entities;

namespace DOTSessions.CodeRain.Systems.Unmanaged
{
    public partial struct CharacterUpdateSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate(state.EntityManager.CreateEntityQuery(typeof(CodeCharacter)));
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            SharedData sharedData = SystemAPI.GetSingleton<SharedData>();

            CharacterUpdateJob job = new()
            {
                deltaTime = SystemAPI.Time.DeltaTime,
                maxCharacters = sharedData.maxCharacters,
                characterUpdateDurationRange = sharedData.characterUpdateDurationRange,
            };

            state.Dependency = job.ScheduleParallel(state.Dependency);
        }
    }
}
