using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
