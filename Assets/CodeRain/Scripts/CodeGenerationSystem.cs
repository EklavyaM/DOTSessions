using Unity.Entities;

namespace DOTSessions.CodeRain
{
    public partial struct CodeGenerationSystem : ISystem
    {
        public void OnCreate(ref SystemState state)
        {
            state.RequireForUpdate<CodeGeneratorData>();
        }

        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;

            CodeGeneratorData generatorData = SystemAPI.GetSingleton<CodeGeneratorData>();
            EntityCommandBuffer commandBuffer = new(state.WorldUpdateAllocator);

            for (int i = 0; i < generatorData.entityCount; ++i)
            {
                Entity codeEntity = commandBuffer.CreateEntity();
                commandBuffer.AddComponent(codeEntity, new CodeData() { character = CodeCharaterSheet.GetRandomCharacter() });
            };

            commandBuffer.Playback(state.EntityManager);
            commandBuffer.Dispose();
        }
    }
}
