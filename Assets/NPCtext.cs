using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCtext : MonoBehaviour
{
    public Canvas canvas;
    void OnTriggerEnter(Collider other)
    {
        canvas.enabled = true;
        Debug.Log("OUAIIIS");
    }

    void OnTriggerExit(Collider other)
    {
        canvas.enabled = false;
    }
}
