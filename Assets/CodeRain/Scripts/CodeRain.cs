using DOTSessions.Common;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;

namespace DOTSessions.CodeRain
{
    public class CodeRain : MonoBehaviour
    {
        [Header("Data")]
        [SerializeField] private MinMax<float> characterChangeDurationRange;

        private EntityManager _entityManager;
        private EntityArchetype _codeGeneratorArchetype;
        private EntityQuery _codeEntityQuery;

        private CodeUI[] _codes;

        private void Awake()
        {
            _entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _codeGeneratorArchetype = _entityManager.CreateArchetype(typeof(CodeGeneratorData));
            _codeEntityQuery = _entityManager.CreateEntityQuery(typeof(CodeData));
        }

        private void Update()
        {
            if (_codes == null)
            {
                return;
            }

            NativeArray<Entity> codeEntities = _codeEntityQuery.ToEntityArray(Unity.Collections.Allocator.TempJob);

            int index = 0;

            foreach (Entity entity in codeEntities)
            {
                CodeData codeData = _entityManager.GetComponentData<CodeData>(entity);
                _codes[index].Text = CodeCharacterSheet.GetCharacter(codeData.characterSheetIndex);
                _codes[index].Alpha = codeData.characterOpacity;

                ++index;
            }

            codeEntities.Dispose();
        }

        public void OnCodeGenerated(CodeUI[] codeUIs)
        {
            _codes = codeUIs;

            Entity entity = _entityManager.CreateEntity(_codeGeneratorArchetype);
            _entityManager.SetComponentData(entity, new CodeGeneratorData()
            {
                entityCount = codeUIs.Length,
                characterChangeDurationRange = characterChangeDurationRange
            });
        }
    }
}
