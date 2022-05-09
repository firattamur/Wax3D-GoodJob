
namespace GameState
{
    public class WaxApplyState: State
    {
        
        public WaxApplyState(GameManager gameManager) : base(gameManager)
        {
        }

        public override void StartState()
        {
            
            gameManager.menuController.MoveMenuUIToOutScreen();
            gameManager.menuController.CreateAndMoveGameUIToScreen();
            
        }
        
    }
}