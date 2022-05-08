using System;
using Controllers;
using GameState;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public WaxMesh  waxMesh;
    public WaxStick waxStick;

    public GameObject waxStickGameObject;
    public GameObject hairyArmGameObject;

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

    private void Update()
    {
        
    }    
    
    public void DestroyWaxStick()
    {
        Destroy(waxStick);
    }
    
    public void DestroyLevel()
    {
        Destroy(hairyArmGameObject);
    }
    
}
