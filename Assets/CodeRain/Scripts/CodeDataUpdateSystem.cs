using Unity.Entities;

namespace DOTSessions.CodeRain
{
    public partial struct CodeDataUpdateSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<CodeData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            CodeDataCharacterUpdateJob job = new()
            {
                deltaTime = SystemAPI.Time.DeltaTime,
                availableCharactersCount = CodeCharacterSheet.AvailableCharactersCount,
                random = new Unity.Mathematics.Random(1)
            };

            job.ScheduleParallel();
        }
    }
}
