using UnityEngine;
using System.Collections;

public class ValidationNiveau : MonoBehaviour {

	public GameObject panneauPickUp;
	private bool canCreate = true;

	void OnCollisionEnter(Collision col){
		if (canCreate) {
			canCreate = false;
			int positionZ = GenerationPickUp.cptPlateforme*40;
		
			if(col.gameObject.name == "unitychan"){
				float panneauPosition = 12.5f;
				Instantiate(panneauPickUp, new Vector3(panneauPosition,5,positionZ), panneauPickUp.transform.rotation);
			}
		}
	}

	void Update(){

	}
}
