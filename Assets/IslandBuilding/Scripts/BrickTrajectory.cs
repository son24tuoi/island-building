using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Construction
{
    public class BrickTrajectory : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private Transform start;
        [SerializeField] private Transform target;
        [SerializeField] private float h = 5f;
        [SerializeField] private float g = -9.81f;

        [Header("Datas")]
        private float _t1 = 0.5f;
        private float _t2 = 0.5f;
        private float _totalTime = 1f;

        private Vector3 _startPos;
        private Vector3 _targetPos;

        private Vector3 _velX;
        private Vector3 _velY;
        private Vector3 _velocity;

        private bool _isValid;

        public float T1 => _t1;
        public float T2 => _t2;
        public float TotalTime => _totalTime;

        public Vector3 StartPos => _startPos;
        public Vector3 TargetPos => _targetPos;

        public bool IsValid => _isValid;

        [ContextMenu(nameof(Setup))]
        public void Setup()
        {
            _startPos = start.position;
            _targetPos = target.position;

            if (_targetPos.y - _startPos.y >= h)
            {
                _isValid = false;
                Debug.LogError(nameof(BrickTrajectory) + ": Invalid h value");
                return;
            }

            _isValid = true;

            Vector3 dXZ = new Vector3(_targetPos.x - _startPos.x, 0, _targetPos.z - _startPos.z);

            _t1 = Mathf.Sqrt(-2 * h / g);
            _t2 = Mathf.Sqrt(-2 * (h + (_startPos.y - _targetPos.y)) / g);
            _totalTime = _t1 + _t2;

            _velX = Vector3.up * Mathf.Sqrt(-2 * g * h);
            _velY = dXZ / (_t1 + _t2);

            _velocity = _velX + _velY;
        }

        public Vector3 GetPos(float t)
        {
            return _startPos + _velocity * t + 0.5f * g * t * t * Vector3.up;
        }

        public Vector3 GetHighestPos()
        {
            return GetPos(T1);
        }
    }
}
