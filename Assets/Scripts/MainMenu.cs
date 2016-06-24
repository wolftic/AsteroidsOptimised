using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	[SerializeField]private Canvas startMenu;
	[SerializeField]private Canvas optionMenu;
	[SerializeField]private Canvas tutorialMenu;
	[SerializeField]private Canvas creditsMenu;
	[SerializeField]private Canvas planetMenu;
	[SerializeField]private Canvas shopMenu;
	[SerializeField]private Canvas buyMenu;
	[SerializeField]private Canvas sellMenu;
	[SerializeField]private Canvas controlMenu; 

	void Awake()
	{
		startMenu = startMenu.GetComponent <Canvas>();
		optionMenu = optionMenu.GetComponent <Canvas>();
		tutorialMenu = tutorialMenu.GetComponent <Canvas> ();
		creditsMenu = creditsMenu.GetComponent <Canvas> ();
		planetMenu = planetMenu.GetComponent <Canvas> ();
		shopMenu = shopMenu.GetComponent <Canvas> ();
		controlMenu = controlMenu.GetComponent <Canvas> ();

		startMenu.enabled = true;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
		controlMenu.enabled = false;
	}

	public void TutorialScherm()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = true;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
		controlMenu.enabled = false;
	}

	public void NewGame(string scene)
	{
		SceneManager.LoadScene (scene);
	}
	public void OptionMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = true;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
		controlMenu.enabled = false;
	}

	public void ExitOptions()
	{
		startMenu.enabled = true;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
		controlMenu.enabled = false;
	}

	public void CreditMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = true;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
		controlMenu.enabled = false;
	}

	public void PlanetSelection()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = true;
		shopMenu.enabled = false;
		controlMenu.enabled = false;
	}

	public void ShopMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = true;
		controlMenu.enabled = false;
	}

	public void ControlMenu()
	{
		startMenu.enabled = false;
		optionMenu.enabled = false;
		tutorialMenu.enabled = false;
		creditsMenu.enabled = false;
		planetMenu.enabled = false;
		shopMenu.enabled = false;
		controlMenu.enabled = true;
	}
}
