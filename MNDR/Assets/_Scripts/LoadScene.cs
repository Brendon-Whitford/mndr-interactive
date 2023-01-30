// The player's parent object needs to be tagged with "Player" for this script to trigger correctly.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneNamed;
    public bool additiveScene;
    public bool retainPlayerPosition;
    public float playerPosX;
    public float playerPosY;
    public float playerPosZ;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (additiveScene) SceneManager.LoadScene(SceneNamed, LoadSceneMode.Additive);
            if (!additiveScene) SceneManager.LoadScene(SceneNamed, LoadSceneMode.Single);

            if (!retainPlayerPosition) other.transform.position = new Vector3(playerPosX, playerPosY, playerPosZ);

            Debug.Log("loading scene " + SceneNamed);
        }
    }
}
