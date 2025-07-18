using NUnit.Framework.Constraints;
using System;
using System.Collections;
using UnityEngine;
public enum StoneType
{
    Low,
    Middle,
    High
}
public class TargetStone : MonoBehaviour
{
    public static event Action<StoneType> OnHitByProjectile;
    public static event Action<StoneType> OnKnockDownEvent;
    public static event Action<Vector3> OnKnockDownToZombiEvent;
    
    public StoneType stoneType;
    public Renderer objRenderer;

    float fadeDuration = 2f;
    Color originalColor;
    bool isHit = false;

    private void Start()
    {
        originalColor = objRenderer.material.color;
    }
    private void OnCollisionEnter(Collision collision)
    {
        MeshCollider meshCollider = GetComponent<MeshCollider>();
        if (collision.gameObject.CompareTag("Stone"))
        {
            OnHitByProjectile?.Invoke(stoneType);
            isHit = true;
        }
        ContactPoint contact = collision.contacts[0];
        Vector3 contactPoint = contact.point;


        if (meshCollider != null)
        {
            float edgeDsitance = EdgeDistanceCalculator.GetDistanceToNearestEdge(meshCollider, contactPoint);
            Debug.Log("Distanec to nearest edge: " + edgeDsitance);
        }
        

    }



    void Update()
    {
        if (isHit)
        {
            //TODO : 넘어짐 판정 수정
            //과제:   타켓 스톤의 넘어짐 판정을  다시 만들기 
            //울퉁불퉁한 돌이 넘어지면, 270도, 90도가 아니어서,
            //기존 코드는 완벽하지 않음.그래서, 이 부분을 레이케스트를 이용해서 넘어짐 판정을 하는 것으로 코딩하기.

            

            if ((Math.Abs(transform.eulerAngles.z - 270) < 3f) || Math.Abs(transform.eulerAngles.z - 90f) < 3)
            {
                OnKnockDownToZombiEvent?.Invoke(transform.position);
                StartCoroutine(FadeOutObject());
                isHit = false;

            }
        }
    }

    IEnumerator FadeOutObject()
    {
        float elapsed = 0f;
        while (elapsed < 2)
        {
            float alpha = Mathf.Lerp(originalColor.a, 0f, elapsed / fadeDuration);
            Color newColor = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            objRenderer.material.color = newColor;
            elapsed += Time.deltaTime;
            yield return null;
        }
        Color finalColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        objRenderer.material.color = finalColor;
        yield return new WaitForSeconds(0.5f);
        OnKnockDownEvent?.Invoke(stoneType);
        Destroy(gameObject);
    }


}
