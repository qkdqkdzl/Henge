using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;



public class MyMainUI : MonoBehaviour
{
    [SerializeField] Transform Barrel;
    [SerializeField] Transform Cannon;
    [SerializeField] UIDocument _document;
    [SerializeField] StyleSheet _styleSheet;
    [SerializeField] ProjectileLauncher myProjectileLauncher;
    [SerializeField] Transform launchingPad;
    public ProjectileSo projectileSO;
    VisualElement root;
    VisualElement container;
    Button throwBtn, drawBtn, quitBtn;         
    Slider sliderBarrel, sliderCannon, speedSlider, massSlider;
      
    public void OnRayCastHitZombiEventHandler()
    {

    }

    private void Awake()
    {
        root = _document.rootVisualElement;
        root.styleSheets.Add(_styleSheet);
        root.Clear();
        
        container = UTIL.Create<VisualElement>("container");
        drawBtn = UTIL.Create<Button>("button");
        throwBtn = UTIL.Create<Button>("button");
        quitBtn = UTIL.Create<Button>("button");
        throwBtn.text = "Throw";
        drawBtn.text = "Draw";
        quitBtn.text = "Quit";

        sliderBarrel = UTIL.Create<Slider>("my-slider");
        sliderCannon = UTIL.Create<Slider>("my-slider");
        massSlider = UTIL.Create<Slider>("my-slider");
        speedSlider = UTIL.Create<Slider>("my-slider");       
                
        VisualElement buttonContainer = UTIL.Create<VisualElement>("head-box");

        buttonContainer.Add(throwBtn);
        buttonContainer.Add(drawBtn);
        buttonContainer.Add(quitBtn);

        container.Add(buttonContainer);
       
        container.Add(sliderBarrel);
        container.Add(sliderCannon);
        container.Add(massSlider);
        container.Add(speedSlider);
        root.Add(container);
    }

    private void Start()
    {
        TargetStone.OnKnockDownEvent += TargetStone_OnKnockDownEvent;
        FlyingStone.OnMissionComplete += FlyingStone_OnMissionComplete;

        Initialize();
        AddListener();
    } 

    public void TargetStone_OnKnockDownEvent(StoneType obj)
    {
        List<string> list = new List<string>();
        list.Add("OK");
        list.Add("OK, You won! ");        
        ShowPopup(list);
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.P))
        {
            List<string> list = new List<string>();
            list.Add("OK");
            list.Add("OK, You won!");
            ShowPopup(list);
        }
    }

    private void Initialize()
    {
        sliderBarrel.lowValue = 20f - 80f;     // 최초 45 
        sliderBarrel.highValue = 45f + 20f;     //
        sliderCannon.lowValue = 180 - 90f;      //
        sliderCannon.highValue = 180 + 90f;      //
        sliderBarrel.value = 45f;    // 최초의 각 
        sliderCannon.value = 180f;   // 최초의 각
                      
        speedSlider.value = projectileSO.Speed;
        massSlider.value = projectileSO.Mass;
    }

    void AddListener()
    {
        throwBtn.clicked += OnThrowButtonClick;
        drawBtn.clicked += OnDrawButtonClick;
        quitBtn.clicked += OnQuitButtonClick;

        drawBtn.RegisterCallback<MouseEnterEvent>(evt =>
        {
            Debug.Log("Mouse entered button!");
            drawBtn.style.backgroundColor = new StyleColor(Color.green);
            myProjectileLauncher.isDrawing = true;
        });

        drawBtn.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            Debug.Log("Mouse exited button!");
            drawBtn.style.backgroundColor = new StyleColor(Color.white);
            myProjectileLauncher.isDrawing = false;
        });
        //TODO ...
        sliderBarrel.RegisterValueChangedCallback(evt =>
        {
            Barrel.localRotation = Quaternion.Euler(0f, evt.newValue, 0f);
        });

        sliderCannon.RegisterValueChangedCallback(evt =>
        {
            Cannon.localRotation = Quaternion.Euler(0f, evt.newValue, 0f);
        });
               
        
        speedSlider.RegisterValueChangedCallback(evt =>
        {
            projectileSO.Speed = evt.newValue;
            speedSlider.label = string.Concat(evt.newValue.ToString(), " Speed");

        });
        massSlider.RegisterValueChangedCallback(evt =>
        {
            projectileSO.Mass = evt.newValue;
            massSlider.label = string.Concat(evt.newValue.ToString(), " Mass");

        });
    }

    private void OnQuitButtonClick()
    {

    }

    private void OnDrawButtonClick()
    {

    }

    private void OnThrowButtonClick()
    {
        Debug.Log("ddd");
        myProjectileLauncher.ThrowStone();        
        container.visible = false;
    }
    public void FlyingStone_OnMissionComplete()
    {
        container.visible = true;
    }
    public void OnStageClearEvent()
    {

    }    
    
    public void ShowPopup(List<string> texts)
    {
        var _popupContainer = UTIL.Create<VisualElement>("full-box");
        var _popup = UTIL.Create<VisualElement>("popup-container");

        foreach (string text in texts)
        {
            UnityEngine.UIElements.Label label = UTIL.Create<UnityEngine.UIElements.Label>("label");
            label.AddToClassList("label-exercise");
            label.text = text;
            _popup.Add(label);
        }
        var closebtn = UTIL.Create<Button>("button", "bottom-button");
        closebtn.text = "Close";
        closebtn.clicked += () =>
        {
            StartCoroutine(FadeOut(_popupContainer));
        };

        _popupContainer.Add(_popup);
        _popupContainer.Add(closebtn);
        root.Add(_popupContainer);
        StartCoroutine(FadeIn(_popupContainer));
    }
    IEnumerator FadeIn(VisualElement element)
    {
        element.AddToClassList("fade");
        yield return null;
        element.AddToClassList("fade-in");
    }
    IEnumerator FadeOut(VisualElement element)
    {

        element.AddToClassList("fade-hidden");

        yield return new WaitForSeconds(0.5f);
        element.RemoveFromHierarchy();
       

    }

    private void SetupElements()
    {
        sliderBarrel.lowValue = 45f - 20f;     // 최초 45 
        sliderBarrel.highValue = 45f + 20f;     //
        sliderCannon.lowValue = 180 - 90f;      //
        sliderCannon.highValue = 180 + 90f;      //
        sliderBarrel.value = 45f;    // 최초의 각 
        sliderCannon.value = 180f;   // 최초의 각


    }
}