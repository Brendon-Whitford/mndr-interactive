using UnityEngine;

public class VisualScaler : MonoBehaviour
{
    public float scale;
    public int bin;

   // m_Renderer = GetComponent<Renderer>();


    void Update()
    {
        var val = VisualizeSoundManager.Instance.bins[bin] * scale;
        var finalVal = val / 7f;
        transform.localScale = new Vector3(finalVal ,finalVal, finalVal);
    }
}

