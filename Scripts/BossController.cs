using UnityEngine;
using System.Collections;

public class BossController : MonoBehaviour 
{
	public bool bossAwake = false;
	public bool inBattle = false;
	public bool attacking = false;

	public float idleTimer = 0.0f;
	public float idleWaitTime = 10.0f;

	public float attackTimer = 0.0f;
	public float attackWaitTime = 2.0f;
	public int attackCount = 0;
	public bool attackTimerActive;

	private Animator anim;
	private BossHealth bossHealth;
	private CharacterHealth characterHealth;
	
	private SphereCollider eyeTrigger;

	public float blinkTimer = 0.0f;
	public float blinkWaitTime = 2.0f;

	public AudioClip bossIntroAudio;
	public AudioClip smashAudio;
	public AudioClip deathAudio;

	// Use this for initialization
	void Awake () 
	{
		anim = GetComponentInChildren<Animator>();
		bossHealth = GetComponentInChildren<BossHealth>();
		characterHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();

		eyeTrigger = GameObject.Find ("EyeTrigger").GetComponent<SphereCollider>();
	
		anim.SetInteger("attackCount", attackCount);
	}


	// Update is called once per frame
	void Update () 
	{
		if(bossAwake)
		{
			anim.SetBool("bossAwake", true);
			anim.SetInteger("attackCount", attackCount);

			if(inBattle)
			{
				blinkTimer += Time.deltaTime;
				if(blinkTimer >= blinkWaitTime)
				{
					EyeBlink();
					blinkTimer = 0.0f;
				}
				if(!attacking)
				{
					idleTimer += Time.deltaTime;
				}

				if(idleTimer >= idleWaitTime)
				{
					//attacking = true;
					attackTimerActive = true;
					idleTimer = 0.0f;
				}
			}
			else
			{
				idleTimer = 0.0f;
			}

			if(bossHealth.health > 0 && characterHealth.health > 0)
			{
				if(attackCount == 0)
				{
					inBattle = true;
					if(bossHealth.health == 4)
					{
						attackCount = 1;
						attackWaitTime = 4.0f;
					}

					if(bossHealth.health == 3)
					{
						attackCount = 2;
						attackWaitTime = 3.0f;
					}

					if(bossHealth.health == 2)
					{
						attackCount = 3;
						attackWaitTime = 2.0f;
					}

					if(bossHealth.health == 1)
					{
						attackCount = 4;
						attackWaitTime = 1.0f;
					}
				}

				if(attackTimerActive)
				{
					anim.SetBool ("attackReady", true);
					attackTimer += Time.deltaTime;
					idleTimer = 0.0f;
					
					if(attackTimer >= attackWaitTime)
					{
						if(attackCount == 0)
						{
							attacking = false;
						}

						anim.SetTrigger ("bossAttack");
						
						attackTimer = 0.0f;
						anim.SetBool("attackReady", false);
						attackTimerActive = false;
						
					}
				}
			}

			else
			{
				attackTimer = 0.0f;
			}
			
		}
		
	}

	public void UpdateAttackCount()
	{
		if(characterHealth.health > 0)
		{
			attackCount--;
		}

		else
		{
			attackCount = 0;
		}
	}

	public void ActivateAttackTimer()
	{
		attackTimerActive = true;
	}

	void EyeBlink()
	{
		if(bossHealth.health > 0)
		{
			anim.SetTrigger("blink");
		}
	}

	public void EnableEye()
	{
		eyeTrigger.collider.enabled = true;
	}

	public void DisableEye()
	{
		eyeTrigger.collider.enabled = false;
	}

	public void PlayIntroAudio()
	{
		AudioSource.PlayClipAtPoint(bossIntroAudio, transform.position, 0.2f);
	}

	public void PlaySmashAudio()
	{
		AudioSource.PlayClipAtPoint(smashAudio, transform.position, 0.2f);
	}

	public void PlayDeathAudio()
	{
		AudioSource.PlayClipAtPoint(deathAudio, transform.position, 0.2f);
	}



}
