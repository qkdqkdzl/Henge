using System;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject progectie;
    public float Speed = 10f;
    public int IinePoints;

    public CameraFollow cameraFollow;
    public GameObject projectile;
    public ProjectileSo projectileSo;
    public CannonShake cannonShake;
    public ParticleSystem particleSystem;



    public bool isDrawing = false;


    [Header("-------Tragectory--------")]
    public LineRenderer lineRenderer;
    

    void Update()
    {
        particleSystem.Stop();
        if (lineRenderer != null)
        {
            if (isDrawing)
            {
                DrawTrajectory();
                lineRenderer.enabled = true;
            }
            else
                lineRenderer.enabled = false;
        }
       
    }
    void DrawTrajectory()
    {
        
        Vector3 origin = launchPoint.position;
        Vector3 startVelocity = Speed * launchPoint.up;
        float time = 0;
        for (int i = 0; i < IinePoints; i++)
        {
            var x = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            var y = (startVelocity.x * time) + (Physics.gravity.x / 2 * time * time);
            
        }
    }

    public  void ThrowStone()
    {
        cannonShake.Fire();
        particleSystem.Play();


        lineRenderer.enabled = false;
        Quaternion rot = launchPoint.rotation;
        rot.x = projectileSo.AngleX;
        rot.y = projectileSo.AngleY;
        rot.z = projectileSo.AngleZ;
        var _projectile = Instantiate(progectie, launchPoint.position, launchPoint.rotation);
        _projectile.GetComponent<Rigidbody>().linearVelocity = Speed * launchPoint.up;
        cameraFollow.SetTarget(_projectile.transform);
        
    }

    
}
