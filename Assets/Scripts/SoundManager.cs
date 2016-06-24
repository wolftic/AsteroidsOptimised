using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SoundManager : MonoBehaviour {
	public static SoundManager current;
	public float BGMvolume;
	public float SFXvolume;
	private AudioSource source;
	[SerializeField]
	private AudioClip background;
	[SerializeField]
	private AudioSource backgroundSource;

	[SerializeField]
	private AudioClip[] sounds;

	void Start () {
		if (current != null) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (this);
		current = this;
		source = GetComponent<AudioSource> ();
		backgroundSource.PlayOneShot (background, BGMvolume);
	}

	void Update () {
		backgroundSource.volume = BGMvolume;
	}

	[ContextMenu("DEBUG")]
	void DEBUG() {
		PlaySound ("Klikwav");
	}

	public void PlaySound(string sound) {
		source.PlayOneShot (GetSound (sound), SFXvolume);
	}

	public void SetVolumeSFX(Transform slider) {
		float volume = slider.GetComponent<Slider> ().value;
		SFXvolume = volume;
	}

	public void SetVolumeBGM(Transform slider) {
		float volume = slider.GetComponent<Slider> ().value;
		BGMvolume = volume;
	}

	public void SetVolumeSFX(float volume) {
		SFXvolume = volume;
	}

	public void SetVolumeBGM(float volume) {
		BGMvolume = volume;
	}

	/*public void PlaySound(string sound, float volume) {
		source.PlayOneShot (GetSound(sound), volume);
	}*/

	private AudioClip GetSound(string name) {
		foreach (AudioClip audio in sounds) {
			if (audio.name == name) {
				return audio;
			}
		}

		return null;
	}
}
