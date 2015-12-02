using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour 
{

	public bool enemyAwake = false;
	public bool inBattle = false;
	public bool attacking = false;

	public float idleTimer = 0.0f;
	public float idleWaitTimer = 1.0f;

	public float attackTimer = 0.0f;
	public float attackWaitTime = 1.0f;
	public int attackCount = 0;
	public bool attackTimerActive;

	private Animator anim;
	private CharacterHealth characterHealth;

	private BoxCollider handTrigger_R;
	// Use this for initialization
	void Awake() 
	{
		anim = GetComponentInChildren<Animator> ();
		characterHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealth>();
		anim.SetInteger ("attackCount",attackCount);
		handTrigger_R = GameObject.Find ("HandTrigger_R").GetComponent<BoxCollider>();

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (enemyAwake) 
		{
			anim.SetBool("enemyAwake",true);
			anim.SetInteger("attackCount",attackCount);

			if(inBattle)
			{

				if(!attacking)
				{
					idleTimer += Time.deltaTime;
				}
				else
				{
					idleTimer = 0.0f;
					attackTimer += Time.deltaTime;
					if(attackTimer >= attackWaitTime)
					{
						attacking = false;
						
						attackTimer = 0.0f;
						//print ("BOSS SMASH!");
						//handTrigger_L.collider.enabled = true;
						handTrigger_R.collider.enabled = true;
					}
				}


				if(idleTimer >= idleWaitTimer)
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
		
			if (characterHealth.health > 0) 
			{
				if(attackCount == 0)
				{
					inBattle = true;
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
						
						anim.SetTrigger ("enemyAttack");
						
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
}
