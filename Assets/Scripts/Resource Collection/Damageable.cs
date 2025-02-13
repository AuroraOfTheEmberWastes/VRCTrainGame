
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class Damageable : UdonSharpBehaviour
{
			// BIG FAT NOTE: IF COLLIDERS FOR OBJECTS CHANGE, THIS NEEDS ALTERATION WHERE IT IS MARKED WITH <<


	//For damage calc
	public int toughness = 1;
	private int damageTaken = 0;

	//For deciding the form changing
	private int currentDamageLevel = 0;
	private int damageLevelChange = 0;

	//For storing what needs to be activated and 
	public GameObject[] damageLevels = new GameObject[4];
	public GameObject spawnedResource;

	//For debug
	private int totalDamage = 0;

	private void Start()
	{
		//so colliders other than the first get inspector defined toughness				<<
		toughness++;
	}

	public void TakeDamage(int damage)
	{
		//Taking the damage
		Debug.Log("Damage dealt");
		damageTaken += damage;

		//Debug
		//totalDamage += damage;
		//Debug.Log(damageTaken);
		
		//so first collider gets inspector defined toughness							<<
		if (damageTaken >= toughness - 1 && currentDamageLevel == 0)
		{
			damageLevelChange += 1;
			damageTaken -= toughness-1;
		}

		while (damageTaken >= toughness)
		{
			damageLevelChange += 1;
			damageTaken -= toughness;
		}

		//Stops if the damage isn't enough to change its' form
		if (damageLevelChange != 0)
		{
			damageLevels[currentDamageLevel].SetActive(false);
			currentDamageLevel += damageLevelChange;
			//If enough damage is dealt, destroy and spawn resource
			if (currentDamageLevel > damageLevels.Length - 1)
			{
				if (spawnedResource != null)
				{
					Instantiate(spawnedResource,transform.position, transform.rotation);
				}
				//Destroy(gameObject);
				this.enabled = false;					
			} //Otherwise, change active model to reflect damage taken
			else
			{
				damageLevels[currentDamageLevel].SetActive(true);
			}
			damageLevelChange = 0;
		}
	}
}
