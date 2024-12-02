using System.Collections;
using Controller;
using UnityEngine;

namespace Animation
{
    public class GunAnimator:MonoBehaviour
    {
        private const string Shoot = "Shoot";
        [SerializeField] private ShootController _shootController;
        private Animator _animator;
        [SerializeField] private float _recoilTime = 1;
        [SerializeField] private float _backMovementTime = 1;
        [SerializeField] private float _recoilXPos;
        private Transform _tr;

        private void Start()
        {
            _tr = GetComponent<Transform>();
            _animator = GetComponent<Animator>();
            _shootController.Shooted += PlayShootAnim;
        }

        private void PlayShootAnim()
        {
            _animator.SetTrigger(Shoot);
            StartCoroutine(RecoilAnimation());
        }

        private IEnumerator RecoilAnimation()
        {
            Vector2 originPos = _tr.position;
            Vector2 target = originPos - (Vector2)_tr.right * _recoilXPos;
            float step = 0;
            while (step < _recoilTime)
            {
                step += Time.deltaTime;
                _tr.position = Vector2.Lerp(originPos, target, step/_recoilTime);
                yield return null;
            }
            step = 0;
            Vector2 _recoilFinalPoint = _tr.position;
            while (step < _backMovementTime)
            {
                step += Time.deltaTime;
                _tr.position = Vector2.Lerp( _recoilFinalPoint, originPos, step/_backMovementTime);
                yield return null;
            }
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position-transform.right*_recoilXPos,0.1f);
        }
    }
}