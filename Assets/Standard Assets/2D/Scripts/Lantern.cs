using UnityEngine;
using System.Collections;

public class Lantern : MonoBehaviour {

    private Animator lantern_anim;

    // Use this for initialization
    void Awake() {
        lantern_anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
	    
	}
    public void PowerOn(bool powerOn)
    {
        if (powerOn == true)
            {
            lantern_anim.SetBool("powerOn", true);
            Debug.Log("Animation Changed");
        }
    }
}
