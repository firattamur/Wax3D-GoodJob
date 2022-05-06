using System.Collections;

namespace GameState
{
    public class RemoveState: State
    {
        
        public RemoveState(GameManager gameManager) : base(gameManager)
        {
        }

        public override IEnumerator StartStateCoroutine()
        {
            yield break;
        }
        
    }
}