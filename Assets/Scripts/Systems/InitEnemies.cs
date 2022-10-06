using Leopotam.EcsLite;
using UnityEngine;

namespace Client
{
    sealed class InitEnemies : IEcsInitSystem
    {
        public void Init(IEcsSystems systems)
        {

            var gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
            var world = systems.GetWorld();
            foreach (var go in gameObjects)
            {
               var entity = world.NewEntity();
                world.GetPool<Enemy>().Add(entity);

                //ref var moveComp = ref world.GetPool<Movable>().Add(entity);
                //moveComp.Speed = 2;

                //ref var viewComp = ref world.GetPool<View>().Add(entity);
                //viewComp.Transform = go.transform; 
            }

        }
    }
}