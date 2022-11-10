using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneCtrl : MonoBehaviour
{

    private void Awake()
    {
        Screen.SetResolution(1280, 720, false);
    }
    public void clickPlay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void clickMain()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void clickQuit()
    {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

}
