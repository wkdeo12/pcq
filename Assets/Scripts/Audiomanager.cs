using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{

    public AudioClip[] audioClips;
    AudioSource audioSource;
    public AudioClip loudsound;
    public AudioClip mainTheme;
    AudioClip randomAud;
  

   
    // Use this for initialization
    void Start ()
    {
        audioSource = GetComponent<AudioSource>();
        randomAud = GetComponent<AudioClip>();
        //mainTheme = GetComponent<Audiomanager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void PlayAudio()
    {

        if (/*일반 충돌 조건 만족*/true)
        {
            audioSource.clip = audioClips[Random.Range(0, 6)];
            randomAud = audioSource.clip;
            audioSource.PlayOneShot(randomAud);
        }
        else if (/*대형 버스 충돌 조건 만족*/ true)
        {
            audioSource.PlayOneShot(loudsound);
            audioSource.play
        }

    }

    //게임 시작 버튼에 옮길 코드

    //public AudioSource mainThemePlay;

    //Audiomanager mainThemePlay = new Audiomanager();
    //mainThemePlay.audioSource.Play(mainThemePlay.mainTheme);

    



}
