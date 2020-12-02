using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReMenu : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}