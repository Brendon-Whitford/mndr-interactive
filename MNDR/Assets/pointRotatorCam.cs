using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
[ExecuteInEditMode]
public class pointRotatorCam : MonoBehaviour
{
    public Camera cam;

    public float rotateSpeed=0;
    public float offsetx, offsety;

    public GameObject[] Lights;
    float rotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        cam.transform.RotateAround(transform.position, cam.transform.up, rotateSpeed);
        cam.transform.LookAt(transform.position, Vector3.up);
        //cam.transform.localPosition = new Vector3(offsetx, offsety, 0f);

        
        //transform.Rotate(0f, rotateSpeed, 0f);
        foreach (var item in Lights)
        {
            item.transform.LookAt(transform.position, Vector3.up);
        }

        
    }
}
