using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This script should be attached to an object with a box collider with Is Trigger enabled.
// It loads a new scene when the player hits the box.
// Tag the player's collider with "Player" for this to work.

public class LoadScene : MonoBehaviour
{
    public string SceneNamed;

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>();
        // Tag your player with Player
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneNamed);
            // when the barrier loads the next scene the player's cordinates do not reset to (0,0,0). They retain their position
        }
    }
}
