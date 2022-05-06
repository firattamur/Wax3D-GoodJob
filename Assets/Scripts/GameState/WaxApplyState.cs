using System.Collections;

namespace GameState
{
    public class WaxApplyState: State
    {
        
        public WaxApplyState(GameManager gameManager) : base(gameManager)
        {
        }

        public override IEnumerator StartStateCoroutine()
        {
            yield break;
        }
        
    }
}