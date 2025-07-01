using System;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "ProjectileSo", menuName = "Scriptable Objects/ProjectileSo")]
public class ProjectileSo : ScriptableObject
{
    public float Mass;
    public float Speed;
    public float Angel;

    //private void Awake()
    //{

    //    var root = GetComponent<UIDocument>().rootVisualElement;

    //    var massSlider = root.Q<Slider>("massSlider");
    //    var speedSlider = root.Q<Slider>("speedSlider");
    //    var angleSlider = root.Q<Slider>("angleSlider");

    //    Assign slider value to variables
    //    massSlider.RegisterValueChangedCallback(evt => Mass = evt.newValue);
    //    speedSlider.RegisterValueChangedCallback(evt => Speed = evt.newValue);
    //    angleSlider.RegisterValueChangedCallback(evt => Angel = evt.newValue);

    //}


}
