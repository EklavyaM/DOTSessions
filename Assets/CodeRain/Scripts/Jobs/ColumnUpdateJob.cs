using DOTSessions.CodeRain.ComponentData.Unmanaged;
using DOTSessions.Common;
using DOTSessions.Common.Randomizer;
using DOTSessions.Common.Timer;
using Unity.Burst;
using Unity.Entities;

namespace DOTSessions
{
    [BurstCompile]
    public partial struct ColumnUpdateJob : IJobEntity
    {
        public MinMax<float> columnUpdateDurationRange;
        public MinMax<float> dissipationRateRange;

        public void Execute(ref Randomizer randomizer, in ColumnConfig columnConfig, ref ColumnDissipation columnDissipation, ref Column column, ref TimerData timer)
        {
            if (timer.HasExpired)
            {
                timer.elapsed = 0f;

                if (column.currentIndex < columnConfig.endIndex)
                {
                    ++column.currentIndex;
                }
                else
                {
                    column.currentIndex = columnConfig.startIndex;
                    columnDissipation.dissipationRate = randomizer.rng.NextFloat(dissipationRateRange.min, dissipationRateRange.max);

                    timer.duration = randomizer.rng.NextFloat(columnUpdateDurationRange.min, columnUpdateDurationRange.max);
                }
            }
        }
    }
}
