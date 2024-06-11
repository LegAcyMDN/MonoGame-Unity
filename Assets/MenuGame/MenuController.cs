using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ChangeScene(int sceneJouer)
    {
        SceneManager.LoadScene(sceneJouer);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
