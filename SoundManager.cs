using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static AudioClip CoinSound, GoldCoinSound;
    static AudioSource audioSrc;

    public AudioClip background_music;
    public AudioClip Score_music;
    public AudioClip Scoreup_music;

    //스코어 체크 
    public int Score = 0;

    void Start()
    {
        CoinSound = Resources.Load<AudioClip>("Coin");
        GoldCoinSound = Resources.Load<AudioClip>("GoldCoin");

        background_music = Resources.Load<AudioClip>("Stage1");
        Score_music = Resources.Load<AudioClip>("Stage2");
        Scoreup_music = Resources.Load<AudioClip>("Stage3");

        audioSrc = GetComponent<AudioSource>();

        audioSrc.clip = background_music;
        audioSrc.Play();
        audioSrc.loop = true;

    }

    private void Update()
    {
        if(ScoreManager._Score >= 5000 && ScoreManager._Score < 10000)
        {
            if (Score < 5000)
            {
                if (audioSrc.isPlaying)
                {
                    audioSrc.loop = false;
                    audioSrc.Stop();
                }
                audioSrc.clip = Score_music;
                audioSrc.Play();
                audioSrc.loop = true;

                Score = 5000;
            }
           
        }
        else if (ScoreManager._Score >= 10000)
        {
            if (Score < 10000)
            {
                if (audioSrc.isPlaying)
                {
                    audioSrc.loop = false;
                    audioSrc.Stop();
                }
                audioSrc.clip = Scoreup_music;
                audioSrc.Play();
                audioSrc.loop = true;
                Score = 10000;
            }
           
        }
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Coin":
                audioSrc.PlayOneShot(CoinSound);
                break;
            case "GoldCoin":
                audioSrc.PlayOneShot(GoldCoinSound);
                break;
        }
    }


}
