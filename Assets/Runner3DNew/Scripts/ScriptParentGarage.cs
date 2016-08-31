using UnityEngine;
using System.Collections;

public class ScriptParentGarage : MonoBehaviour {
	private bool feuxLances=false;
	
	public ControlFeuGarage parentControlGarage;
	public AnimationVoitures parentAnimVoiture;
	
	// Use this for initialization
	void Start () {
		Component[] mesControlFeuGarage;
		Component[] mesAnimationVoitures;
		
		mesControlFeuGarage = GetComponentsInChildren( typeof(ControlFeuGarage) );
		mesAnimationVoitures = GetComponentsInChildren( typeof(AnimationVoitures) );
		
		if( mesControlFeuGarage != null )
		{
			foreach( ControlFeuGarage joint in mesControlFeuGarage )
			{
				//Debug.Log("on a trouve un joint"+joint + "joint.changementFeu : "+joint.changementFeu);
				
				if( mesAnimationVoitures != null )
				{
					foreach( AnimationVoitures voit in mesAnimationVoitures )
					{
						
						//voit.monChangementFeu = joint.changementFeu;
						parentControlGarage = joint;
						parentAnimVoiture = voit;
						feuxLances=true;
						
					}
				}
			}
		}
		else
		{
			
		}
	}
	
	void Update()
	{
		if (feuxLances == true) {
			//Debug.Log("changement feu du parent : "+parentControlFeu.changementFeu);
			parentAnimVoiture.monChangementFeuGarage = parentControlGarage.changementFeu;
		}
		
	}
}
