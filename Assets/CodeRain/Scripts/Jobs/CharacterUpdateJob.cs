using DOTSessions.CodeRain.ComponentData.Unmanaged;
using DOTSessions.Common;
using DOTSessions.Common.Randomizer;
using DOTSessions.Common.Timer;
using Unity.Burst;
using Unity.Entities;

namespace DOTSessions.CodeRain.Jobs
{
    [BurstCompile]
    public partial struct CharacterUpdateJob : IJobEntity
    {
        public MinMax<float> characterUpdateDurationRange;
        public int maxCharacters;

        public float deltaTime;

        public void Execute(ref Randomizer randomizer, ref CodeCharacter codeCharacter, ref TimerData timer)
        {
            if (timer.HasExpired)
            {
                timer.elapsed = 0f;
                timer.duration = randomizer.rng.NextFloat(characterUpdateDurationRange.min, characterUpdateDurationRange.max);

                codeCharacter.characterIndex = randomizer.rng.NextInt(0, maxCharacters);
            }
        }
    }
}
