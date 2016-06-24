using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
	public int levelUnlocked = 0;
	private GameObject[] planets = new GameObject[4];

	void OnEnable () {
		planets[0] = GameObject.FindGameObjectWithTag ("Planet1");
		planets[1] = GameObject.FindGameObjectWithTag ("Planet2");
		planets[2] = GameObject.FindGameObjectWithTag ("Planet3");
		planets[3] = GameObject.FindGameObjectWithTag ("Planet4");

		levelUnlocked = PlayerPrefs.GetInt ("unlocked");
	} 

	void Update () {
		for (int i = 0; i < planets.Length; i++) {
			planets [i].transform.GetChild (0).gameObject.SetActive ( (i > levelUnlocked) );
			planets [i].GetComponent<Button> ().interactable = !(i > levelUnlocked);
		}
	}
}
