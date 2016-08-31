using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerAnim: MonoBehaviour {

    public static Animator anim;
    public Rigidbody rb;
	private int n;
	private int cpt = 0;
    private float inputH;
    private float inputV;
    private bool run;
	private Vector3 rotation;

	public static int nbBlocks = 3;      //Compteur de plateformes créées, 
										//sert à la génération de plateformes 
										//voir le script du meme nom

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        run = true;
		rotation = GetComponentInChildren<Camera> ().transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Space))  //Si touche espace pressée fais une action
        {
			run=false;  //le perso ne cours plus
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
			run=true;  //Le perso cours
			inputV=1f;
			inputH = Input.GetAxis("Horizontal");

        }

		if(Input.GetKeyUp(KeyCode.Space))
		{
			cpt=0;
			GetComponentInChildren<Camera>().transform.eulerAngles=rotation;
		}

		if (anim.GetCurrentAnimatorStateInfo (0).IsName ("DAMAGED01"))
		{
			inputV = 0f;
		}

        inputH = Input.GetAxis("Horizontal");
        anim.SetFloat("inputHori", inputH);
        anim.SetFloat("inputVerti", inputV);
        anim.SetBool("run", run);

        float moveX = inputH * 50f * Time.deltaTime;
        float moveZ = inputV*150f*Time.deltaTime;

        if(moveZ<=0f)
        {
            moveX = 0f;
        }
        else if(run)
        {
            moveX *= 5f;
            moveZ *= 5f;

        }

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

}
