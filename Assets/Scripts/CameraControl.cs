using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target; // El GameObject a seguir
    public float smoothSpeed = 0.125f; // Suavizado del seguimiento
    public float yOffset = -1.5f; // Offset en Y (negativo para que el personaje quede m�s abajo)

    private float fixedZ;

    void Start()
    {
        fixedZ = transform.position.z; // Mantener la Z fija (�til para 2D)
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Calcula la posici�n deseada con offset en Y
        Vector2 desiredPosition2D = new Vector2(target.position.x, target.position.y + yOffset);

        // Interpolaci�n suave
        Vector2 smoothedPosition2D = Vector2.Lerp((Vector2)transform.position, desiredPosition2D, smoothSpeed);

        // Aplica la posici�n final con Z fija
        transform.position = new Vector3(smoothedPosition2D.x, smoothedPosition2D.y, fixedZ);
    }
}
