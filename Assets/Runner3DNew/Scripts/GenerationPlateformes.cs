using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GenerationPlateformes : MonoBehaviour {

	public GameObject[] plateformes;
	public static List <GameObject> listDePlateformes = new List<GameObject>();
	public GameObject plateformeFin;
	private bool atelier = false;
	private bool canCreate = true;

	void OnCollisionEnter(Collision col){
		if (canCreate) {
			canCreate = false;
			PlayerAnim.nbBlocks += 1;
			GenerationPickUp.cptPlateforme += 1;
			int position = PlayerAnim.nbBlocks*40;

			if(col.gameObject.name == "unitychan"){
				//Debug.Log("entre sur new plateformes");
			    GameObject plateformesSelect = plateformes[Random.Range(0,plateformes.Length)];

				if(plateformesSelect.name.Contains("Feu")){
					if(listDePlateformes.Count >= 5){
						//Debug.Log("Il y a 5 plateformes de mise en situation");
						Instantiate(plateformeFin,
						            new Vector3(0,0,position), Quaternion.identity);
					}
					else{
						if(atelier == false){

							Instantiate(plateformesSelect,
							            new Vector3(0,0,position), Quaternion.identity);
							listDePlateformes.Add(plateformesSelect);
							//Debug.Log("Plateformes" + plateformesSelect.name + " comptabilisée");
							//Debug.Log("Prochaine plateforme créée");
							
							atelier = true;
						}
					}
				}
				else{
					Instantiate(plateformesSelect,
					            new Vector3(0,0,position), Quaternion.identity);
					atelier = false;
					//Debug.Log("Prochaine plateforme créée");
				}
			}
		}
	}

	void Update(){
		if (Vector3.Distance (transform.position, GameObject.Find ("unitychan").transform.position) > 300) {

			Destroy(this.transform.parent.gameObject); //transform.parent récupère l'élément dont 
													  //l'objet manipulé est issu et le supprime entièrement
													 //Les plateformes entières sont supprimées et pas juste les trottoirs
		}
	}
}
