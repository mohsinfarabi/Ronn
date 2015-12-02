using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
	//public int health = 2;
	private BoxCollider boxCollider;
	private GameObject enemy;
	// Use this for initialization
	void Start ()
	{
		//enemy = GameObject.FindGameObjectWithTag("Enemy");
	}

	void update()
	{


	}
	// Update is called once per frame

	void OnTriggerEnter(Collider other)
	{
					
						Destroy (this);
			

				
	}

}
