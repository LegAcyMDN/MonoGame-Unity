using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void JouerScene(int sceneJouer)
    {
        SceneManager.LoadScene(sceneJouer);
    }

    public void CreditScene(int creditScene)
    {
        SceneManager.LoadScene(creditScene);
    }

    public void Quitter()
    {
        Application.Quit();
    }
}
