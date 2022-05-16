using UnityEngine;

// Copy meshes from children into the parent's Mesh.
// CombineInstance stores the list of meshes.  These are combined
// and assigned to the attached Mesh.

namespace Helper
{
    
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class MeshCombiner : MonoBehaviour
    {
        
        public void CombineMeshes()
        {
            
            var meshFilters = GetComponentsInChildren<MeshFilter>();
            var combine = new CombineInstance[meshFilters.Length];

            var combinedMesh = new Mesh(); 

            for (var i = 0; i < meshFilters.Length; i++)
            {
                
                combine[i].mesh       = meshFilters[i].mesh;
                combine[i].transform  = meshFilters[i].transform.localToWorldMatrix; 
                
                meshFilters[i].gameObject.SetActive(false);
                
            }
            
            combinedMesh.CombineMeshes(combine);
            GetComponent<MeshFilter>().mesh = combinedMesh;

            transform.gameObject.SetActive(true);
            
        }
        
        
        
    }
    
}
