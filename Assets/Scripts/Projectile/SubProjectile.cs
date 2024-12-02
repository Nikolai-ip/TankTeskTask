using UnityEngine;

namespace Projectile
{
    public class SubProjectile:ProjectileBase
    { 
        public void StartProjectile(float angle, Vector2 originVelocity, Vector2 startPosition)
        {
            transform.position = startPosition;
            angle *= Mathf.Deg2Rad;
            Vector2 forceDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized; 
            Rb.AddForce(forceDirection * (originVelocity.magnitude+Force), ForceMode2D.Impulse);
        }
    }
}