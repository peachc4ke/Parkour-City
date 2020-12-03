/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; //점수를 표시하는 Text 객체
    private int _Score = 0; //점수 관리

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        scoreText.text = " " + _Score; //텍스트 반영
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);//코인 파괴

        if (other.gameObject.tag == "Gold")//금일 때
        {
            _Score += 500;
        }
        else if (other.gameObject.tag == "Silver")//은일 때
        {
            _Score += 300;
        }
        else if (other.gameObject.tag == "Bronze")
        {
            _Score += 100;
        }
    }
}*/