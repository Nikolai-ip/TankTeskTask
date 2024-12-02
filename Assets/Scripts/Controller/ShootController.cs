using System;
using Container;
using Input;
using Projectile;
using UnityEngine;

namespace Controller
{
    public class ShootController:MonoBehaviour
    {
        [SerializeField] private ProjectileBase _shotPrefab;
        [SerializeField] private Transform _shotPoint;
        [SerializeField] private ProjectileContainer _divisibleProjectileContainer;
        private InputController _inputController;
        private Transform _tr;

        public event Action Shooted;

        private void Start()
        {
            _tr = transform;
            _inputController = FindObjectOfType<InputController>();
            _inputController.FireButtonPressed += OnFire;
        }

        private void OnFire()
        {
            Shoot(_tr.localEulerAngles.z);
        }

        private void Shoot(float angle)
        {
            Shooted?.Invoke();
            ProjectileBase projectileBase = _divisibleProjectileContainer.GetProjectile();
            projectileBase.StartProjectile(angle,_shotPoint.transform.position);
        }
    }
}