﻿using FlyingFox.Components;
using FlyingFox.ECS;

namespace FlyingFox.Systems
{
    internal class RigidbodySystem : ECSSystem
    {
        public RigidbodySystem(Registry registry) : base(registry)
        {

        }

        public override void Update(Registry registry, float deltaTime)
        {
            var view = registry.View<Rigidbody>();

            foreach (var e in view)
            {
                Rigidbody rb = registry.GetComponent<Rigidbody>(e);

                rb.Update(deltaTime);
            }
        }
    }
}
