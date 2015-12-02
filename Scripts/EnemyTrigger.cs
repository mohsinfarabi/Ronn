using UnityEngine;
using System.Collections;

public class EnemyTrigger : MonoBehaviour 
{
	private EnemyController enemyController;

	// Use this for initialization
	void Awake () 
	{
		enemyController = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerExit(Collider other)
	{
				if (other.tag == "Player")
				{
						//Change the camera behavior
						//Wake up the boss
						enemyController.enemyAwake = true;
			
						collider.isTrigger = false;
						//anim.SetFloat ("speed", 0.0f);
						//Disable Character Movement
						//characterMovement.enabled = false;
						//			smoothFollow.bossCameraActive = true;
						//other.audio.Stop ();
				}
	}
}
