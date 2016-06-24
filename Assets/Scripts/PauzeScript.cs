using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauzeScript : MonoBehaviour {

	private InputHandler inputHandler;
	private float newTimeScale = 1;
	private float oldTimeScale = 1;
	private float percentage = 0;

	[SerializeField]
	private Canvas pauseMenu;
	[SerializeField]
	private Canvas optionsMenu;
	[SerializeField]
	private Canvas buttonsMenu;

	private bool pause;

	void Awake(){
		inputHandler = GameObject.FindObjectOfType <InputHandler> ();
		pauseMenu.gameObject.SetActive (false);
	}

	void Update()
	{
		if(Input.GetKeyDown (inputHandler.inputs["pauzeKnop"]) && Time.timeScale == 1)
		{
			Time.timeScale = 0;

			pause = true;
			ShowPause (pause);
		} else if(Input.GetKeyDown (inputHandler.inputs["pauzeKnop"]) && Time.timeScale == 0){
			Time.timeScale = 1;

			pause = false;
			ShowPause (pause);
		}
		Debug.Log (Time.timeScale);
	}

	public void Switch(bool pause) {
		optionsMenu.gameObject.SetActive (pause);
		buttonsMenu.gameObject.SetActive (!pause);
	}

	public void ShowPause(bool show) {
		optionsMenu.gameObject.SetActive (false);
		buttonsMenu.gameObject.SetActive (true);
		pauseMenu.gameObject.SetActive(show);
	}

	public void SetVolumeSFX(Transform slider) {
		float volume = slider.GetComponent<Slider> ().value;
		SoundManager.current.SFXvolume = volume;
	}

	public void SetVolumeBGM(Transform slider) {
		float volume = slider.GetComponent<Slider> ().value;
		SoundManager.current.BGMvolume = volume;
	}
}