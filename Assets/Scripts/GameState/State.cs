using System.Collections;

namespace GameState
{
    public abstract class State
    {
        private readonly GameManager _gameManager;

        protected State(GameManager gameManager)
        {
            _gameManager = gameManager;
        }

        public virtual IEnumerator StartStateCoroutine()
        {
            yield break;
        }
    
    }
}
