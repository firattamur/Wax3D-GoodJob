using System;
using GameState;
using UnityEngine;

namespace Controllers
{
    public class WaxMesh : MonoBehaviour
    {

        [SerializeField] private MeshRenderer meshRenderer;
        [SerializeField] private MegaBend megaBend;
        [SerializeField] private GameObject hairs;
        [SerializeField] private float megaBendUpdateAngleValue = 2f;
        [SerializeField] private float megaBendMaxAngle = 60f;
            
        private void OnEnable()
        {

            WaxStick.OnWaxStickAnimationStopped += DryWaxMesh;

        }

        private void OnDisable()
        {
            WaxStick.OnWaxStickAnimationStopped -= DryWaxMesh;
        }

        private void Update()
        {
            TouchDrag(); 
        }

        private void FixedUpdate()
        {
            
            if (megaBend.angle == 0)
                return;

            if (LeanTween.isPaused())
                megaBend.angle += megaBendUpdateAngleValue; 

            if (megaBend.angle > megaBendMaxAngle)
                MoveWaxOutOfScreen();

        }

        private void MoveWaxOutOfScreen()
        {
            LeanTween.moveLocalY(gameObject, -10, 1f).setOnComplete(ChangeStateToMenu);
        }

        private void ChangeStateToMenu()
        {
            GameManager.Instance.SetState(new MenuState(GameManager.Instance));
        }
        
        private void TouchDrag()
        {

            if (Input.touchCount <= 0)
            {
                
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
            LeanTween.alpha(meshRenderer.gameObject, 1.0f, 2f).setOnComplete(OnWaxMeshDried);
        }

        private void OnWaxMeshDried()
        {
            
            hairs.SetActive(false);
            
            // simple animation loop to guide player to remove wax
            LeanTween.value(gameObject, UpdateMegaBendAngleValue, 0f, 10f, 2f).setLoopPingPong();
            
            GameManager.Instance.SetState(new WaxRemoveState(GameManager.Instance));
            
        }
        
        void UpdateMegaBendAngleValue( float val )
        {
            megaBend.angle = val;
        }

    }
}
