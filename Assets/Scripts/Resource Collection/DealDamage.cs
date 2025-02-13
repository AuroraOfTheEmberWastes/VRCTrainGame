
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;
using VRC.Udon;

public class DealDamage : UdonSharpBehaviour
{
	public int damage = 1;
	//private void OnCollisionEnter(Collision other)
	//{

	//	Debug.Log("I hit something");
	//	if (other.gameObject.GetComponent<Damageable>() != null)
	//	{
	//		Damageable target = other.gameObject.GetComponent<Damageable>();
	//		target.TakeDamage(damage);
	//	}
	//	else if (other.gameObject.GetComponentInParent<Damageable>())
	//	{
	//		Damageable target = other.gameObject.GetComponentInParent<Damageable>();
	//		target.TakeDamage(damage);
	//	}
	//}


	void OnTriggerEnter(Collider other)
	{

		Debug.Log("I hit something");
		if (other.gameObject.GetComponent<Damageable>() != null)
		{
			Damageable target = other.gameObject.GetComponent<Damageable>();
			target.TakeDamage(damage);
		}
		else if (other.gameObject.GetComponentInParent<Damageable>())
		{
			Damageable target = other.gameObject.GetComponentInParent<Damageable>();
			target.TakeDamage(damage);
		}
	}
}
