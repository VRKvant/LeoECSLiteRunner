using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client {
    sealed class KeyboardInputSystem : IEcsRunSystem {
        readonly EcsFilterInject<Inc<Player, PlayerInput>> _player = default;
        readonly EcsPoolInject<MoveCommand> _moveCommandPool = default;
        public void Run (IEcsSystems systems) {
            // add your run code here.
            foreach (var entity in _player.Value)
            {
                var horizInput = Input.GetAxisRaw("Horizontal");

            }
        }
    }
}