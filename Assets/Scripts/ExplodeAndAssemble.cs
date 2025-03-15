using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeAndAssemble : MonoBehaviour
{
    public GameObject fragmentPrefab; // Префаб фрагментов
    public int fragmentCount = 10; // Количество фрагментов
    public float explosionForce = 300f;
    public float explosionRadius = 2f;
    public float assembleDelay = 3f; // Время до начала сборки

    private List<GameObject> fragments = new List<GameObject>(); // Список фрагментов
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position; // Запоминаем изначальную позицию
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Explode();
        }
    }

    void Explode()
    {
        // Скрываем визуальную модель капсулы, но оставляем её активной
        gameObject.GetComponent<MeshRenderer>().enabled = false; // Отключаем рендер капсулы

        for (int i = 0; i < fragmentCount; i++)
        {
            GameObject fragment = Instantiate(fragmentPrefab, transform.position, Random.rotation);
            Rigidbody rb = fragment.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 explosionDir = (fragment.transform.position - transform.position).normalized;
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
            fragments.Add(fragment); // Сохраняем фрагменты
        }

        // Запуск сборки после задержки
        Invoke(nameof(Assemble), assembleDelay);
    }

    void Assemble()
    {
        foreach (GameObject fragment in fragments)
        {
            StartCoroutine(MoveFragmentToPosition(fragment));
        }

        // Показать капсулу после сборки
        gameObject.GetComponent<MeshRenderer>().enabled = true; // Включаем рендер капсулы обратно
        fragments.Clear(); // Очищаем список фрагментов
    }

    IEnumerator MoveFragmentToPosition(GameObject fragment)
    {
        Vector3 startPos = fragment.transform.position;
        float duration = 1f;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            fragment.transform.position = Vector3.Lerp(startPos, originalPosition, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        Destroy(fragment); // Удаляем фрагменты после сборки
    }
}
