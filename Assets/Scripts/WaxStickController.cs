using System;
using Obi;
using UnityEngine;

public class WaxStickController : MonoBehaviour
{

    [SerializeField] private Camera camera;
    [SerializeField] private ObiEmitter _obiEmitter;
    [SerializeField] private int _emitSpeed = 2;
    [SerializeField] private ObiParticleRenderer _obiParticleRenderer;

    public delegate void WaxStickAnimation();
    public static event WaxStickAnimation waxStickAnimationStopped;
    
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
        _obiEmitter.speed = 0;
    }

    private void Update()
    {
         
    }

    private void OnMouseDrag()
    {

        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        float mousePosZ = Input.mousePosition.z;
        
        _screenPosition   = new Vector3(mousePosX, mousePosY, _cameraZDistance);
        _newWorldPosition = camera.ScreenToWorldPoint(_screenPosition);

        transform.position = _newWorldPosition;

    }
    
    private void OnTriggerStay(Collider other)
    {

        if (_obiEmitter.activeParticleCount == _obiEmitter.particleCount)
        {
            _obiParticleRenderer.enabled = false;
            waxStickAnimationStopped.Invoke();
        }
        
        _obiEmitter.speed = 2;

    }

    private void OnTriggerExit(Collider other)
    {
        _obiEmitter.speed = 0;
    }

}
