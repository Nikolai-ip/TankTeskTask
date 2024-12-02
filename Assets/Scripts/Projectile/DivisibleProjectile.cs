using Container;
using UnityEngine;

namespace Projectile
{
    public class DivisibleProjectile:ProjectileBase
    {
        private float _maxY;
        [SerializeField] private int _subProjectileCount = 3;
        [SerializeField] private float _maxAngle;
        [SerializeField] private float _minAngle;
        private ProjectileContainer _subProjectileContainer;
        public void Init(ProjectileContainer container)
        {
            _subProjectileContainer = container;
        }

        public override void StartProjectile(float angle, Vector2 position)
        {
            base.StartProjectile(angle, position);
            angle *= Mathf.Deg2Rad;
            float initialVelocity = Force /  Rb.mass;
            _maxY = (Mathf.Pow(initialVelocity * Mathf.Sin(angle), 2)) / (2 * Mathf.Abs(Physics2D.gravity.y));
            _maxY += transform.position.y;
        }
        private void Update()
        {
            if (Mathf.Abs(transform.position.y - _maxY)<0.05f)
            {
                CreateSubProjectiles();
                Destroy();
            }
        }

        private void CreateSubProjectiles()
        {
            float angleStep = (Mathf.Abs(_maxAngle) + Mathf.Abs(_minAngle)) / (_subProjectileCount - 1);
            Vector3 direction = Rb.velocity.normalized;
            float originAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            for (int i = 0; i < _subProjectileCount; i++)
            {
                float subAngle = _minAngle + i * angleStep;
                SubProjectile subProjectile = (SubProjectile)_subProjectileContainer.GetProjectile();
                float angle = originAngle + subAngle;
                subProjectile.StartProjectile(angle, Rb.velocity, transform.position); 
            }
        }
    }
}