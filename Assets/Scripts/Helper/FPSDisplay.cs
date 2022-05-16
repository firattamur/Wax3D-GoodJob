using TMPro;
using UnityEngine;

namespace Helper
{
    
    public class FPSDisplay : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI fpsText;

        private int _frameCount    = 0;
        private float _timePassed  = 0f;
        private const float PoolingTime = 1f;

        private void Update()
        {

            _timePassed += Time.deltaTime;
            _frameCount += 1;

            if (!(_timePassed > PoolingTime)) return;
            
            var fbs = Mathf.RoundToInt(_frameCount / _timePassed);
            fpsText.text = _frameCount.ToString() + " FPS";

            _timePassed -= PoolingTime;
            _frameCount = 0;

        }
    }
    
}


