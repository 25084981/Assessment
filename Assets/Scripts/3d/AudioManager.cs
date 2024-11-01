using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource StartGameMusic;
    public AudioSource GameMusic;
    public AudioSource EatDot;
    public AudioSource Count;
    public AudioSource Death;
    public AudioSource breathMusic;
    public AudioSource winMusic;

    void Start()
    {
        PlayStartGameMusic();
    }

    private void PlayStartGameMusic()
    {
        StartGameMusic.Play();
    }

    public void GamePlay()
    {
        StopBreathMusic();
        PlayGameMusic();
    }

    private void StopBreathMusic()
    {
        breathMusic.Stop();
    }

    private void PlayGameMusic()
    {
        GameMusic.Play();
    }

    public void eatDot()
    {
        EatDot.Play();
    }

    public void CountPlay()
    {
        Count.Play();
    }

    public void death()
    {
        StopGameMusic();
        Death.Play();
        Invoke("PlayBreath", 5f);
    }

    private void StopGameMusic()
    {
        GameMusic.Stop();
    }

    public void win()
    {
        StopGameMusic();
        winMusic.Play();
        Invoke("PlayBreath", 8f);
    }

    public void PlayBreath()
    {
        StopGameMusic();
        breathMusic.Play();
    }
}
