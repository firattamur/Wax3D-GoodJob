
namespace GameState
{
    public class MenuState: State
    {
        public MenuState(GameManager gameManager) : base(gameManager)
        {
        }

        public override void StartState()
        {
            
            gameManager.menuController.UnDisplayGameUI();
            gameManager.menuController.DisplayMenuUI();
            
        }
        
    }
}