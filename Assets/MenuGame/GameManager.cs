using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

    private void Awake()
    {
        if (instance != null)
        { Destroy(this); return; }

        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    public void JouerScene(int sceneJouer)
    { SceneManager.LoadScene(sceneJouer); }

    public void Quitter()
    { Application.Quit(); }
}
