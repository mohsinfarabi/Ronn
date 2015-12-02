using UnityEngine;
using System.Collections;

public class KillBox : MonoBehaviour 
{
	public CharacterHealth characterHealth;

	// Use this for initialization
	void Awake () 
	{
		characterHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			characterHealth.health = 0;
			Application.LoadLevel(0);
		}
	}

}
