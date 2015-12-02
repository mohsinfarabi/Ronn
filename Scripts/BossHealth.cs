using UnityEngine;
using System.Collections;

public class BossHealth : MonoBehaviour 
{
	public int health = 4;
	public float timer = 0.0f;
	public float waitTime = 2.0f;
	public bool bossDead;
	public Material hurtEyeMaterial;
	private GameObject eyeModel;

	private BossController bossController;
	private SceneFadeInOut sceneFadeInOut;
	private Animator anim;

	public AudioClip hitAudio;

	// Use this for initialization
	void Awake () 
	{
		bossController = GameObject.FindGameObjectWithTag("Boss").GetComponent<BossController>();
		sceneFadeInOut = GameObject.FindGameObjectWithTag("Fader").GetComponent<SceneFadeInOut>();
		anim = GameObject.Find ("Boss_Rig").GetComponent<Animator>();
		eyeModel = GameObject.FindGameObjectWithTag("EyeModel");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(health <= 0)
		{
			if(!bossDead)
			{
				BossDying();
			}

			else
			{
				BossDead();
				//LevelReset();
				Application.LoadLevel(0);
			}

		}
	
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Projectile" && health > 0)
		{
			if(health != 1)
			anim.SetTrigger("isHit");
			bossController.inBattle = false;
			bossController.DisableEye();

			AudioSource.PlayClipAtPoint(hitAudio, transform.position, 0.2f);

			health--;
			print ("Boss Health: " + health);

			Destroy (other.gameObject);

			if(health == 2)
			{
				eyeModel.renderer.material = hurtEyeMaterial;
			}

		}
	}

	void BossDying()
	{
		bossDead = true;
		anim.SetBool ("isDead", bossDead);
	}

	void BossDead()
	{
		if(anim.GetCurrentAnimatorStateInfo(0).IsName("Boss_Death"))
		{
			anim.SetBool ("isDead", false);
		}
	}


	void LevelReset()
	{
		timer += Time.deltaTime;
		
		if(timer >= waitTime)
		{
			sceneFadeInOut.EndScene();
		}
	}
}
