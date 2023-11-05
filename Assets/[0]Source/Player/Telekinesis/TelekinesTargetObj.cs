using System;
using UnityEngine;

namespace Game.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class TelekinesTargetObj : MonoBehaviour
    {
        [SerializeField] private Renderer _renderer;
        [SerializeField] private Rigidbody _rigidbody;

        private void Update()
        {
            _rigidbody.angularVelocity = new Vector3(0, 0, 0);
        }

        public void SetMaterial(Material material)
        {
            _renderer.material = material;
        }

        public void OnUp()
        {
            _rigidbody.useGravity = false;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
        }

        public void OnDown()
        {
            _rigidbody.useGravity = true;
            _rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;
        }
        
        public void SetVelocity(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
        }
    }
}