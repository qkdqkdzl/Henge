using UnityEngine;
using UnityEngine.UIElements;

public class MainUI : MonoBehaviour
{
    [SerializeField] private ProjectileSo projectileSo;
    [SerializeField] private UIDocument myUI;

    private VisualElement root;
    private Button throwBtn;

    private void Awake()
    {
        root = myUI.rootVisualElement;
        throwBtn = root.Q<Button>("ThrowBtn");

        throwBtn.clicked += OnThrowButtonClicked;
    }

    private void OnThrowButtonClicked()
    {

    }
}
