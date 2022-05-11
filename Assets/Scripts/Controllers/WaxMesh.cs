using System;
using GameState;
using UnityEngine;

namespace Controllers
{
    public class WaxMesh : MonoBehaviour
    {
    
        [SerializeField] private GameObject hairs;
        [SerializeField] private MegaBend megaBend;
        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private float megaBendMaxAngle = 60f;
        [SerializeField] private float megaBendUpdateAngleValue = 2f;
        
        private void OnEnable()
        {
            WaxStick.OnWaxStickApplyStopped += DryWaxMesh;
        }
        
        private void Update()
        {
            ControlWaxMesh(); 
        }

        private void FixedUpdate()
        {
            
            if (megaBend.angle == 0)
                return;

            if (LeanTween.isPaused())
                megaBend.angle += megaBendUpdateAngleValue; 

            if (megaBend.angle > megaBendMaxAngle)
                MoveWaxMeshOutOfScreen();

        }

        private void MoveWaxMeshOutOfScreen()
        {
            LeanTween.moveLocalY(gameObject, -10, 1f).setOnComplete(GameStateChangedToMenu);
        }

        private void GameStateChangedToMenu()
        {
            GameManager.Instance.SetState(new MenuState(GameManager.Instance));
        }
        
        private void ControlWaxMesh()
        {

            if (Input.touchCount <= 0)
            {
                
                // if not touch on screen resume wax remove guide animation for player
                if (LeanTween.isPaused())
                    LeanTween.resume(gameObject);
                
                return;
                
            }
            
            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Stationary && touch.phase != TouchPhase.Moved) return;
    
            if (!LeanTween.isPaused())
                LeanTween.pause(gameObject);
            
        }

        private void DryWaxMesh()
        {
            // increase alpha value of mesh renderer material for dry animation effect
            LeanTween.alpha(meshRenderer.gameObject, 1.0f, 2f).setOnComplete(OnWaxMeshDried);
        }

        private void OnWaxMeshDried()
        {

            hairs.SetActive(false);
            // simple animation loop to guide player for removing wax
            LeanTween.value(gameObject, UpdateMegaBendAngleValue, 0f, 10f, 2f).setLoopPingPong();
            
        }
        
        void UpdateMegaBendAngleValue( float val )
        {
            megaBend.angle = val;
        }
        
        private void OnDisable()
        {
            WaxStick.OnWaxStickApplyStopped -= DryWaxMesh;
        }

    }
}
