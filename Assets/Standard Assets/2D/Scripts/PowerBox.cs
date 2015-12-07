using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class PowerBox : MonoBehaviour {

    public float interactionDistance = 1.5f;
    private bool canInteract = false;
    private Transform pos_powerBox;

    // Use this for initialization
    void Awake()
    {
        pos_powerBox = transform;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Interaction_PowerBox();
    }
    public void Interaction_PowerBox()
    {
        // Check if character is in Interaction Distance
        if (Vector2.Distance(pos_powerBox.position, PlatformerCharacter2D.m_InteractionCheck.position) <= interactionDistance)
        {
            canInteract = true;
            Debug.Log("Interactable");
        }
        else if (Vector2.Distance(pos_powerBox.position, PlatformerCharacter2D.m_InteractionCheck.position) > interactionDistance)
        {
            canInteract = false;
            Debug.Log("Not Interactable");
        }
        if (canInteract == true)
        {
            //Event
        }
    }
}
