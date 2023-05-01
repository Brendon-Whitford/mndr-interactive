using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public bool collected = false;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Checks for interaction between the player and card. Then once the card has been interacted with once, it is accessible from the inventory.
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "PlayerHands")
        {
            Debug.Log("Collected");
            collected = true;
        }
    }


    //Links to XR Grabbable on the Card object in scene. Destroys the card once its unselected(let go of). This does not affect the cards instanciated by the inventory.
    public void DesroyCard()
    {
        Destroy(this.gameObject);
    }
}
