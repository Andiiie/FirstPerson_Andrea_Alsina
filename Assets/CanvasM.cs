using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasM : MonoBehaviour
{
    // Start is called before the first frame update
    public void Play()
    {
        SceneManager.LoadScene(2);
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Tutorial()
    {
        SceneManager.LoadScene(1);
    }
}
