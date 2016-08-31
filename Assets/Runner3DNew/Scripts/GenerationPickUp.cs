using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GenerationPickUp : MonoBehaviour {
	
	public GameObject panneauPickUp;
	public Material[] typePanneau;
	private bool canCreate = true;
	public static int cptPlateforme = 0;
	private int[] panneauPosition = {7,10,14,18};

	void OnCollisionEnter(Collision col){
		if (canCreate) {
			canCreate = false;
			int posSup = Random.Range (2, 15);
			int positionZ = cptPlateforme * 40;
			int indexMaterial = Random.Range(0,5);
			if (col.gameObject.name == "unitychan") {
				int indexPosition = Random.Range(0,4);

				Instantiate (panneauPickUp, new Vector3 (panneauPosition[indexPosition], 3, positionZ + posSup), panneauPickUp.transform.rotation);
				panneauPickUp.GetComponent<Renderer> ().material = typePanneau [indexMaterial];
			}
		}
	}
}
