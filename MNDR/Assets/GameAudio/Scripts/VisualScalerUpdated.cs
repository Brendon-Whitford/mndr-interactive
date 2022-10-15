using UnityEngine;

public class VisualScalerUpdated : MonoBehaviour
{
    public float scale;
    public float minXScale = .25f;
    public int bin;

    void Update()
    {
        var val = VisualizeSoundManagerUpdated.Instance.bins[bin] * scale;
        transform.localScale = new Vector3(1/(val+minXScale),val, val);
    }
}

