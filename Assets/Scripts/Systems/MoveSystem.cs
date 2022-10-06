using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client
{
    sealed class MoveSystem : IEcsRunSystem
    {
        EcsCustomInject<GameplayData> _gameplayData = default;

        readonly EcsWorldInject _world = default;
        readonly EcsFilterInject<Inc<Movable>> _filter = default;
        readonly EcsPoolInject<Movable> movePool;
        readonly EcsPoolInject<View> viewPool;


        public void Run(IEcsSystems systems)
        {

            foreach (int entity in _filter.Value)
            {


                ref Movable moveComp = ref movePool.Value.Get(entity);
                ref View viewComp = ref viewPool.Value.Get(entity);
                Vector2 startPos = Vector3.zero;
                Vector3 direction;
                //SideMoving(viewComp, Vector3.forward*0.1f);
                if (Input.touchCount > 0)
                {
                    Touch touch = Input.GetTouch(0);

                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            startPos = touch.position;
                            break;

                        case TouchPhase.Moved:
                            if (touch.deltaPosition.x < startPos.x)
                            {
                                direction = Vector3.left;
                                //SideMoving(viewComp, direction);
                                RbMove(viewComp, direction);
                                //viewComp.Rigidbody.MovePosition(viewComp.Transform.position + direction * Time.deltaTime * _gameplayData.Value.PlayerSpeed);
                            }
                            else
                            {
                                direction = Vector3.right;
                                // SideMoving(viewComp, direction);
                                RbMove(viewComp, direction);
                                //viewComp.Rigidbody.MovePosition(viewComp.Transform.position + direction * Time.deltaTime * _gameplayData.Value.PlayerSpeed);
                            }
                            break;

                        case TouchPhase.Ended:
                            break;
                    }
                }
            }
        }
        private Vector3 SideMoving(View viewComp, Vector3 direction)
        {
            return viewComp.Transform.position += direction * Time.deltaTime * _gameplayData.Value.PlayerSpeed;
        }
        private void RbMove(View viewComp, Vector3 direction)
        {
            viewComp.Rigidbody.MovePosition(viewComp.Transform.position + direction * Time.deltaTime * _gameplayData.Value.PlayerSpeed);

        }
    }
}
