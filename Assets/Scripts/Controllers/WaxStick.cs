using System;
using Obi;
using UnityEngine;

namespace Controllers
{
    public class WaxStick : MonoBehaviour
    {

        [SerializeField] private Camera camera;
        [SerializeField] private ObiEmitter obiEmitter;
        [SerializeField] private int emitSpeed = 2;
        [SerializeField] private ObiParticleRenderer obiParticleRenderer;

        public delegate void WaxStickAnimation();
        public static event WaxStickAnimation OnWaxStickAnimationStopped;
    
        private float   _cameraZDistance;
        private Vector3 _screenPosition;
        private Vector3 _newWorldPosition;
    
        private void Awake()
        {
            camera = camera ? camera : Camera.main;
        }

        private void Start()
        {
            _cameraZDistance  = camera.WorldToScreenPoint(transform.position).z;
            obiEmitter.speed = 0;
        }

        private void Update()
        {
            ControlWaxStick();
        }

        private void ControlWaxStick()
        {

            if (Input.touchCount <= 0) return;

            var touch = Input.GetTouch(0);
            if (touch.phase != TouchPhase.Stationary && touch.phase != TouchPhase.Moved) return;

            var mousePosX = touch.position.x;
            var mousePosY = touch.position.y;

            _screenPosition = new Vector3(mousePosX, mousePosY, _cameraZDistance);
            _newWorldPosition = camera.ScreenToWorldPoint(_screenPosition);

            transform.position = _newWorldPosition;

        }

        private void OnTriggerStay(Collider other)
        {

            if (ShouldAnimationStop())
            {
                StopAnimation();
            }

            obiEmitter.speed = 2;

        }

        private bool ShouldAnimationStop()
        {
            return obiEmitter.activeParticleCount == obiEmitter.particleCount;
        }

        private void StopAnimation()
        {
            OnWaxStickAnimationStopped?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            obiEmitter.speed = 0;
        }

        public void DisableWaxStick()
        {
            obiParticleRenderer.enabled = false;
        }

    }
    
}
