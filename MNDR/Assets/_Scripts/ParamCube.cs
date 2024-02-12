using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// transforming the local scale of the gameObject this is attached too
//it is based one whether or not the bool _useBuffer is false or true

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeerC._bandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
        if (!_useBuffer)
        {
            transform.localScale = new Vector3(transform.localScale.x, (AudioPeerC._freqBand[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
        }
    }
}
