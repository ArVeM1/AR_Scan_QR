using UnityEngine;
using Vuforia;

public class QRCodeTracker : MonoBehaviour
{
    private ObserverBehaviour observerBehaviour; // Обновлённое API
    public GameObject laserBeam;

    void Start()
    {
        observerBehaviour = GetComponent<ObserverBehaviour>();
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged += OnTargetStatusChanged;
        }
        laserBeam.SetActive(false); // Изначально скрываем лазер
    }

    private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED)
        {
            laserBeam.SetActive(true); // Показываем лазер при обнаружении QR-кода
        }
        else
        {
            laserBeam.SetActive(false); // Скрываем при потере QR-кода
        }
    }

    private void OnDestroy()
    {
        if (observerBehaviour != null)
        {
            observerBehaviour.OnTargetStatusChanged -= OnTargetStatusChanged;
        }
    }
}
