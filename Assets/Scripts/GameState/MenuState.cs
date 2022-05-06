using System.Collections;

namespace GameState
{
    public class MenuState: State
    {
        public MenuState(GameManager gameManager) : base(gameManager)
        {
        }

        public override IEnumerator StartStateCoroutine()
        {
            yield break;
        }
        
    }
}