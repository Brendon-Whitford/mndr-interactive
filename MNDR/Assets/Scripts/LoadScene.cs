using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneNamed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<Collider>();
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneNamed);
            // when the barrier loads the next scene the player's cordinates do not reset to (0,0,0)
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
