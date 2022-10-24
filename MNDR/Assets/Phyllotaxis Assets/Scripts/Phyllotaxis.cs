using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phyllotaxis : MonoBehaviour
{

    public GameObject _dot;
    public float _degree, _c;
    public int _n;
    public float _dotScale;


    private Vector2 CalculatePhyllotaxis(float degree, float scale, int count)
    {
        //Angle: number * degree (convert degree number to radians)
        double angle = count * degree * Mathf.Deg2Rad;

        //Declare Radius
        float r = scale * Mathf.Sqrt(count);

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

    private void Update()
    {
        //Space bar held = new positions
        if (Input.GetKey(KeyCode.Space))
        {
            _phyllotaxisPosition = CalculatePhyllotaxis(_degree, _c, _n);
            GameObject dotInstance = (GameObject)Instantiate(_dot);
            dotInstance.transform.position = new Vector3(_phyllotaxisPosition.x, _phyllotaxisPosition.y, 0);
            dotInstance.transform.localScale = new Vector3(_dotScale, _dotScale, _dotScale);
            _n++;
        }
    }

}
