using System;
using Controllers;
using GameState;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public MenuController menuController;
    
    private State _currentState;
    public static GameManager instance;

    private void Awake()
    {
        
        if (instance != null)
            Destroy(instance);
        else
            instance = this;
        
    }

    public void SetState(State state)
    {
        _currentState = state;
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
