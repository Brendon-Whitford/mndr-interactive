using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// setting the gameObject scroller to ture or false based on whether or not it is active in the Hierarchy

public class togglescroller : MonoBehaviour
{
    public GameObject scroller;
   
    public void toggleScroller()
    {
        if(scroller.activeInHierarchy == false)
        {
            scroller.SetActive(true);

        }
        else if(scroller.activeInHierarchy == true)
        {
            scroller.SetActive(false);
        }
    }
   
}
