using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NewPlayerAnim : MonoBehaviour {

    public static Animator anim;
    public GameObject conti;
    public GameObject quit;
    private bool arret;
    private bool pause;
    private int n;
    public Rigidbody rb;
    private float inputH;
    private float inputV;
    private int cpt;
    private Vector3 rotation;
    public Text countText;
    public Button stop;
    private int count;
    private int click;


    public static int nbBlocks = 3;

    // Use this for initialization
    void Start () {
        

        arret = false;
        n = 0;
        cpt = 0;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        anim.SetBool("run1", true);
        inputV = 1f;
        inputH = 0f;
        click = 0;
        rotation = GetComponentInChildren<Camera>().transform.eulerAngles;
        countText.text = "Score: ";
        count = 0;


    }

    // Update is called once per frame
    void Update () {


        //Permettre de lancer le menu de pause si on clique sur le bouton retour sur Android
        if (Input.GetKeyDown(KeyCode.Escape)| (pause))
        {

            Time.timeScale = 0f; //arret du temps dans le jeu
            conti.SetActive(true);
            quit.SetActive(true);
        }
        //Si appui sur le bouton quitter qui rend le booléen pause false et donc enclenche la condition suivante
        else if(!pause)
        {
            Time.timeScale = 1f; //arret du temps dans le jeu
            conti.SetActive(false);
            quit.SetActive(false);
        }



        //Mise en place des mobiles touch
        if (Input.touchCount > 0)
        {
            // Gère les mouvements de touchers sur l'écran en fonction de la phase
            switch (Input.GetTouch(0).phase)
            {
                // Enregistre la position du touch
                case TouchPhase.Began:
                    if (pause)
                    {
                        anim.SetFloat("inputHori", 0f);
                        inputH = 0f;
                    }
                    else if (Input.GetTouch(0).position.x < Screen.width / 2)
                    {
                        anim.SetFloat("inputHori", -1f);
                        inputH = -1f;
                    }

                    else if (Input.GetTouch(0).position.x > Screen.width / 2)
                    {
                        anim.SetFloat("inputHori", 1f);
                        inputH = 1f;
                    }


                    break;


                // Réagis si le toucher est fini
                case TouchPhase.Ended:
                    anim.SetFloat("inputHori", 0f);
                    inputH = 0f;
                    break;
            }

        }
        //Si appel de la fonction publique presserPause
        if (arret)
        {
            inputV = 0f;
            anim.SetBool("break", true);
            anim.SetFloat("inputVerti", inputV);
            anim.SetBool("run1", false);
            n = Random.Range(1, 4);
            anim.SetInteger("num", n);


            //Partie Camera: Roatation de la caméra lorsque l'on appuie sur pause
            if (cpt <= 25)
            {
                cpt += 1;
                GetComponentInChildren<Camera>().transform.Rotate(new Vector3(0, -15, 0) * 0.1f);
            }
            else if ((cpt > 25) & (cpt < 70))
            {
                cpt += 1;
                GetComponentInChildren<Camera>().transform.Rotate(new Vector3(0, 15, 0) * 0.1f);
            }

            else if ((cpt >= 70) & (cpt < 90))
            {
                cpt += 1;
                GetComponentInChildren<Camera>().transform.eulerAngles = rotation;
            }

            //Partie Camera fin
        }

        //Code qui change les valeurs des variables quand la pause est terminée
        else
        {
            inputV = 1f;
            anim.SetBool("run1", true);
            anim.SetBool("break", false);
            anim.SetFloat("inputVerti", inputV);
            cpt = 0;
            GetComponentInChildren<Camera>().transform.eulerAngles = rotation;
        }
        //Condition qui s'enclenche si l'animation joué par l'animator(controller gérant les animations d'un gameobject rattaché)
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("DAMAGED01"))
        {
            inputV = 0f;
        }
        //Code qui sert à permettre au personnage de ne pas seulement exécuter l'animation de se mouvoir mais aussi d'avancer en même temps
        float moveX = inputH * 375f * Time.deltaTime;
        float moveZ = inputV * 750f * Time.deltaTime;

        if (moveZ <= 0f)
        {
            moveX = 0f;
        }

        //Code donnant de la vélocité au rigidbody et le faisant ainsi avancer
        rb.velocity = new Vector3(moveX, 0, moveZ);


    }

    // Fonction permettant au pick up d'être ramassé
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
    }
    //Fonction actualisant le score
    void SetCountText()
    {
        countText.text = "Score:" + count;
    }

    //Fonction réagissant à la collision aveec des voitures
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Voiture"))
        {
            anim.Play("DAMAGED01", -1, 0f);
        }

    }

    //Fonction rendant le booléen pause true et entraînant en réaction un changement dans la fonciton update()
    public void presserArret()
    {
        if (arret)
        {
            arret = false;
        }
        else
        {
            arret = true;
        }
    }

    //Fonction servant à lancer le menu pause et consécutivement à stopper le temps dans le jeu
    public void presserPause()
    {
        pause = true;
    }

    //Fonction relancant le jeu si appui sur le bouton continuer
    public void continuer()
    {
        pause = false;
    }

    //Fonction servant à quitter le jeu si appuie sur le bouton quitter
    public void quitter()
    {
        Application.Quit();
    }
}
