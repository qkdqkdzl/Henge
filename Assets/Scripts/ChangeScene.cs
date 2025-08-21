using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    public Button targetButton;
    [SerializeField] CameraLookSequence sequence;  


    void Start()
    {
        targetButton.gameObject.SetActive(false);
        Invoke("ShowButton", 5f);
       
    }

   
    //invoke È£ÃâÇÔ 
    void ShowButton()
    {
        targetButton.gameObject.SetActive(true);
        
        targetButton.onClick.AddListener(() =>
        {
            sequence.StopCameraWork();
            SceneManager.LoadScene("Play");            
        });
       
    }
}
