using UnityEngine;
using System.Collections;

public class SwordDestruction : MonoBehaviour 
{
	public float lifeSpan = 1.0f;

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, lifeSpan);
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.collider.tag == "EnvironmentCollider")
		{
			Destroy (gameObject);
		}
	}
}
