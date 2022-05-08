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
        [SerializeField] private float megaBendUpdateAngle = 2f;
        [SerializeField] private float megaBendMaxAngle = 60f;
            
        private float _megaBendAngleIncrease;
        
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
                megaBend.angle += _megaBendAngleIncrease;

            if (megaBend.angle > megaBendMaxAngle)
                MoveWaxOutOfScreen();

        }

        private void MoveWaxOutOfScreen()
        {
            LeanTween.moveLocalY(gameObject, -10, 1f);
        }

        private void TouchDrag()
        {

            if (Input.touchCount <= 0)
            {
                
                _megaBendAngleIncrease = -megaBendUpdateAngle;
                
                if (LeanTween.isPaused())
                    LeanTween.resume(gameObject);
                
                return;
                
            }
            
            if (!LeanTween.isPaused())
                LeanTween.pause(gameObject);
            
            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Stationary && touch.phase != TouchPhase.Moved) return;

            _megaBendAngleIncrease = megaBendUpdateAngle;

        }

        private void DryWaxMesh()
        {
            LeanTween.alpha(meshRenderer.gameObject, 1.0f, 2f).setOnComplete(OnWaxMeshDry);
        }

        private void OnWaxMeshDry()
        {
            
            hairs.SetActive(false);
            LeanTween.value(gameObject, UpdateBendAngleValue, 0f, 15f, 3f).setLoopPingPong();
            
            GameManager.instance.SetState(new WaxRemoveState(GameManager.instance));
            
        }
        
        void UpdateBendAngleValue( float val )
        {
            megaBend.angle = val;
        }

    }
}
