using Projectile;
using UnityEngine;

namespace Container
{
    public class DivisiableProjectileContainer:ProjectileContainer
    {
        [SerializeField] private ProjectileContainer _subProjectileContainer;
        protected override void Start()
        {
            base.Start();
            foreach (var projectile in Pool)
            {
                if (projectile is DivisibleProjectile divisibleProjectile)
                    divisibleProjectile.Init(_subProjectileContainer);
            }
        }
    }
}