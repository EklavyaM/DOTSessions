using Unity.Entities;

namespace DOTSessions.CodeRain
{
    public partial class CodeUIUpdateSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate(EntityManager.CreateEntityQuery(typeof(CodeData), typeof(CodeUIReference)));
        }

        protected override void OnUpdate()
        {
            Entities.ForEach((ref CodeData data, in CodeUIReference ui) =>
            {
                ui.codeUI.Text = CodeCharacterSheet.GetCharacter(data.characterSheetIndex);
                ui.codeUI.Alpha = data.characterOpacity;
            }).WithoutBurst().Run();
        }
    }
}
