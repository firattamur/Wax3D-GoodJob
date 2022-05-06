using GameState;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private State _currentState;
    
    private void SetState(State state)
    {
        _currentState = state;
        StartCoroutine(state.StartStateCoroutine());
    }
    
    private void Start()
    {
        SetState(new MenuState(this));   
    }

    private void Update()
    {
        
    }
    
}
