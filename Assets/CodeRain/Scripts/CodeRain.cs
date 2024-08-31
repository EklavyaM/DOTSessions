using DOTSessions.Common;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DOTSessions.CodeRain
{
    public class CodeRain : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField, Min(1)] private uint randomSeed;
        [SerializeField] private MinMax<float> characterChangeDurationRange;

        private EntityManager _entityManager;

        private void Awake()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        public void OnCodeGenerated(CodeUI[] codeUIs, Vector2Int size)
        {
            EntityCommandBuffer commandBuffer = new(_entityManager.World.UpdateAllocator.Handle);

            Entity sharedDataEntity = commandBuffer.CreateEntity();
            commandBuffer.AddComponent(sharedDataEntity, new CodeRainSharedData()
            {
                characterChangeDurationRange = characterChangeDurationRange,
                randomSeed = randomSeed
            });


            Entity gridEntity = commandBuffer.CreateEntity();
            commandBuffer.AddComponent(gridEntity, new CodeGridData()
            {
                grid = codeUIs,
                size = new int2(size.x, size.y)
            });

            Unity.Mathematics.Random random = new(randomSeed);


            for (int i = 0; i < codeUIs.Length; ++i)
            {
                Entity codeEntity = commandBuffer.CreateEntity();

                commandBuffer.AddComponent(codeEntity, new CodeData()
                {
                    gridIndex = i,
                    characterIndex = random.NextInt(0, CodeCharacterSheet.AvailableCharactersCount),
                    characterChangeFrameCounter = 0,
                    characterChangeDuration = random.NextFloat(characterChangeDurationRange.min, characterChangeDurationRange.max),
                    characterOpacity = 0,
                });
            };

            commandBuffer.Playback(_entityManager);
            commandBuffer.Dispose();
        }
    }
}
