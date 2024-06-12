using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public int score;
    public float jumpForce = 5f; // La force de saut
    private Rigidbody rb;
    public float speed = 10f;
    public float mouseSensitivity = 3f;
    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouvement souris cam
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation += mouseX;
        horizontalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -360f, 360f);
        horizontalRotation = Mathf.Clamp(horizontalRotation, -90f, 90f);
       // Debug.Log(horizontalRotation);
        //Debug.Log(verticalRotation);
        transform.rotation = Quaternion.Euler(horizontalRotation, verticalRotation, 0);
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * 5f * Time.fixedDeltaTime * Input.GetAxis("Vertical"));
        transform.Translate(Vector3.right * 5f * Time.fixedDeltaTime * Input.GetAxis("Horizontal"));
        //ColinAction.win = true;
        
    }
    void OnCollisionEnter(Collision collision)
    {
        // Vérifie si le joueur entre en collision avec un autre joueur
        if (collision.gameObject.CompareTag("Cigars"))
        {
            Debug.Log("Collision détectée avec un autre joueur !");
            // Ajoutez ici le code pour gérer la collision, par exemple, réduire la vie, repousser les joueurs, etc.
        }
    }

}
