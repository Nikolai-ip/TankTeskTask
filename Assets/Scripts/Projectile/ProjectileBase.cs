using UnityEngine;

namespace Projectile
{
    public class ProjectileBase : MonoBehaviour
    {
        private const string GroundLayer = "Ground";
        [SerializeField] protected float Force;
        protected Rigidbody2D Rb;

        protected virtual void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }

        public virtual void StartProjectile(float angle, Vector2 position)
        {
            transform.position = position;
            angle *= Mathf.Deg2Rad;
            Vector2 forceDirection = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized; 
            Rb.AddForce(forceDirection * Force, ForceMode2D.Impulse);        
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer(GroundLayer))
                Destroy();
        }

        protected virtual void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}