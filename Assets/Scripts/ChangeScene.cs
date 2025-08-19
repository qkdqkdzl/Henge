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

        sequence.StopCameraWork();

        targetButton.gameObject.SetActive(true);
        
        targetButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("Play");
        });
       
    }
}
