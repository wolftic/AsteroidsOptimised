using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    public void SwitchScene(string name)
    {
        Application.LoadLevel(name);
    }
}