using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class playerScript : MonoBehaviour
{
    public float jumpForce = 5f; // La force de saut
    private Rigidbody rb;
    public float speed = 10f;
    public float mouseSensitivity = 3f;
    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;
    public TMP_Text scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (scoreText == null)
        {
            Debug.LogError("Le champ scoreText n'a pas été assigné dans l'inspecteur.");
            return;
        }
        UpdateScoreText();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //mouvement souris cam
       float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        verticalRotation += mouseX;
        horizontalRotation -= mouseY;
       verticalRotation = Mathf.Clamp(verticalRotation, -360f, 360f);
         horizontalRotation= Mathf.Clamp(horizontalRotation, -90f, 90f);
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
        if (collision.gameObject.CompareTag("Colin"))
        {

        }
        // Vérifie si le joueur entre en collision avec un autre joueur
        if (collision.gameObject.CompareTag("Cigars"))
        {
            Destroy(collision.gameObject);
        }
        // Vérifier si l'objet touché a le tag "Collectible"
        if (collision.gameObject.CompareTag("Cigars"))
        {
            // Incrémenter le score
            score++;
            // Mettre à jour le score affiché
            UpdateScoreText();
            // Détruire l'objet touché
            Destroy(collision.gameObject);
        }
    }

    void UpdateScoreText()
    {

       // Mettre à jour le texte du score
       scoreText.text = "Score: " + score;
    }
}
