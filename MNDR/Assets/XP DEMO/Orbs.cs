using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbs : MonoBehaviour
{

    private Transform player;
    public GameObject trail;

    private Vector3 movement;

    private float speed = 1;
    private float acceleration = 10;
    private float turnSpeed = 1f;
    private float xp = 10;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        movement = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        movement = movement.normalized * Random.Range(3f, 5f);

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 delta = player.position - transform.position;
        Vector3 direction = delta.normalized;

        //movement = direction * speed;
        movement = Vector3.Lerp(movement, direction * speed, turnSpeed * Time.deltaTime);
        transform.position += movement * Time.deltaTime;

        while (speed <= acceleration)
        {
            speed += acceleration * Time.deltaTime;
        }

        if (Vector3.Distance(player.transform.position, transform.position) < .5f) GiveXP();
    }

    void GiveXP()
    {
        Debug.Log("The player has received: " + xp.ToString() + " xp");
        Destroy(gameObject);
    }
}
