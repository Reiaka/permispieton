using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAnim: MonoBehaviour {


    public static Animator anim;
    public GameObject stop;
    public GameObject conti;
    public GameObject quit;
    public GameObject rejoue;
    private bool arret;
    private bool pause;
    private int n;
    public Rigidbody rb;
    private float inputH;
    private float inputV;
    private int cpt;
    private Vector3 rotation;


    public static int nbBlocks = 3;      //Compteur de plateformes créées, 
										//sert à la génération de plateformes 
										//voir le script du meme nom

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        anim.SetBool("run1", true);
        rotation = GetComponentInChildren<Camera> ().transform.eulerAngles;

        arret = false;
        cpt = 0;
        inputV = 1f;
        inputH = 0f;
#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX
        stop.SetActive(false);
#endif
#if UNITY_ANDROID
        stop.SetActive(true);
#endif
    }

    // Update is called once per frame
    void Update () {

        //Permettre de lancer le menu de pause si on clique sur le bouton retour sur Android
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause = true;
        }
        if (pause)
        {

            Time.timeScale = 0f; //arret du temps dans le jeu
            conti.SetActive(true);
            quit.SetActive(true);
            rejoue.SetActive(true);

        }
        //Si appui sur le bouton quitter qui rend le booléen pause false et donc enclenche la condition suivante
        else/* if (!pause)*/
        {
            Time.timeScale = 1f; //arret du temps dans le jeu
            conti.SetActive(false);
            quit.SetActive(false);
            rejoue.SetActive(false);

        }

#if UNITY_EDITOR || UNITY_STANDALONE_WIN || UNITY_STANDALONE_LINUX

        if (Input.GetKey(KeyCode.Space))  //Si touche espace pressée fais une action
        {
            anim.SetBool("run1", false);  //le perso ne cours plus
            anim.SetBool("break", true);
            n = Random.Range(0,3);
			anim.SetInteger("num",n);
			inputV=0f;

			if (cpt<=25) //Action de rotation fais par la caméra
			{
				cpt+=1;
				GetComponentInChildren<Camera>().transform.Rotate(new Vector3(0,-15,0)*0.1f);
			}
			if((cpt>25)&(cpt<70))
			{
				cpt+=1;
				GetComponentInChildren<Camera>().transform.Rotate(new Vector3(0,15,0)*0.1f);
			}

			if (cpt ==70)
			{
				GetComponentInChildren<Camera>().transform.eulerAngles=rotation;
			}
        }
        else //Si la touche espace n'est pas pressée 
        {
            anim.SetBool("run1", true); //Le perso cours
            anim.SetBool("break", false);
            inputV =1f;
			inputH = Input.GetAxis("Horizontal");

        }

		if(Input.GetKeyUp(KeyCode.Space))
		{
			cpt=0;
			GetComponentInChildren<Camera>().transform.eulerAngles=rotation;
		}

        inputH = Input.GetAxis("Horizontal");
        anim.SetFloat("inputHori", inputH);
        anim.SetFloat("inputVerti", inputV);
#endif


#if UNITY_ANDROID

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
#endif

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

    void OnTriggerEnter(Collider other)  //Récupération des pick up
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
			if(other.gameObject.name.Contains("Valider")){
				if((AnimationVoitures.estPlateformeAvecFeu) | (AnimationVoitures1.estPlateformeAvecFeu)){
					if((AnimationVoitures.feuPietonOn) | (AnimationVoitures1.feuPieton1On)){
						ScoreScript.cptValidation += 1;
						print (ScoreScript.cptValidation);

					}
					else{
						print ("Raté");
					}
				}
				else{
					ScoreScript.cptValidation += 1;
					print (ScoreScript.cptValidation);
				}
			}
			else{
				ScoreScript.cptPanneaux += 1;
				print (ScoreScript.cptValidation);
			}
        }
    }

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.CompareTag("Voiture"))
		{
			anim.Play("DAMAGED01",-1,0f);
			ScoreScript.cptValidation -= 1;
			print (ScoreScript.cptValidation);
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

    public void rejouer()
    {
        GenerationPlateformes.listDePlateformes.Clear();
        PlayerAnim.nbBlocks = 3;
        GenerationPickUp.cptPlateforme = 0;
        ScoreScript.cptValidation = 0;
        ScoreScript.cptPanneaux = 0;
        SceneManager.LoadScene("NewRunner");
    }

    //Fonction servant à quitter le jeu si appuie sur le bouton quitter
    public void quitter()
    {
        Application.Quit();
    }

}
