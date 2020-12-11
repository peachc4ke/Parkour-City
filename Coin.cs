using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Gold")//금일 때
            {
                SoundManager.PlaySound("GoldCoin");
                ScoreManager._Score += 500;
            }
            else if (gameObject.tag == "Silver")//은일 때
            {
                SoundManager.PlaySound("Coin");
                ScoreManager._Score += 300;
            }
            else if (gameObject.tag == "Bronze")
            {
                SoundManager.PlaySound("Coin");
                ScoreManager._Score += 100;
            }

            Destroy(gameObject);
        }
    }

}