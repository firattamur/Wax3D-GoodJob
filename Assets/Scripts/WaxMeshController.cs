using System;
using GameState;
using UnityEngine;
using UnityEngine.Serialization;

public class WaxMeshController : MonoBehaviour
{

    [SerializeField] private MeshRenderer meshRenderer;
    
    private void OnEnable()
    {

        WaxStickController.OnWaxStickAnimationStopped += DryWaxMesh;

    }

    private void OnDisable()
    {
        WaxStickController.OnWaxStickAnimationStopped -= DryWaxMesh;
    }

    void Start()
    {
         
    }

    void Update()
    {
        
    }

    private void DryWaxMesh()
    {
        LeanTween.alpha(meshRenderer.gameObject, 1.0f, 2f).setOnComplete(OnWaxMeshDry);
    }

    private void OnWaxMeshDry()
    {
        GameManager.instance.SetState(new WaxRemoveState(GameManager.instance));
    }

}
