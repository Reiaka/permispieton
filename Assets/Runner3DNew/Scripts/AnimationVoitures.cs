using UnityEngine;
using System.Collections;

public class AnimationVoitures : MonoBehaviour {
	
	public static bool feuPietonOn;
	public static bool estPlateformeAvecFeu;

	public bool plateformeAvecFeu;
	public bool plateformeAvecGarage;

	private int cpt = 0;
	private int valeur;

	public GameObject feuAssocie;

	public int monChangementFeu = 0;
	public int monChangementFeuGarage = 0;

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
			if(plateformeAvecFeu){//Si plateforme avec feux simples
				//Debug.Log("etat du feu associé"+feuAssocie.changementFeu);
				estPlateformeAvecFeu = true;

				if(monChangementFeu == 2){
					feuPietonOn = false; 
					//Debug.Log ("feu pieton = " + feuPietonOn);
					transform.Translate (Vector3.forward * 20 * Time.deltaTime);
				}
				else{
					feuPietonOn = true;
					//Debug.Log ("feu pieton = " + feuPietonOn);
					transform.Translate (Vector3.forward * 20 * Time.deltaTime);
					transform.Translate (Vector3.back * 20 * Time.deltaTime);
				}
			}
			else if(plateformeAvecGarage){//Si plateforme avec un garage
				estPlateformeAvecFeu = true;
				//Debug.Log("plateforme avec Garage");
				if(monChangementFeuGarage == 2){
					//Debug.Log("voiture avance");
					feuPietonOn = false; 
					transform.Translate (Vector3.forward * 20 * Time.deltaTime);
				}
				else{
					feuPietonOn = true; 
					transform.Translate (Vector3.forward * 20 * Time.deltaTime);
					transform.Translate (Vector3.back * 20* Time.deltaTime);
				}
			}
			else{ //si plateforme sans garage ni feux
				estPlateformeAvecFeu = false;
				feuPietonOn = false; 
				transform.Translate (Vector3.forward * 20 * Time.deltaTime);
			}
		}

		//Debug.Log ("monChangementFeu" + monChangementFeu);
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "unitychan") {
			PlayerAnim.anim.Play ("DAMAGED01", -1, 0f);
		}
	}
}
