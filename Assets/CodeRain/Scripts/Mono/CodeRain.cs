using DOTSessions.CodeRain.ComponentData.Managed;
using DOTSessions.CodeRain.ComponentData.Unmanaged;
using DOTSessions.CodeRain.Shared;
using DOTSessions.Common;
using DOTSessions.Common.Randomizer;
using DOTSessions.Common.Timer;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DOTSessions.CodeRain.Mono
{
    public class CodeRain : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField, Min(1)] private uint randomSeed;
        [SerializeField] private MinMax<float> characterChangeDurationRange;
        [SerializeField] private MinMax<float> columnUpdateDurationRange;
        [SerializeField] private MinMax<float> dissipationRateRange;

        private EntityManager _entityManager;
        private EntityArchetype _gridArchetype;
        private EntityArchetype _codeArchetype;
        private EntityArchetype _columnArchetype;

        private void Awake()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;

            _gridArchetype = _entityManager.CreateArchetype(typeof(GridConfig), typeof(GridData));
            _codeArchetype = _entityManager.CreateArchetype(typeof(Randomizer), typeof(CodePosition), typeof(CodeCharacter), typeof(CodeAlpha), typeof(TimerData));
            _columnArchetype = _entityManager.CreateArchetype(typeof(Randomizer), typeof(Column), typeof(ColumnDissipation), typeof(ColumnConfig), typeof(TimerData));
        }

        public void OnCodeGenerated(CodeUI[] codeUIs, Vector2Int size)
        {
            EntityCommandBuffer commandBuffer = new(_entityManager.World.UpdateAllocator.Handle);

            Entity sharedDataEntity = commandBuffer.CreateEntity();
            SharedData sharedData = new()
            {
                characterUpdateDurationRange = characterChangeDurationRange,
                maxCharacters = CharacterSheet.AvailableCharactersCount,
                rng = new Unity.Mathematics.Random(randomSeed),
                dissipationRateRange = dissipationRateRange,
                columnUpdateDurationRange = columnUpdateDurationRange
            };

            commandBuffer.AddComponent(sharedDataEntity, sharedData);

            Entity gridEntity = commandBuffer.CreateEntity(_gridArchetype);

            commandBuffer.SetComponent(gridEntity, new GridConfig() { size = new int2(size.x, size.y) });
            commandBuffer.SetComponent(gridEntity, new GridData() { grid = codeUIs });

            for (int i = 0; i < size.x; ++i)
            {
                Entity columnEntity = commandBuffer.CreateEntity(_columnArchetype);

                int startIndex = i * size.y;
                int endIndex = startIndex + size.y - 1;

                commandBuffer.SetComponent(columnEntity, new ColumnConfig() { startIndex = startIndex, endIndex = endIndex, });
                commandBuffer.SetComponent(columnEntity, new ColumnDissipation()
                {
                    dissipationRate = sharedData.rng.NextFloat(sharedData.dissipationRateRange.min, sharedData.dissipationRateRange.max)
                });

                commandBuffer.SetComponent(columnEntity, new Column() { currentIndex = startIndex });
                commandBuffer.SetComponent(columnEntity, new Randomizer() { rng = new Unity.Mathematics.Random(sharedData.rng.NextUInt()) });
                commandBuffer.SetComponent(columnEntity, new TimerData()
                {
                    elapsed = 0,
                    duration = sharedData.rng.NextFloat(sharedData.columnUpdateDurationRange.min, sharedData.columnUpdateDurationRange.max)
                });
            }

            for (int i = 0; i < codeUIs.Length; ++i)
            {
                Entity codeEntity = commandBuffer.CreateEntity(_codeArchetype);

                commandBuffer.SetComponent(codeEntity, new Randomizer() { rng = new Unity.Mathematics.Random(sharedData.rng.NextUInt()) });
                commandBuffer.SetComponent(codeEntity, new CodePosition() { gridIndex = i });
                commandBuffer.SetComponent(codeEntity, new CodeCharacter() { characterIndex = sharedData.rng.NextInt(0, CharacterSheet.AvailableCharactersCount) });
                commandBuffer.SetComponent(codeEntity, new CodeAlpha() { alpha = 0f });
                commandBuffer.SetComponent(codeEntity, new TimerData()
                {
                    elapsed = 0,
                    duration = sharedData.rng.NextFloat(characterChangeDurationRange.min, characterChangeDurationRange.max)
                });
            };

            commandBuffer.Playback(_entityManager);
            commandBuffer.Dispose();
        }
    }
}
