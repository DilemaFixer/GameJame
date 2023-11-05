using UnityEngine;

namespace Game.Player
{
    public class Telekinesis : MonoBehaviour
    {
        [SerializeField] private float _telekinesisLength = 10f;
        [SerializeField] private float _pursuitSpeed;
        [SerializeField] private Transform _player;
        [SerializeField] private Transform _camera;
        [SerializeField] private Material _selectionMaterial;
        [SerializeField] private Transform _pickUpPoint;
        [SerializeField] private LayerMask _targetLayer;
        [SerializeField] private TelekinesTargetObj _test;
        
        private TelekinesTargetObj _currentTargetObj;

        public void Awake()
        {
            _currentTargetObj = _test;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                TelekinesisUpdate();
            }

            if (Input.GetMouseButtonUp(1))
            {
                Drop();
            }
        }

        public void FixedUpdate()
        {
            if (_currentTargetObj != null)
            {
                Vector3 targetDirection = _pickUpPoint.position - _currentTargetObj.transform.position;
                _currentTargetObj.SetVelocity(targetDirection * _pursuitSpeed);
            }
        }

        public void TelekinesisUpdate()
        {
            RaycastHit hit ;
            
            if (Physics.Raycast(_player.transform.position, _player.transform.forward, out hit , _telekinesisLength,
                    _targetLayer))
            {
                if (hit.collider.TryGetComponent<TelekinesTargetObj>(out TelekinesTargetObj telekinesTargetObj))
                {
                    if (_currentTargetObj != null)
                    {
                        _currentTargetObj.OnDown();
                    }
                   
                    _currentTargetObj = telekinesTargetObj;
                    _currentTargetObj.OnUp();
                    _currentTargetObj.SetMaterial(_selectionMaterial);
                   
                }
            }
        }

        public void Drop()
        {
            if (_currentTargetObj != null)
            {
                _currentTargetObj.OnDown();
                _currentTargetObj = null;  
            }
        }
    }
}