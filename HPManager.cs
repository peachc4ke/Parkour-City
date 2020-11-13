using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HPManager : MonoBehaviour
{
    public static int Life = 3;

    public GameObject Life1;
    public GameObject Life2;
    public GameObject Life3;

    bool isDie = false;

    void Start()
    {
        Life1.GetComponent<RawImage>().enabled = true;
        Life2.GetComponent<RawImage>().enabled = true;
        Life3.GetComponent<RawImage>().enabled = true;
    }

    void Update()
    {
        switch(Life)
        {
            case 2:
                Life3.GetComponent<RawImage>().enabled = false;
                break;
            case 1:
                Life2.GetComponent<RawImage>().enabled = false;
                break;
            case 0:
                Life1.GetComponent<RawImage>().enabled = false;
                break;
        }

        if(Life == 0)
        {
            if (!isDie)
                Die();

            return; 
        }

    }

    void Die()
    {
        isDie = true;
        SceneManager.LoadScene("DIE");
    }


}
