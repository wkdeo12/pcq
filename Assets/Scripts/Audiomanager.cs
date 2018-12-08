using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    public AudioClip loudsound;
    public AudioClip mainTheme;
    private AudioClip randomAud;
    public static Audiomanager audiosingle;

    private void Awake()
    {
        audiosingle = this;
    }

    // Use this for initialization
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        randomAud = GetComponent<AudioClip>();
        //mainTheme = GetComponent<Audiomanager>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    public void PlayAudio(int q)
    {
        if (q == 1)
        {
            audioSource.clip = audioClips[Random.Range(0, 6)];
            randomAud = audioSource.clip;
            audioSource.PlayOneShot(randomAud);
        }
        else if (q == 2)
        {
            audioSource.PlayOneShot(loudsound);
            audioSource.Play();
        }
    }

    //게임 시작 버튼에 옮길 코드

    //public AudioSource mainThemePlay;

    //Audiomanager mainThemePlay = new Audiomanager();
    //mainThemePlay.audioSource.Play(mainThemePlay.mainTheme);
}