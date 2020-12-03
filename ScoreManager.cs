using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log(" ");
            Destroy(this);
            return;
        }

        instance = this;
    }

    public Text scoreText; //점수를 표시하는 Text 객체
    public int _Score = 0; //점수 관리

    void Update()
    {
        scoreText.text = " " + _Score; //텍스트 반영
    }
}
