using Leopotam.EcsLite;
using UnityEngine;

namespace Client {
    sealed class InitPlayer : IEcsInitSystem {
        public void Init (IEcsSystems systems) {

            var go = GameObject.FindGameObjectWithTag("Player");
            var world = systems.GetWorld();
            var entity = world.NewEntity();

            world.GetPool<Player>().Add(entity);

            ref var moveComp = ref world.GetPool<Movable>().Add(entity);
            //moveComp.Speed = 5;

            ref var viewComp = ref world.GetPool<View>().Add(entity);
            viewComp.Transform = go.transform;
            viewComp.Rigidbody = go.GetComponent<Rigidbody>();
            
        }
    }
}