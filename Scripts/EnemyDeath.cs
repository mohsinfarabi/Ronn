using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void OnCollisionEnter(Collision other)
	{
		//if(other.collider.tag == "EnvironmentCollider")
		//{
			Destroy (gameObject);
		//}
	}
}
