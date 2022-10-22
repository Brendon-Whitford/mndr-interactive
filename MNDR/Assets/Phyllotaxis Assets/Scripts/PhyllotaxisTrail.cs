using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhyllotaxisTrail : MonoBehaviour
{
    public AudioPeer _audioPeer;
    private Material _trailMat;
    public Color _trailColor;

    //public GameObject _dot;
    public float _degree, _scale;
    public int _numberStart;
    public int _stepSize;
    public int _maxIteration;
    //Lerping
    public bool _useLerping;   
    private bool _isLerping;
    private Vector3 _startPosition, _endPosition;
    private float _lerpPosTimer, _lerpPosSpeed;
    public Vector2 _lerpPosSpeedMinMax;
    public AnimationCurve _lerpPosAnimCurve;
    public int _lerpPosBand;
 

    private int _currentIteration;
    private int _number;
    private TrailRenderer _trailRenderer;
    //public float _dotScale;


    private Vector2 CalculatePhyllotaxis(float degree, float scale, int number)
    {
        //Angle: number * degree (convert degree number to radians)
        double angle = number * degree * Mathf.Deg2Rad;

        //Declare Radius
        float r = scale * Mathf.Sqrt(number);

        //Declare x and y (cartesian points)
        float x = r * (float)System.Math.Cos(angle);
        float y = r * (float)System.Math.Sin(angle);

        //x = r * cos(angle)
        //y = r * sin(angle)
        //this converts polar points (unit circle, radian stuff) to cartesian points (x, y points)


        //Return as vector2
        Vector2 vec2 = new Vector2(x, y);
        return vec2;
    }
    //The equations
    //angle: ? = n ? 137.5
    //radius: r = c ?n

    private Vector2 _phyllotaxisPosition;


    void SetLerpPositions()
    {
        _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _scale, _number);
        _startPosition = transform.localPosition;
        _endPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
    }

    private void Awake()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
        _trailMat = new Material(_trailRenderer.material);
        _trailMat.SetColor("_TintColor", _trailColor);
        _trailRenderer.material = _trailMat;

        _number = _numberStart;
        transform.localPosition = CalculatePhyllotaxis(_degree, _scale, _number);

        if (_useLerping)
        {
            SetLerpPositions();
            _isLerping = true;
        }
    }

    private void Update()
    {
        if (_useLerping)
        {
            if (_isLerping)
            {
                _lerpPosSpeed = Mathf.Lerp(_lerpPosSpeedMinMax.x, _lerpPosSpeedMinMax.y, _lerpPosAnimCurve.Evaluate(_audioPeer._audioBand64[_lerpPosBand]));
                
                //_lerpPosAnimCurve.Evalute spits out a NaN value which screws up everything. This prevents that from happening
                while (float.IsNaN(_lerpPosSpeed))
                {
                    _lerpPosSpeed = 0;
                }
                _lerpPosTimer += Time.deltaTime * _lerpPosSpeed;
                //Debug.Log(_lerpPosSpeed);
                //Debug.Log(_lerpPosAnimCurve.Evaluate(_audioPeer._audioBand[_lerpPosBand]));
                transform.localPosition = Vector3.Lerp(_startPosition, _endPosition, _lerpPosTimer); 
                if (_lerpPosTimer >= 1)
                {
                    _lerpPosTimer -= 1;
                    _number += _stepSize;
                    _currentIteration++;
                    SetLerpPositions();
                }
            }
        }
        if (!_useLerping)
        {
            _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _scale, _number);
            transform.localPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
            _number += _stepSize;
            _currentIteration++;
        }
    }

    /*private void FixedUpdate()
    {
        if (_useLerping)
        {
            if (_isLerping)
            {
                float timeSinceStarted = Time.time - _timeStartedLerping;
                float percentageComplete = timeSinceStarted / _intervalLerp;
                transform.localPosition = Vector3.Lerp(_startPosition, _endPosition, percentageComplete);
                if (percentageComplete >= 0.97f)
                {
                    transform.localPosition = _endPosition;
                    _number += _stepSize;
                    _currentIteration++;
                    if (_currentIteration <= _maxIteration)
                    {
                        SetLerpPositions();
                    }
                    else
                    {
                        _isLerping = false;
                    }
                }
            }
        }
        else
        {
            _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _scale, _number);
            transform.localPosition = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
            _number += _stepSize;
            _currentIteration++;
        }

        
    }*/

}
