using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowingOrbPulse : MonoBehaviour
{
    public Light targetLight; 
    public float minIntensity = 3f;
    public float maxIntensity = 7f;

    private float direction = 1;
    private float timer = 0f;
    private bool isInterpolating = false;

    void Start()
    {
        if (targetLight != null)
        {
            targetLight.intensity = minIntensity;
        }
    }

    void Update()
    {
        if (isInterpolating)
        {
            timer += (Time.deltaTime * direction);
            targetLight.intensity = timer;

            if (timer >= maxIntensity || timer <= minIntensity)
            {
                direction *= -1;
            }
            Debug.Log(timer);
        }

        // When grabbed start interpolation
        //change input to grabbing logic
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isInterpolating = true;
            timer = minIntensity;
        }
    }
}
