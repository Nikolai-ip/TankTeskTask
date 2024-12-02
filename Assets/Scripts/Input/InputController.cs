using System;
using UnityEngine;

namespace Input
{
    public class InputController:MonoBehaviour
    {
        public event Action FireButtonPressed;
        
        public void OnFireButton()
        {
            FireButtonPressed?.Invoke();    
        }
    }
}