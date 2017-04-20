using UnityEngine;
using System.Collections;

public class AnimationVoitures1 : MonoBehaviour {
	
	public static bool feuPieton1On;
	public static bool estPlateformeAvecFeu;

	public bool plateformeAvecFeu;
	public bool plateformeAvecGarage;

	private int cpt = 0;
	private int valeur;

	public GameObject feuAssocie;

	public int monChangementFeu=0;

	public bool valAleatoire;

	void Start(){
		
		if (valAleatoire) {
			valeur = Random.Range (0, 650);
		} else {
			valeur = 100;
		}
	}

	// Update is called once per frame
	void Update () {
		cpt += 1;

		if (cpt > valeur) {
			if(plateformeAvecFeu == true){
				//Debug.Log("etat du feu associé"+feuAssocie.changementFeu);
				estPlateformeAvecFeu = true;

				if(monChangementFeu == 2){
					feuPieton1On = false; 
					//Debug.Log ("feu pieton = " + feuPieton1On);
					transform.Translate (Vector3.forward * 20 * Time.deltaTime);
				}
				else{
					feuPieton1On = true; 
					//Debug.Log ("feu pieton = " + feuPieton1On);
					transform.Translate (Vector3.forward * 20 * Time.deltaTime);
					transform.Translate (Vector3.back * 20 * Time.deltaTime);
				}
			}
			else{
				estPlateformeAvecFeu = false;
				feuPieton1On = false; 
				transform.Translate (Vector3.forward * 20f * Time.deltaTime);
			}
		}

		//Debug.Log ("monChangementFeu" + monChangementFeu);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "unitychan") {
			PlayerAnim.anim.Play ("DAMAGED01", -1, 0f);
		} else if (col.gameObject.name == "façade") {
			print ("façade heurtée");
		}
	}
}
