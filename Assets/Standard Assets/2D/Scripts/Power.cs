using UnityEngine;
using System.Collections;

public class Power : MonoBehaviour {

    private Animator lantern_anim;
    public static bool flicker = false;
    public static bool on = false;

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
            flicker = false;
            on = true;
        }
    }
    public void PowerFlicker(bool powerFlicker)
    {
        if (powerFlicker == true)
        {
            lantern_anim.SetBool("powerFlicker", true);
            Debug.Log("Animation Changed");
            flicker = true;
        }
    }
}
