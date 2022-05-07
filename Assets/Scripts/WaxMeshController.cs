using System;
using UnityEngine;

public class WaxMeshController : MonoBehaviour
{

    [SerializeField] private MeshRenderer _meshRenderer;
    
    private void OnEnable()
    {

        WaxStickController.waxStickAnimationStopped += DryWaxMesh;

    }

    private void OnDisable()
    {
        WaxStickController.waxStickAnimationStopped -= DryWaxMesh;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void DryWaxMesh()
    {
        _meshRenderer.enabled = true;
    }

}
