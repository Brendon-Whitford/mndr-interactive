using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.GameAudio.Scripts
{
    public class LightControllerUpdated : Singleton<LightControllerUpdated>
    {
        public float maxIntensity;
        public Color minColor;
        public Color maxColor;    
        private Light[] lights;
        private float minV;
        private float maxV;             

        void Start()
        {
           lights = GetComponentsInChildren<Light>();
            minV = float.MaxValue;
            maxV = float.MinValue;        
        }

        void Update()
        {
            for(int i=0; i< VisualizeSoundManagerUpdated.Instance.binNo; i++)
            {
                var val = VisualizeSoundManagerUpdated.Instance.bins1[i];
                maxV = Mathf.Max(maxV, val);
                minV = Mathf.Min(minV, val);
                val = Normalize(val, minV, maxV);
                lights[i].color = Color.LerpUnclamped(minColor, maxColor, val);
                lights[i].intensity = val * maxIntensity;                
            }
        }

        private float Normalize(float val, float min, float max)
        {
            return (val - min) / max;
        }

        
    }
}
