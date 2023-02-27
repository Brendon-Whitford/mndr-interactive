using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    public GameObject orb;
    float orbAmount = 10;

    // Start is called before the first frame update
    void Start()
    {
        //SpawnOrbs();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) SpawnOrbs();
    }

    void SpawnOrbs()
    {
        for (int i = 0; i < orbAmount; i++)
        {
            GameObject go = Instantiate(orb, transform.position, Quaternion.identity);
            Color color = go.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            go.GetComponent<Orbs>().trail.GetComponent<Renderer>().material.color = color;
        }
    }
}
