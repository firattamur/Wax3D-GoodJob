using System;
using Controllers;
using GameState;
using Helper;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public MenuController menuController;
    
    public static GameManager instance;

    private void Awake()
    {
        base.Awake();
    }

    public void SetState(State state)
    {
        state.StartState();
    }
    
    private void Start()
    {
        SetState(new MenuState(this));
    }

    public void StartGame()
    {
        SetState(new WaxApplyState(this));
    }

}
