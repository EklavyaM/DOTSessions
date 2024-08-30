using DOTSessions.Common;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace DOTSessions.CodeRain
{
    [BurstCompile]
    public partial struct CodeDataUpdateJob : IJobEntity
    {
        public MinMax<float> characterDurationChange;
        public int availableCharactersCount;
        public float deltaTime;
        public Random random;

        public void Execute(ref CodeData codeData)
        {
            codeData.characterChangeFrameCounter += deltaTime;
            if (codeData.characterChangeFrameCounter > codeData.characterChangeDuration)
            {
                codeData.characterChangeDuration = random.NextFloat(characterDurationChange.min, characterDurationChange.max);
                codeData.characterChangeFrameCounter = 0;
                codeData.characterSheetIndex = random.NextInt(0, availableCharactersCount);
                codeData.characterOpacity = random.NextFloat();
            }
        }
    }
}
