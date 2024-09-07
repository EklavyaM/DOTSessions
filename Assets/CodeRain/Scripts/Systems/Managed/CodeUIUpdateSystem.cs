using DOTSessions.CodeRain.ComponentData.Unmanaged;
using DOTSessions.CodeRain.Mono;
using DOTSessions.CodeRain.Shared;
using DOTSessions.CodeRain.Systems.Unmanaged;
using Unity.Entities;
using UnityEngine;

namespace DOTSessions.CodeRain.Systems.Managed
{
    [UpdateAfter(typeof(CharacterUpdateSystem))]
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
                codeUI.Alpha = Mathf.MoveTowards(codeUI.Alpha, codeAlpha.alpha, SystemAPI.Time.DeltaTime);
            }).WithoutBurst().Run();
        }
    }
}
