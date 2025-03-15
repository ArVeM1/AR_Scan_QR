using UnityEngine;

public class RotateARObject : MonoBehaviour
{
    public float rotationSpeed = 0.2f;
    private bool isDragging = false;

    void Update()
    {
        // Вращение мышью для тестов на ПК
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        if (isDragging)
        {
            float rotationX = Input.GetAxis("Mouse Y") * rotationSpeed * 10f;
            float rotationY = -Input.GetAxis("Mouse X") * rotationSpeed * 10f;

            transform.Rotate(Vector3.up, rotationY, Space.World);
            transform.Rotate(Vector3.right, rotationX, Space.World);
        }

        // Вращение через касания для телефона (когда тестируешь на девайсе)
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.y * rotationSpeed;
                float rotationY = -touch.deltaPosition.x * rotationSpeed;

                transform.Rotate(Vector3.up, rotationY, Space.World);
                transform.Rotate(Vector3.right, rotationX, Space.World);
            }
        }
    }
}
