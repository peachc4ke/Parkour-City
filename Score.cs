using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    //Rigidbody rb;
    //public float speed;
    public Text scoreText; //점수를 표시하는 Text 객체
    private int _Score = 0; //점수 관리

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        scoreText.text = " " + _Score; //텍스트 반영
    }

    /*void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);
    }*/

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);//코인 파괴

        if (other.gameObject.tag == "Gold")//금일 때
        {
            _Score += 500;
            //scoreText.text = "Score: " + _Score; //텍스트 반영
        }
        else if (other.gameObject.tag == "Silver")//은일 때
        {
            _Score += 300;
            //scoreText.text = "Score: " + _Score; //텍스트 반영
        }
        else if (other.gameObject.tag == "Bronze")
        {
            _Score += 100;
        }
        /*else if (other.gameObject.tag == "Bronze")//동일 때
        {
            Debug.Log("Tag=Bronze");
            _Score = _Score + 100;
        }*/
    }
}
