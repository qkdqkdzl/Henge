using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    [SerializeField] private ProjectileSo projectileSo;
    [SerializeField] private UIDocument myUI;
    [SerializeField] Transform launchingPad;
    [SerializeField] ProjectileLauncher myProjectileLauncher;


    private VisualElement root;
    private Button throwBtn;
    Slider angleSlider;
    Slider massSlider;
    Slider speedSlider;

    private void Awake()
    {
        root = myUI.rootVisualElement;

        throwBtn = root.Q<Button>("ThrowBtn");

        massSlider = root.Q<Slider>("massSlider");
        speedSlider = root.Q<Slider>("speedSlider");
        angleSlider = root.Q<Slider>("angleSlider");
    }

    private void Start()
    {
        throwBtn.clicked += OnThrowButtonClicked;

        
        angleSlider.value = launchingPad.transform.rotation.eulerAngles.z;

        angleSlider.RegisterValueChangedCallback(evt =>
        {
            float angle = evt.newValue;
            launchingPad.transform.rotation = Quaternion.Euler(0, 0, angle);
        });

        
    }

    private void OnThrowButtonClicked()
    {
        myProjectileLauncher.ThrowStone();
    }
}
