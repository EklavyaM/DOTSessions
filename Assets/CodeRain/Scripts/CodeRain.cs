using DOTSessions.Common;
using Unity.Entities;
using UnityEngine;

namespace DOTSessions.CodeRain
{
    public class CodeRain : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private MinMax<float> characterChangeDurationRange;

        private EntityManager _entityManager;
        private void Awake()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        }

        public void OnCodeGenerated(CodeUI[] codeUIs)
        {
            EntityCommandBuffer commandBuffer = new(_entityManager.World.UpdateAllocator.Handle);

            for (int i = 0; i < codeUIs.Length; ++i)
            {
                Entity codeEntity = commandBuffer.CreateEntity();

                commandBuffer.AddComponent(codeEntity, new CodeData()
                {
                    characterSheetIndex = CodeCharacterSheet.GetRandomIndex(),
                    characterChangeDurationRange = characterChangeDurationRange,
                    characterChangeFrameCounter = 0,
                    characterChangeDuration = UnityEngine.Random.Range(characterChangeDurationRange.min, characterChangeDurationRange.max),
                    characterOpacity = 0,
                });

                commandBuffer.AddComponent(codeEntity, new CodeUIReference()
                {
                    codeUI = codeUIs[i],
                });
            };

            commandBuffer.Playback(_entityManager);
            commandBuffer.Dispose();
        }
    }
}
