using DOTSessions.CodeRain.ComponentData.Unmanaged;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;

namespace DOTSessions.CodeRain.Jobs
{
    [BurstCompile]
    public partial struct AlphaUpdateJob : IJobEntity
    {
        [ReadOnly] public NativeArray<Entity> activeColumns;

        [ReadOnly] public ComponentLookup<Column> columnLookup;
        [ReadOnly] public ComponentLookup<ColumnConfig> configLookup;
        [ReadOnly] public ComponentLookup<ColumnDissipation> dissipationLookup;

        public float deltaTime;

        public void Execute(in CodePosition codePosition, ref CodeAlpha codeAlpha)
        {
            int gridIndex = codePosition.gridIndex;

            bool columnWasFound = false;

            for (int i = 0; i < activeColumns.Length; ++i)
            {
                if (columnLookup[activeColumns[i]].currentIndex == gridIndex)
                {
                    columnWasFound = true;
                    break;
                }
            }

            if (columnWasFound)
            {
                codeAlpha.alpha = 1f;
            }
            else
            {
                for (int i = 0; i < activeColumns.Length; ++i)
                {
                    ColumnConfig columnConfig = configLookup[activeColumns[i]];
                    if (gridIndex >= columnConfig.startIndex && gridIndex <= columnConfig.endIndex)
                    {
                        ColumnDissipation columnDissipation = dissipationLookup[activeColumns[i]];
                        codeAlpha.alpha = math.max(codeAlpha.alpha - (columnDissipation.dissipationRate * deltaTime), 0);
                        break;
                    }
                }
            }
        }
    }
}
