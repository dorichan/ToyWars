using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour 
{
	public float health;
	public bool isDead;

	private float maxHealth;
	private float damage;
	private GameObject gm;

	void Awake()
	{
		gm = GameObject.FindGameObjectWithTag("GameManager");
	}

 	void Start () 
	{
		maxHealth = 100.0f;
		health = maxHealth;
		damage = 10.0f;
		isDead = false;
	}

	void Update()
	{
		if (health <= 0.0f) {
			Dead ();
		}
	}
	
	public void OnDamage () 
	{
		health -= damage;
	}

	void Dead()
	{
		if(gameObject == GameObject.FindWithTag("Red")) {
			gm.GetComponent<GameManager>().numRobots -= 1;
		}
		if(gameObject == GameObject.FindWithTag("Blue")) {
			gm.GetComponent<GameManager>().numFloaters -= 1;
		}
		Destroy (gameObject);
	}
}