using UnityEngine;

public class CapsuleExplosion : MonoBehaviour
{
    public GameObject fragmentPrefab; // Префаб кусочков капсулы
    public int fragmentCount = 10; // Количество фрагментов
    public float explosionForce = 300f; // Сила взрыва
    public float explosionRadius = 2f; // Радиус взрыва

    private bool isExploded = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isExploded)
        {
            Explode();
        }
    }

    void Explode()
    {
        isExploded = true;

        // Уничтожаем капсулу (или скрываем)
        gameObject.SetActive(false);

        // Генерация фрагментов
        for (int i = 0; i < fragmentCount; i++)
        {
            GameObject fragment = Instantiate(fragmentPrefab, transform.position, Random.rotation);
            Rigidbody rb = fragment.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 explosionDir = (fragment.transform.position - transform.position).normalized;
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }

            // Автоматическое удаление фрагментов через 5 секунд
            Destroy(fragment, 5f);
        }
    }
}
