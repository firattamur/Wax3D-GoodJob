
namespace GameState
{
    public abstract class State
    {
        protected readonly GameManager gameManager;

        protected State(GameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        public virtual void StartState()
        {
        }
    
    }
}
