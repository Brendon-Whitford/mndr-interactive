using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetObjects : MonoBehaviour
{
    public GameObject hoverUi;

    private void Start()
    {
        hoverUi.SetActive(false);
    }

    public void SetActive()
    {
        hoverUi.SetActive(true);
    }

    public void SetInactive()
    {
        hoverUi.SetActive(false);
    }
}
