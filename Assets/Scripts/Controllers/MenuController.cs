using UnityEngine;

namespace Controllers
{
    public class MenuController : MonoBehaviour
    {

        [SerializeField] private GameObject waxStickGamePrefab;
        [SerializeField] private GameObject hairyArmGamePrefab; 

        private GameObject _waxStickGameObject;
        private GameObject _hairyArmGameObject;

        public RectTransform gameTitle;
        public RectTransform playButton;

        public void DisplayMenuUI()
        {
            LeanTween.moveY(gameTitle, 400, 1f).setEaseOutBounce();
            LeanTween.moveY(playButton, -200, 1f).setEaseOutBounce(); 
        }

        public void UnDisplayMenuUI()
        {
            LeanTween.moveY(gameTitle, 1400, 1f).setEaseOutBounce();
            LeanTween.moveY(playButton, -1400, 1f).setEaseOutBounce(); 
        }

        public void DisplayGameUI()
        {
            
            CreateWaxStickGameObject();
            CreateHairyArmGameObject();
            
            LeanTween.moveLocalX(_hairyArmGameObject, 0.10f, 1f).setEaseOutBounce();
            LeanTween.moveLocalX(_waxStickGameObject, -0.02f, 1f);  
            
        }

        public void UnDisplayGameUI()
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
