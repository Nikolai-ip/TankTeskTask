using Projectile;
using UnityEngine;

namespace Container
{
    public class ProjectileContainer:MonoBehaviour
    {
        [SerializeField] protected ProjectileBase ProjectilePrefab;
        protected PoolMono<ProjectileBase> Pool;
        [SerializeField] protected int Capacity;
        protected virtual void Start()
        {
            Pool = new PoolMono<ProjectileBase>(ProjectilePrefab,Capacity,transform){AutoExpand = true};
        }

        public virtual ProjectileBase GetProjectile() => Pool.GetFreeElement();
    }
}