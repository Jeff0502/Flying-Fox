using System.Collections;
using System.Collections.Generic;

namespace FlyingFox.ECS
{
    public struct Group : IEnumerable<uint>
    {
        // A way to access multiple components simultaneously (at once)
        Registry registry;
        Registry.GroupData groupData;

        internal Group(Registry registry, Registry.GroupData groupData)
        {
            this.registry = registry;
            this.groupData = groupData;
        }

        public IEnumerator<uint> GetEnumerator() => groupData.Entities.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}