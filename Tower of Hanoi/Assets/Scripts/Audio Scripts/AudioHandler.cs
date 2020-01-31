using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private AudioSet audioManager;

    [Header("BGM Properties")]
    [Space(10)]
    [SerializeField, Range(0, 1)] private float volume;

    private AudioSource bgmSource;

    // Start is called before the first frame update
    void Start()
    {
        bgmSource = audioManager.GetAudio("BGM").PlayAudio();
        bgmSource.transform.parent = transform;
        bgmSource.loop = true;
        UpdateBGMVolume();
    }

    public void UpdateBGMVolume()
    {
        bgmSource.volume = volume;
    }

    public void PlaySFX(string identifier)
    {
        AudioSource sfxSource = audioManager.GetAudio(identifier).PlayAudio(destroyAfter: true, randomPitch: true);
        if(!sfxSource)
        {
            Debug.LogWarning("Could not find the sound effect [" + identifier + "]");
            return;
        }
        sfxSource.transform.parent = transform;
    }
}
