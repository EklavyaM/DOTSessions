using DOTSessions.CodeRain.ComponentData.Unmanaged;
using DOTSessions.CodeRain.Mono;
using DOTSessions.CodeRain.Shared;
using DOTSessions.CodeRain.Systems.Unmanaged;
using Unity.Entities;

namespace DOTSessions.CodeRain.Systems.Managed
{
    [UpdateAfter(typeof(AlphaUpdateSystem))]
    public partial class CodeUIUpdateSystem : SystemBase
    {
        protected override void OnCreate()
        {
            RequireForUpdate(EntityManager.CreateEntityQuery(typeof(CodePosition), typeof(CodeCharacter), typeof(CodeAlpha)));
        }

        protected override void OnUpdate()
        {
            ComponentData.Managed.GridData gridData = SystemAPI.ManagedAPI.GetSingleton<ComponentData.Managed.GridData>();

            Entities.ForEach((in CodeCharacter codeCharacter, in CodePosition codePosition, in CodeAlpha codeAlpha) =>
            {
                CodeUI codeUI = gridData.grid[codePosition.gridIndex];

                codeUI.Text = CharacterSheet.GetCharacter(codeCharacter.characterIndex);
                codeUI.Alpha = codeAlpha.alpha;
            }).WithoutBurst().Run();
        }
    }
}
