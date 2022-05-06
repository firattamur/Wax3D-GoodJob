using System;
using UnityEngine;

public class WaxStickController : MonoBehaviour
{

    [SerializeField] private Camera camera;

    private float _cameraZDistance;
    private Vector3 _screenPosition;
    private Vector3 _newWorldPosition;
    
    private void Awake()
    {
        camera = camera ? camera : Camera.main;
    }

    private void Start()
    {
        _cameraZDistance = camera.WorldToScreenPoint(transform.position).z;
    }

    private void Update()
    {
        
    }

    private void OnMouseDrag()
    {

        Debug.Log("Mouse dragging");
        
        float mousePosX = Input.mousePosition.x;
        float mousePosY = Input.mousePosition.y;
        float mousePosZ = Input.mousePosition.z;
        
        _screenPosition   = new Vector3(mousePosX, mousePosY, _cameraZDistance);
        _newWorldPosition = camera.ScreenToWorldPoint(_screenPosition);

        transform.position = _newWorldPosition;

    }
}
