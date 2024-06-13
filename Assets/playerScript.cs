using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    public float jumpForce = 5f; // La force de saut
    private Rigidbody rb;
    public float speed = 10f;
    public float mouseSensitivity = 3f;
    private float horizontalRotation = 0f;
    private float verticalRotation = 0f;
    public CigarSpawner spawnCigarScript;
    public TMP_Text scoreText;
    public Canvas CanvaScore; // <-- Assign your GUITexture to this.
    public float life=100f;
    public static float dommage=10f;
    public const float maxLife = 100f;
    public Canvas lifeBar;
    public Canvas baseBar;
    public Canvas mort;

    public static int score = 0;

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //GameObject phasmeObj = GameObject.FindGameObjectWithTag("Phasme");
        //phasmeObj.SetActive(false);
        CanvaScore.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        if (scoreText == null)
        {
            Debug.LogError("Le champ scoreText n'a pas �t� assign� dans l'inspecteur.");
            return;
        }
        UpdateScoreText();
        rb = GetComponent<Rigidbody>();

        manager = GameManager.instance;
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

    void OnTriggerEnter(Collider trigger)
    {
        if (trigger.gameObject.CompareTag("Colin"))
        {

            if (!ColinAction.win)
            {
                CanvaScore.enabled = true;
            }
            else
            {
                CanvaScore.enabled = false;

            }
        
        }
        if (trigger.gameObject.CompareTag("Cigars"))
        {
            score++;
            UpdateScoreText();
            Destroy(trigger.gameObject);
            if (score < 5)
            {
                spawnCigarScript.SpawnCigars();
            }
            else if(score >=5) {
                ColinAction.win = true;
            }
        }
    }


        void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("tirEnnemi"))
        {
            Destroy(collision.gameObject);
            life -= 10;
            UpdatingLifeBar(life, maxLife);
        }
    }

    public void UpdateScoreText()
    {

       // Mettre � jour le texte du score
       scoreText.text = "Cigare(s): " + score + "/5";
        if(score >= 5)
        {
            //TODO DECLANCHER LE BOSSFIGHT
            ColinAction.win = true;
        }
    }
    public void UpdatingLifeBar(float life, float maxlife)
    {
        if (life > 0)
        {
            RectTransform rt = lifeBar.GetComponent(typeof(RectTransform)) as RectTransform;
            RectTransform rt2 = baseBar.GetComponent(typeof(RectTransform)) as RectTransform;
            rt.sizeDelta = new Vector2(life / maxlife * rt.sizeDelta.x, rt.sizeDelta.y);
        } else
        {
            //SceneRetour(0);
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
           // mort.enabled = true;
        }




    }

    //public void SceneRetour(int sceneRetour)
    //{ manager.sceneRetour = sceneRetour;}
}
