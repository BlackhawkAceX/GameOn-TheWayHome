using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

public class PowerBox : MonoBehaviour {

    public float interactionDistance = 1.5f;
    private bool inRange = false;
    private bool interacted = false;
    private Transform pos_powerBox;
    private Animator box_anim;
    private bool interaction;

    // Use this for initialization
    void Awake()
    {
        pos_powerBox = transform;
        box_anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        interaction = CrossPlatformInputManager.GetButtonDown("Fire1");
        Interaction_PowerBox();
    }
    public void Interaction_PowerBox()
    {
        // Check if character is in Interaction Distance
        if (Vector2.Distance(pos_powerBox.position, PlatformerCharacter2D.m_InteractionCheck.position) <= interactionDistance)
        {
            inRange = true;
        //    Debug.Log("Interactable");
        }
        else if (Vector2.Distance(pos_powerBox.position, PlatformerCharacter2D.m_InteractionCheck.position) > interactionDistance)
        {
            inRange = false;
        //    Debug.Log("Not Interactable");
        }
        if (inRange == true && interaction == true && interacted == false)
        {
           //Event
           interacted = true;
           box_anim.SetBool("powerOn", true);
           Debug.Log("Interacted");

           //Turning On Lanterns
           GameObject lantern1 = GameObject.Find("Night-Environment-Assets-Lantern");
           Lantern lanternOn1 = (Lantern)lantern1.GetComponent(typeof(Lantern));
           lanternOn1.PowerOn(true);
           //2
           GameObject lantern2 = GameObject.Find("Night-Environment-Assets-Lantern (3)");
           Lantern lanternOn2 = (Lantern)lantern2.GetComponent(typeof(Lantern));
           lanternOn2.PowerOn(true);
           //3
           GameObject lantern3 = GameObject.Find("Night-Environment-Assets-Lantern (4)");
           Lantern lanternOn3 = (Lantern)lantern3.GetComponent(typeof(Lantern));
           lanternOn3.PowerOn(true);
        }
    }
}
