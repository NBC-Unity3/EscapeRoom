using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    [SerializeField] private GameObject settings;

    public void OnClickStart()
    {
        SceneManager.LoadScene("Test_Choi");
    }

    public void OnClickSettings()
    {
        settings.SetActive(true);
    }

    public void OnClickExit()
    {
        Application.Quit();
    }
}
