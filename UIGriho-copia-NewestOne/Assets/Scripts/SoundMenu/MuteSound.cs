using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class MuteSound: MonoBehaviour
{
    public AudioSource audioSource;
    public AudioMixer audioMixer;
    public VideoPlayer videoPlayer;
    public void MuteVolume()
    {
        audioSource.mute = true;
        audioMixer.SetFloat("volume", -80);

    }

    public void UnMuteVolume()
    {
        audioMixer.SetFloat("volume", 0);
        audioSource.mute = false;
    }

    public void MuteVideoVolume()
    {
        videoPlayer.SetDirectAudioMute(0, true);
    }

    public void UnMuteVideoVolume()
    {
        videoPlayer.SetDirectAudioMute(0, false);

    }
}
