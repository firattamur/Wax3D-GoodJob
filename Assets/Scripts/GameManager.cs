using Controllers;
using GameState;
using Helper;


public class GameManager : Singleton<GameManager>
{

    public MenuController menuController;
    
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
