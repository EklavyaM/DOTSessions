using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace DOTSessions.CodeRain
{
    [BurstCompile]
    public partial struct CodeDataCharacterUpdateJob : IJobEntity
    {
        public int availableCharactersCount;
        public float deltaTime;
        public Random random;

        public void Execute(ref CodeData codeData)
        {
            codeData.characterChangeFrameCounter += deltaTime;
            if (codeData.characterChangeFrameCounter > codeData.characterChangeDuration)
            {
                codeData.characterChangeDuration = random.NextFloat(codeData.characterChangeDurationRange.min, codeData.characterChangeDurationRange.max);
                codeData.characterChangeFrameCounter = 0;
                codeData.characterSheetIndex = random.NextInt(0, availableCharactersCount);
                codeData.characterOpacity = random.NextFloat();
            }
        }
    }
}
