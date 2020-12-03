using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSetting : MonoBehaviour
{
    private bool state;
    void Start()
    {
        state = false;
    }
    public GameObject Sound;
    public void OnSetting()
    {
        if(state == false)
        {
            Sound.SetActive(true);
            state = true;
        }
        else
        {
            Sound.SetActive(false);
            state = false;
        }
    }
}
