using Common.Models.Units;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Common.Models
{
    public class AdventurePlayer
    {
        private AdventureUnit _controllableUnit;

        public Transform Transform => _controllableUnit.transform;
        public bool IsExist => _controllableUnit != null;
        
        public AdventurePlayer(AdventureUnit controllableUnit)
        {
            _controllableUnit = controllableUnit;
        }
        
        public void StartMoving(InputAction.CallbackContext context)
        {
            Vector2 movementVector = context.ReadValue<Vector2>();

            _controllableUnit.StartMoving(movementVector);
        }

        public void StopMoving(InputAction.CallbackContext context)
        {
            _controllableUnit.StopMoving();
        }

        public void Interact(InputAction.CallbackContext context) => _controllableUnit.Interact();
    }
}