using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

	private Animator tower_anim;
	public static bool on = false;
	public static bool active = false;

	// Use this for initialization
	void Start () {
		tower_anim = GetComponent<Animator> ();
	}
	
	public void PowerOn(bool towerPowerOn)
	{
		if (towerPowerOn == true)
		{
			tower_anim.SetBool("towerPowerOn", true);
			Debug.Log("Tower Animation Changed");
			on = true;
		}
	}
	public void TowerActive(bool towerActive)
	{
		if (towerActive == true)
		{
			tower_anim.SetBool("towerPowerOnActive", true);
			Debug.Log("Tower Animation Changed");
			active = true;
		}
	}
}
