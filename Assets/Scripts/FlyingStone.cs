using System;
using UnityEngine;

public class FlyingStone : MonoBehaviour
{
    public static event Action OnMissionComplete;
    // �������� ��
    // ������: MainUI.  Why   button �� Slider�� Unlock. 

    private void Start()
    {
        TrailRenderer trail = gameObject.AddComponent<TrailRenderer>();
        trail.material = new Material(Shader.Find("Sprites/Default"));
        trail.startColor = Color.yellow;
        trail.endColor = Color.clear;
        trail.time = 0.5f;
        trail.startWidth = 0.2f;
        trail.endWidth = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            OnMissionComplete?.Invoke();
            Destroy(gameObject, 3);
        }

        if (collision.gameObject.CompareTag("Target"))
        {
            OnMissionComplete?.Invoke();
            Destroy(gameObject, 3);
        }
    }    
}
