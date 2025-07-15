using System;
using UnityEngine;

public class FlyingStone : MonoBehaviour
{
    public static event Action OnMissionComplete;    // �������� ��
    // ������: MainUI.  Why   button �� Slider�� Unlock. 
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
