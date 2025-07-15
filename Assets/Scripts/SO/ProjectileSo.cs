using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ProjectileSo", menuName = "Scriptable Objects/ProjectileSo")]
public class ProjectileSo : ScriptableObject
{
    public float Mass;
    public float Speed;
    public float AngleY;
    public float AngleZ;



}
