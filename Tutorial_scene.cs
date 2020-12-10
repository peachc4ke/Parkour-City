using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial_scene : MonoBehaviour
{
    private bool state;
    void Start()
    {
        state = false;
    }
    public GameObject Tutorial;
    public void OnSetting()
    {
        if(state == false)
        {
            Tutorial.SetActive(true);
            state = true;
        }
        else
        {
            Tutorial.SetActive(false);
            state = false;
        }
    }
}
