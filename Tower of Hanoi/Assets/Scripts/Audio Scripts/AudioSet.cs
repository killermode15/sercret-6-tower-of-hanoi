using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioData
{
    public string Identifier => identifier;
    public bool UseSnapshot => useSnapshot;
    public float Volume => volume;
    public AudioClip Clip => audioClip;
    public AudioMixerSnapshot MixerSnapshot => mixerSnapshot;

	[SerializeField] private string identifier = string.Empty;
	[SerializeField] private bool useSnapshot = false;
	[SerializeField] private AudioClip audioClip = null;
	[SerializeField] private AudioMixerSnapshot mixerSnapshot;

    [SerializeField, Range(0, 1)] private float volume = 0.75f;

	public AudioSource PlayAudio (bool play = true, bool destroyAfter = false, bool randomPitch = false)
	{
		if (!useSnapshot)
		{
			AudioSource source = new GameObject ("Source [" + identifier + "]").AddComponent<AudioSource> ();
			source.clip = audioClip;
			if (play)
			{
				source.Play ();
                source.volume = volume;
                if(randomPitch)
                {
                    float startingPitch = source.pitch;
                    source.pitch = Random.Range(startingPitch - 0.01f, startingPitch + 0.01f);
                }
			}
			if (destroyAfter)
			{
				GameObject.Destroy (source.gameObject, source.clip.length);
			}
			return source;
		}
		else
		{
			Debug.LogWarning ("Using PlayAudio() while Use Snapshot is true");
			return null;
		}
	}

	public void PlaySnapshot (float timeToReach)
	{
		if (useSnapshot)
		{
			mixerSnapshot.TransitionTo (timeToReach);
		}
		else
		{
			Debug.LogWarning("Using PlaySnapshot() while Use Snapshot is false");
		}
	}
}

[CreateAssetMenu (fileName = "Audio Manager")]
public class AudioSet : ScriptableObject
{
	public List<AudioData> AudioData;

	public AudioData GetAudio (string identifier)
	{
		return AudioData.Find (x => x.Identifier.ToLower () == identifier.ToLower ());
	}
}