using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class InputReader : MonoBehaviour
{
    public static event Action<Vector2> movimiento;

    public void Movimiento(InputAction.CallbackContext context)
    {
        movimiento?.Invoke(context.ReadValue<Vector2>());
    }
}
