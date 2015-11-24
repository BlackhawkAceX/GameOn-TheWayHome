using UnityEngine;
using System.Collections;



public class Interaction : MonoBehaviour {

    public float interactionDistance;
    private bool canInteract = false;
    public Transform m_Character;
    public Transform m_Object;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        // Check if character is in Interaction Distance
        if (Vector2.Distance(m_Object.position, m_Character.position) <= interactionDistance)
        {
            canInteract = true;
            Debug.Log("Interactable");
        }
        if (Vector2.Distance(m_Object.position, m_Character.position) > interactionDistance)
        {
            canInteract = false;
            Debug.Log("Not Interactable");
        }
    }
    
}
