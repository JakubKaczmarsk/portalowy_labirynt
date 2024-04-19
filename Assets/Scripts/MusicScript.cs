using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{
    public AudioClip[] audioClips { get; private set; }

    private AudioSource audioSorce;
    private double pauseClipTime = 0;

    [SerializeField]
    private int activeClipIndex = 0;

    private void Start()
    {
        audioSorce= GetComponent<AudioSource>();
        audioSorce.clip = audioClips[activeClipIndex];
        audioSorce.Play();
    }

    private void Update()
    {
        if(audioSorce.time >= audioClips[activeClipIndex].length)
        {
            activeClipIndex = (activeClipIndex + 1) % audioClips.Length;

            audioSorce.clip = audioClips[activeClipIndex];
            audioSorce.Play();
        }
    }
    public void PitchThis(float pitch)
    {
        audioSorce.pitch = pitch;
    }

    public void OnPauseGame()
    {
        pauseClipTime = audioSorce.time;
        audioSorce.Pause();
    }

    public void OnResumeGame()
    {
        audioSorce.PlayScheduled(pauseClipTime);
        pauseClipTime = 0;
    }
}
