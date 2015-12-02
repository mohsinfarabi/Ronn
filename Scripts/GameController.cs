using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
//	public BossController bossController;
//	public BossHealth bossHealth;
//	public AudioSource bossAudio;
	public float musicFadeSpeed = 1.0f;

	// Use this for initialization
	void Awake () 
	{
	//	bossAudio = transform.Find ("SecondaryMusic").audio;
//		bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
	//	bossHealth = GameObject.FindGameObjectWithTag("Boss").GetComponentInChildren<BossHealth>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		MusicFading();
	}

	void MusicFading()
	{/*
		if(bossController.bossAwake && bossHealth.health > 0)
		{
			audio.volume = Mathf.Lerp (audio.volume, 0.0f, musicFadeSpeed * Time.deltaTime);
			bossAudio.volume = Mathf.Lerp (bossAudio.volume, 0.05f, musicFadeSpeed * Time.deltaTime);
		}

		else
		{
			audio.volume = Mathf.Lerp (audio.volume, 0.1f, musicFadeSpeed * Time.deltaTime);
			bossAudio.volume = Mathf.Lerp (bossAudio.volume, 0.0f, musicFadeSpeed * Time.deltaTime);
		}
	*/}
}
