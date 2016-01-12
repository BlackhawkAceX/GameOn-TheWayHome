using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;
using UnityStandardAssets.CrossPlatformInput;

public class House : MonoBehaviour
{

    public float interactionDistance = 1.5f;
    private bool inRange = false;
    private bool interacted = false;
    private Transform house;
    private Animator house_anim;
    private bool interaction;

    // Use this for initialization
    void Awake()
    {
        house = transform;
        house_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        interaction = CrossPlatformInputManager.GetButtonDown("Fire1");
        Interaction_House();
    }
    public void Interaction_House()
    {
        // Check if character is in Interaction Distance
        if (Vector2.Distance(house.position, PlatformerCharacter2D.m_InteractionCheck.position) <= interactionDistance)
        {
            inRange = true;
            //    Debug.Log("Interactable");
        }
        else if (Vector2.Distance(house.position, PlatformerCharacter2D.m_InteractionCheck.position) > interactionDistance)
        {
            inRange = false;
            //    Debug.Log("Not Interactable");
        }
        if (inRange == true && interaction == true && interacted == false && Power.flicker == false && Power.on == false)
        {
            // play light switch sound
            FMODUnity.RuntimeManager.PlayOneShot("event:/light_switch", gameObject.transform.GetChild(0).position);

            //Event
            interacted = true;
            house_anim.SetBool("powerFlicker", true);
            Debug.Log("Interacted");
            
            //Turning On Lanterns
            GameObject lantern1 = GameObject.Find("Night-Environment-Assets-Lantern");
            Power lanternFlicker1 = (Power)lantern1.GetComponent(typeof(Power));
            lanternFlicker1.PowerFlicker(true);
            //2
            GameObject lantern2 = GameObject.Find("Night-Environment-Assets-Lantern (3)");
            Power lanternFlicker2 = (Power)lantern2.GetComponent(typeof(Power));
            lanternFlicker2.PowerFlicker(true);
            //3
            GameObject lantern3 = GameObject.Find("Night-Environment-Assets-Lantern (4)");
            Power lanternFlicker3 = (Power)lantern3.GetComponent(typeof(Power));
            lanternFlicker3.PowerFlicker(true);
            //House
            GameObject powerBox = GameObject.Find("Night-Environment-Assets-PowerBox");
            Power powerBoxFlicker = (Power)powerBox.GetComponent(typeof(Power));
            powerBoxFlicker.PowerFlicker(true);
        }
    }
	public void disableCollision()
	{
		Destroy (GetComponent<EdgeCollider2D>());
	}
}