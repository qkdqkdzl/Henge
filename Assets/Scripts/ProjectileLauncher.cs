using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform IaunchPoint;
    public GameObject progectie;
    public float Speed = 10f;
    public int IinePoints;


    //[Header("-------Tragectory--------")]
    public LineRenderer lineRenderer;


    void Update()
    {
        if (lineRenderer != null)
        {
            if (Input.GetMouseButton(1))
            {
                DrawTrajectory();
                lineRenderer.enabled = true;
            }
            else
                lineRenderer.enabled = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            var _projectile = Instantiate(progectie, IaunchPoint.position, IaunchPoint.rotation);
            _projectile.GetComponent<Rigidbody>().linearVelocity = Speed * IaunchPoint.up;
        }
    }
    void DrawTrajectory()
    {
        Vector3 origin = IaunchPoint.position;
        Vector3 startVelocity = Speed * IaunchPoint.up;
        float time = 0;
        for (int i = 0; i < IinePoints; i++)
        {
            var x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            var y = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
        }
    }
}
