using UnityEngine;

public class LaserBeam : MonoBehaviour
{
    private LineRenderer lineRenderer;

    public float laserDistance = 5.0f; // Длина луча
    public Transform laserEndPoint; // Конечная точка, если хочешь контролировать её вручную

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;  // Два положения: начало и конец
    }

    void Update()
    {
        // Стартовая точка — текущая позиция объекта
        lineRenderer.SetPosition(0, transform.position);

        // Конечная точка — вперед от объекта (по его локальной оси Z)
        Vector3 endPosition = transform.position + transform.forward * laserDistance;
        lineRenderer.SetPosition(1, endPosition);  // Устанавливаем конечную точку

        // Если есть лазерная конечная точка (например, объект с физическим взаимодействием)
        if (laserEndPoint != null)
        {
            lineRenderer.SetPosition(1, laserEndPoint.position);
        }
    }
}
