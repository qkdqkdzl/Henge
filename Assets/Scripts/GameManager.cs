using System;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTag
{
    Zombi,
    FlyingStong,
    TargetStone
}
public class GameManager : MonoBehaviour
{
    public ProjectileSo projectileSO;    
    public TargetStoneManager targetStoneManager;
    public MyMainUI mainUI;

    private void Start()
    {


        RaycastDrawer.OnRayCastHitZombiEvent += OnRayCastHitZombiEventHandler;
        TargetStone.OnKnockDownEvent += TargetStone_OnKnockDownEvent;
        TargetStoneManager.OnStageClearEvent += OnStageClearEvent;
        FlyingStone.OnMissionComplete += FlyingStone_OnMissionComplete;
        targetStoneManager.CreateOneTargeStone();
        

    }

    private void FlyingStone_OnMissionComplete()
    {
        mainUI.FlyingStone_OnMissionComplete();
    }

    private void OnStageClearEvent()
    {
        mainUI.OnStageClearEvent();
    }

    private void TargetStone_OnKnockDownEvent(StoneType type)
    {
        mainUI.TargetStone_OnKnockDownEvent((StoneType)type);
    }

    private void OnRayCastHitZombiEventHandler()
    {
        mainUI.OnRayCastHitZombiEventHandler();
        //What to do next? 
    }
}
