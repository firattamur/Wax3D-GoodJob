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
            LeanTween.moveY(gameTitle, 400, 1f).setEaseOutBounce();
            LeanTween.moveY(playButton, -200, 1f).setEaseOutBounce(); 
        }

        public void MoveMenuUIToOutScreen()
        {
            LeanTween.moveY(gameTitle, 1400, 1f).setEaseOutBounce();
            LeanTween.moveY(playButton, -1400, 1f).setEaseOutBounce(); 
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
            DestroyWaxStickGameObject();
        }

        private void CreateWaxStickGameObject()
        {
            _waxStickGameObject = Instantiate(waxStickGamePrefab);
        }

        private void CreateHairyArmGameObject()
        {
            _hairyArmGameObject = Instantiate(hairyArmGamePrefab); 
        }
        
        public void DestroyWaxStickGameObject()
        {
            if (_waxStickGameObject != null)
                Destroy(_waxStickGameObject);
        }

        private void DestroyHairyArmGameObject()
        {
            if (_hairyArmGameObject != null)
                Destroy(_hairyArmGameObject);
        } 

    }
}
