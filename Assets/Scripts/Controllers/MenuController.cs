using UnityEngine;

namespace Controllers
{
    public class MenuController : MonoBehaviour
    {

        [SerializeField] private RectTransform gameTitle;
        [SerializeField] private RectTransform playButton;
        [SerializeField] private GameObject waxStickGamePrefab;
        [SerializeField] private GameObject hairyArmGamePrefab; 
        
        private GameObject _waxStickGameObject;
        private GameObject _hairyArmGameObject;
        
        public void MoveMenuUIToScreen()
        {
            LeanTween.moveY(gameTitle, -400, 1f).setEaseOutBounce();
            LeanTween.moveY(playButton, 600, 1f).setEaseOutBounce(); 
        }

        public void MoveMenuUIToOutScreen()
        {
            LeanTween.moveY(gameTitle, 150, 1f).setEaseOutBounce();
            LeanTween.moveY(playButton, -100, 1f).setEaseOutBounce(); 
        }

        public void CreateAndMoveGameUIToScreen()
        {
            
            CreateWaxStickGameObject();
            CreateHairyArmGameObject();
            
            LeanTween.moveLocalX(_hairyArmGameObject, 0.10f, 1f).setEaseOutBounce();
            LeanTween.moveLocalX(_waxStickGameObject, -0.02f, 1f);  
            
        }

        public void DestroyGameUI()
        {
            DestroyHairyArmGameObject();
            DestroyWaxStickGameObjectAfter(0f);
        }

        private void CreateWaxStickGameObject()
        {
            _waxStickGameObject = Instantiate(waxStickGamePrefab);
        }

        private void CreateHairyArmGameObject()
        {
            _hairyArmGameObject = Instantiate(hairyArmGamePrefab); 
        }
        
        public void DestroyWaxStickGameObjectAfter(float durationInSeconds)
        {
            if (_waxStickGameObject != null)
                Destroy(_waxStickGameObject, durationInSeconds);
        }

        private void DestroyHairyArmGameObject()
        {
            if (_hairyArmGameObject != null)
                Destroy(_hairyArmGameObject);
        } 

    }
}
