using System.Collections;

namespace GameState
{
    public class WaxDryState: State
    {
        
        public WaxDryState(GameManager gameManager) : base(gameManager)
        {
        }

        public override IEnumerator StartStateCoroutine()
        {
            yield break;
        }
        
    }
}