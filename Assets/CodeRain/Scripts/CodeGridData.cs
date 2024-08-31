using Unity.Entities;
using Unity.Mathematics;

namespace DOTSessions.CodeRain
{
    public class CodeGridData : IComponentData
    {
        public CodeUI[] grid;
        public int2 size;
    }
}
