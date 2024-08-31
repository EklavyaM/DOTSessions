using Unity.Entities;

namespace DOTSessions.CodeRain
{
    public partial class CodeUIUpdateSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate(EntityManager.CreateEntityQuery(typeof(CodeData)));
        }

        protected override void OnUpdate()
        {
            CodeGridData gridData = SystemAPI.ManagedAPI.GetSingleton<CodeGridData>();

            Entities.ForEach((ref CodeData data) =>
            {
                gridData.grid[data.gridIndex].Text = CodeCharacterSheet.GetCharacter(data.characterIndex);
                gridData.grid[data.gridIndex].Alpha = data.characterOpacity;
            }).WithoutBurst().Run();
        }
    }
}
