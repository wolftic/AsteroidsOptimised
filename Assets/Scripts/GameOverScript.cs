using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour {

	private GameObject player;
	private bool playerdying = false;
	private PlayerHealth playerHealth;
	[SerializeField]
	private Text gameOverText;
	[SerializeField]
	private Canvas gameOverCanvas;


	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");

		playerHealth = player.GetComponent <PlayerHealth> ();
		gameOverText.canvasRenderer.SetAlpha (0);
		gameOverCanvas.enabled = false;

	}

	void Update(){
		if (playerHealth.Health <= 0 && !playerdying) {
			playerdying = true;
			GameOverFadeIn ();
		}
	}

	private void GameOverFadeIn(){
		gameOverText.CrossFadeAlpha(1f, 3f, false);
		Invoke ("ShowButtons", 3.2f);
	}

	private void ShowButtons(){
		gameOverCanvas.enabled = true;
	}

	public void RestartGame(string scene){
		SceneManager.LoadScene (scene);
	}

	public void ExitGame(){
		SceneManager.LoadScene ("MainMenu");
	}
}