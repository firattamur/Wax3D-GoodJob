using Obi;
using GameState;
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
        public static event WaxStickAnimation OnWaxStickApplyStopped;
    
        private float _cameraZDistance;
        private bool _isWaxStickMoving;
        
        private Vector3 _screenPosition;
        private Vector3 _newWorldPosition;
        private ObiFluidRenderer _obiFluidRenderer;
        
        private void Awake()
        {
            
            camera = camera ? camera : Camera.main;
            
            // to have a fluid like simulation instead of particle we need to set obi particle renderer to obi fluid renderer
            // more detail: http://obi.virtualmethodstudio.com/manual/6.1/fluidrendering.html#:~:text=Obi%20Particle%20Renderer,tiny%20spheres%20using%20this%20technique.
            _obiFluidRenderer = camera.GetComponent<ObiFluidRenderer>();
            _obiFluidRenderer.particleRenderers[0] = obiParticleRenderer;
            
        }

        private void Start()
        {
            _cameraZDistance = camera.WorldToScreenPoint(transform.position).z;
            obiEmitter.speed = 0;
        }

        private void Update()
        {
            ControlWaxStick();
        }

        private void ControlWaxStick()
        {

            if (Input.touchCount <= 0)
            {
                _isWaxStickMoving = false;
                return;
            }

            var touch = Input.GetTouch(0);
            
            if (touch.phase != TouchPhase.Stationary && touch.phase != TouchPhase.Moved)
            {
                _isWaxStickMoving = false;
                return;
            }

            var mousePosX = touch.position.x;
            var mousePosY = touch.position.y;

            _screenPosition   = new Vector3(mousePosX, mousePosY, _cameraZDistance);
            _newWorldPosition = camera.ScreenToWorldPoint(_screenPosition);

            transform.position = _newWorldPosition;
            _isWaxStickMoving  = true;

        }

        private void OnTriggerStay(Collider other)
        {

            if (ShouldWaxApplyStop())
            {

                DisableObiEmitter();
                
                OnWaxStickApplyStopped?.Invoke();
                GameManager.Instance.SetState(new WaxRemoveState(GameManager.Instance));

                return;
                
            }

            if (_isWaxStickMoving)
                EnableObiEmitter();
            else
                DisableObiEmitter();

        }

        private void EnableObiEmitter()
        {
            obiEmitter.speed = emitSpeed;
        }

        private void DisableObiEmitter()
        {
            obiEmitter.speed = 0;
        }

        private bool ShouldWaxApplyStop()
        {
            return obiEmitter.activeParticleCount == obiEmitter.particleCount;
        }

        private void OnTriggerExit(Collider other)
        {
            DisableObiEmitter();
        }

    }
    
}
