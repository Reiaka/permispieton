using UnityEngine;
using System.Collections;

public class ControlFeuGarage : MonoBehaviour {

	public Material[] feux;
	public GameObject feuVert;
	public GameObject feuRouge;

	private int cpt = 0;
	public int changementFeu;
	public static bool goPieton;

	void Start(){
		changementFeu = Random.Range (1, 3);
	}

	// Update is called once per frame
	void Update () {
	
		cpt += 1;
		//print (cpt);
		if (cpt > 100) {
			cpt = 0;
			
			switch (changementFeu) {
				
			case 1: //Feu rouge, pieton avance
				cpt = -250;
				feuVert.GetComponent<Renderer> ().material = feux [0];
				feuRouge.GetComponent<Renderer> ().material = feux [2];
				changementFeu = 2;
				goPieton = true;
				break;
				
			case 2://feu vert, pieton immobile
				cpt = -400;
				feuVert.GetComponent<Renderer> ().material = feux [2];
				feuRouge.GetComponent<Renderer> ().material = feux [1];
				changementFeu = 1;
				goPieton = false;
				break;
			
			}
		}
	}
}
