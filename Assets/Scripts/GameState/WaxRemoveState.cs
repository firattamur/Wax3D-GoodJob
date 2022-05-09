
namespace GameState
{
    public class WaxRemoveState: State
    {
        
        public WaxRemoveState(GameManager gameManager) : base(gameManager)
        {
        }

        public override void StartState()
        {
            gameManager.menuController.DestroyWaxStickGameObject();
        }
        
    }
}