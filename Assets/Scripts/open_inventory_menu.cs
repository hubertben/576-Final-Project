using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_inventory_menu : MonoBehaviour
{
    public GameObject inventoryMenu;
    public GameObject interactionInstructions;
    public GameObject inventory;
    public GameObject inventorySpot;
    private Animator animation_controller;

    private void Start()
    {
        animation_controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //if player is inside a square surrounding the inventory object, tell them how to open inventory
        if(transform.position.x < inventorySpot.transform.position.x + 4 && transform.position.x > inventorySpot.transform.position.x - 4 &&
           transform.position.z < inventorySpot.transform.position.z + 4 && transform.position.z > inventorySpot.transform.position.z - 4)
        {
            inventoryMenu.SetActive(true);
            //if they press E, open the inventory
            if(Input.GetKey(KeyCode.E))
            {
                interactionInstructions.SetActive(false);
                inventory.SetActive(true);
                animation_controller.SetBool("inMenu", true);
            }
            else if(!animation_controller.GetBool("inMenu")) //if we didn't open the menu, then keep telling us how to 
            {
                interactionInstructions.SetActive(true);
                inventory.SetActive(false);
            }
        }
        else
        {
            inventoryMenu.SetActive(false);
        }
    }
}
