using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SkyManager : MonoBehaviour
{

    public Material skyOne;
    public Material skyTwo;
    public Material skyThree;

    public float RotateSpeed = 0.8f;

    void Start()
    {
        RenderSettings.skybox = skyOne;
        //GameObject.Find("Player").GetComponent<ScoreManager>().Score();
        //player라는 게임 오브젝트에 playerScript라는 Component에서 Score이라는 함수 호출
    }

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotateSpeed);

        if(ScoreManager.instance._Score >= 10000 && ScoreManager.instance._Score < 20000)
        {
            RenderSettings.skybox = skyTwo;
        }
        else if(ScoreManager.instance._Score >= 20000)
        {
            RenderSettings.skybox = skyThree;
        }
    }
}
