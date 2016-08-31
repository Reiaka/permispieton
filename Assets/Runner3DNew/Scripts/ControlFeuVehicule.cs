using UnityEngine;
using System.Collections;

public class ControlFeuVehicule : MonoBehaviour {

	public Material[] feux;
	public GameObject feuVert;
	public GameObject feuOrange;
	public GameObject feuRouge;

	public GameObject feuVertPieton;
	public GameObject feuRougePieton;

	public static bool feuPieton;

	private int cpt = 0;
	public int changementFeu;
	public static int changementEtat;

	void Start(){
		changementFeu = Random.Range (1, 4);
	}
	
	// Update is called once per frame
	void Update () {
		cpt += 1;
		if (cpt > 120) {
			cpt = 0;
			
			switch (changementFeu) {
				
			case 1:

				cpt = -300;
				feuVert.GetComponent<Renderer>().material = feux[0];
				feuOrange.GetComponent<Renderer>().material = feux[3];
				feuRouge.GetComponent<Renderer>().material = feux[3];

				feuVertPieton.GetComponent<Renderer>().material = feux[3];
				feuRougePieton.GetComponent<Renderer>().material = feux[2];

				feuPieton = false;
				changementFeu = 2;
				changementEtat = changementFeu;
				Debug.Log ("changement d'etat");

				break;
				
			case 2:

				cpt = 2;
				feuVert.GetComponent<Renderer>().material = feux[3];
				feuOrange.GetComponent<Renderer>().material = feux[1];
				feuRouge.GetComponent<Renderer>().material = feux[3];

				feuVertPieton.GetComponent<Renderer>().material = feux[3];
				feuRougePieton.GetComponent<Renderer>().material = feux[2];

				feuPieton = true;
				changementFeu = 3;
				changementEtat = changementFeu;
				Debug.Log ("feu rouge pour les voitures");
				//Debug.Log ("feu pieton = " + feuPieton);
				break;
				
			case 3:
				cpt = -250;
				feuVert.GetComponent<Renderer>().material = feux[3];
				feuOrange.GetComponent<Renderer>().material = feux[3];
				feuRouge.GetComponent<Renderer>().material = feux[2];

				feuVertPieton.GetComponent<Renderer>().material = feux[0];
				feuRougePieton.GetComponent<Renderer>().material = feux[3];

				feuPieton = false;
				changementFeu = 1;
				changementEtat = changementFeu;
				Debug.Log ("feu vert pour les voitures");
				//Debug.Log ("feu pieton = " + feuPieton);
				break;
			}
		}
	}
}
