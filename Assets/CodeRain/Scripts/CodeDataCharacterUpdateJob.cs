using DOTSessions.Common;
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

        public MinMax<float> characterChangeDurationRange;

        public void Execute(ref CodeData codeData)
        {
            codeData.characterChangeFrameCounter += deltaTime;
            if (codeData.characterChangeFrameCounter > codeData.characterChangeDuration)
            {
                codeData.characterChangeDuration = random.NextFloat(characterChangeDurationRange.min, characterChangeDurationRange.max);
                codeData.characterChangeFrameCounter = 0;
                codeData.characterIndex = random.NextInt(0, availableCharactersCount);
                codeData.characterOpacity = random.NextFloat(0.35f, 1);
            }
        }
    }
}
