using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("ground");
            HPManager.Life -= 3;
            SceneManager.LoadScene("Die");
        }
    }
}
