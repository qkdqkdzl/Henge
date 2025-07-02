using UnityEngine;

public class FoilowPlayer : MonoBehaviour
{
    public float speed = 5f;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("player");
    }

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, 
                player.transform.position, speed * Time.deltaTime);
        }
    }
}
