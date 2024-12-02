using System.Collections;
using UnityEngine;

namespace Controller
{
    public class RotateController : MonoBehaviour
    {
        private Transform _tr;
        [SerializeField] private float _angleOffset;
        [SerializeField] private float _maxAngle;
        [SerializeField] private float _minAngle;
        [SerializeField] private float _rotateDuration;
        public float Angle => _tr.localEulerAngles.z;

        void Start()
        {
            _tr = GetComponent<Transform>();
            StartCoroutine(Rotate());
        }

        private IEnumerator Rotate()
        {
            while (true)
            {
                float targetAngle = _tr.localEulerAngles.z == _maxAngle ? _minAngle : _maxAngle;
                yield return RotateTo(targetAngle);
            }
        }

        public IEnumerator RotateTo(float targetAngle)
        {
            float time = 0;
            float originalAngle = _tr.localEulerAngles.z;
            while (time < _rotateDuration)
            {
                time += Time.deltaTime;
                float angle = Mathf.LerpAngle(originalAngle, targetAngle, time / _rotateDuration);
                _tr.localEulerAngles = new Vector3(0, 0, angle);
                yield return null;
            }
            _tr.localEulerAngles = new Vector3(0, 0, targetAngle);
        }
        public void Rotate(Vector2 at)
        {
            Vector2 pos = _tr.position;
            Vector2 dir = (at - pos).normalized;
            float angle  = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            angle = Mathf.Clamp(angle, _minAngle, _maxAngle);
            _tr.rotation = Quaternion.Euler(0, 0, angle + _angleOffset);
        }
    }
}
