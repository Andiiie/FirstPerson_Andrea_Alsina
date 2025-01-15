using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasM : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(2);
        Debug.Log("ju");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Exit()
    {
        Application.Quit();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(1);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
