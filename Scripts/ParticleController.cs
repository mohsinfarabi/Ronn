using UnityEngine;
using System.Collections;

public class ParticleController : MonoBehaviour 
{
	public float emitTime = 0.0f;
	public float emitWaitTime;
	public int minEmitTime = 1;
	public int maxEmitTime = 5;

	private ParticleSystem rockPS;
	// Use this for initialization
	void Awake () 
	{
		emitWaitTime = Random.Range(minEmitTime, maxEmitTime);
		rockPS = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		emitTime += Time.deltaTime;
		if(emitTime >= emitWaitTime)
		{
			EmitParticles();
		}
	}

	void EmitParticles()
	{
		rockPS.Play ();
		emitTime = 0.0f;
		emitWaitTime = Random.Range(minEmitTime, maxEmitTime);
	}
}
