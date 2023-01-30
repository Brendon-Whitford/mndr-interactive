using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dogeReveal : MonoBehaviour
{
    public Transform target;
    public bool triggered;
    public float t;
    [SerializeField]
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (triggered)
        {
            t += Time.deltaTime* speed;
            transform.position = Vector3.Lerp(transform.position, target.transform.position, t);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            triggered = true;
        }   
    }
}
