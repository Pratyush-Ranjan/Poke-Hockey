using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioClip PuckCollision;
    public AudioClip Goal;
    public AudioClip LostGame;
    public AudioClip WonGame;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuckCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoal()
    {
        audioSource.PlayOneShot(Goal);
    }
    public void PlayLostGame()
    {
        StartCoroutine(playsoundwithdelay());
    }

    public void PlayWonGame()
    {
        StartCoroutine(playsoundwithdelayw());
    }
    private IEnumerator playsoundwithdelay()
{
     yield return new WaitForSecondsRealtime(3);
    audioSource.PlayOneShot(LostGame);
}
    private IEnumerator playsoundwithdelayw()
    {
        yield return new WaitForSecondsRealtime(3);
        audioSource.PlayOneShot(WonGame);
    }
}
