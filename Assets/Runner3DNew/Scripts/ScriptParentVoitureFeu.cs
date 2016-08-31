using UnityEngine;
using System.Collections;

public class ScriptParentVoitureFeu : MonoBehaviour {
	private bool feuxLances=false;

	public ControlFeuVehicule parentControlFeu;
	public AnimationVoitures parentAnimVoiture;
	public AnimationVoitures1 parentAnimVoiture1;

	// Use this for initialization
	void Start () {
		Component[] mesControlFeuVehicule;
		Component[] mesAnimationVoitures;
		Component[] mesAnimationVoitures1;
		
		mesControlFeuVehicule = GetComponentsInChildren( typeof(ControlFeuVehicule) );
		mesAnimationVoitures = GetComponentsInChildren( typeof(AnimationVoitures) );
		mesAnimationVoitures1 = GetComponentsInChildren( typeof(AnimationVoitures1) );
		
		if( mesControlFeuVehicule != null )
		{
			foreach( ControlFeuVehicule joint in mesControlFeuVehicule )
			{
				//Debug.Log("on a trouve un joint"+joint + "joint.changementFeu : "+joint.changementFeu);

				if( mesAnimationVoitures != null )
				{
					foreach( AnimationVoitures voit in mesAnimationVoitures )
					{

						//voit.monChangementFeu = joint.changementFeu;
						parentControlFeu = joint;
						parentAnimVoiture = voit;
						feuxLances=true;

					}
				}
				if( mesAnimationVoitures1 != null )
				{
					foreach( AnimationVoitures1 voit1 in mesAnimationVoitures1 )
					{
						
						//voit.monChangementFeu = joint.changementFeu;
						parentAnimVoiture1 = voit1;
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
			parentAnimVoiture.monChangementFeu=parentControlFeu.changementFeu;
			parentAnimVoiture1.monChangementFeu=parentControlFeu.changementFeu;
		}

	}
}
