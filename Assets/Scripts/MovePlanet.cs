using UnityEngine;

public class RotateAndStop : MonoBehaviour
{
    public float rotationSpeed = 20f; // Скорость вращения
    private bool isRotating = true;   // Флаг для проверки, можно ли вращать

    void Update()
    {
        // Вращение модели, если флаг включен
        if (isRotating)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        // Проверка на клик мышью (ПК) или касание (мобильные)
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            isRotating = false; // Останавливает вращение при касании/зажиме
        }

        // Возобновление вращения, если кнопку отпустили
        if (Input.GetMouseButtonUp(0))
        {
            isRotating = true;
        }
    }
}
