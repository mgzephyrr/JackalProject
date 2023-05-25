using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            Application.OpenURL("userguide\\main_menu.htm");
        }
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed!");
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenCertificate()
    {
        Application.OpenURL("users_guide.chm");
    }
}
