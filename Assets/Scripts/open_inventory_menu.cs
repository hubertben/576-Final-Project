using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class open_inventory_menu : MonoBehaviour
{

    private int temp_index = 0;

    public Canvas canvas;
    public GameObject inventoryMenu = GameObject.Find("InventoryMenu");
    public GameObject interactionInstructions;
    public GameObject inventory;
    public GameObject inventorySpot;
    private Animator animation_controller;
    private string[] all_items = {"BasicSword", "AdvancedSword", "MasterSword", "BasicGun", "AdvancedGun", "MasterGun", "BasicBomb", "AdvancedBomb", "MasterBomb"};
    private Weapon[] all_items_objects;
    private string[] selected_items = new string[9];
    private Weapon selected_item;
    private int selected_item_index = 0;
    private Weapon current_item;



    public GameObject basicSword;
    public GameObject basicGun;
    public GameObject basicBomb;   

    public GameObject advancedSword;
    public GameObject advancedGun;
    public GameObject advancedBomb;

    public GameObject masterSword;
    public GameObject masterGun;
    public GameObject masterBomb;



    private void Start()
    {
        
        animation_controller = GetComponent<Animator>();
        init_canvas();
        init_weapons();

        unlock_item(0);
        unlock_item(8);

        unlock_item(4);
    }

    private void init_canvas(){

        int[] name_indicies = {5, 10, 15, 20, 25, 30, 35, 40, 45};
        int[] damage_indicies = {6, 11, 16, 21, 26, 31, 36, 41, 46};
        int[] level_indicies = {7, 12, 17, 22, 27, 32, 37, 42, 47};

        for(int i = 0; i < 9; i++){
            inventoryMenu.GetComponentsInChildren<Transform>()[name_indicies[i]].GetComponent<Text>().text = "???";
            inventoryMenu.GetComponentsInChildren<Transform>()[damage_indicies[i]].GetComponent<Text>().text = "???";
            inventoryMenu.GetComponentsInChildren<Transform>()[level_indicies[i]].GetComponent<Text>().text = "???";
        }

    }

    private void init_weapons(){

        all_items_objects = new Weapon[9];

        all_items_objects[0] = new Weapon(1, 20, 1, 1, "Sword", 0);
        all_items_objects[1] = new Weapon(2, 30, 2, 2, "Sword", 1);
        all_items_objects[2] = new Weapon(3, 40, 3, 3, "Sword", 2);

        all_items_objects[3] = new Weapon(1, 20, 1, 1, "Gun", 3);
        all_items_objects[4] = new Weapon(2, 30, 2, 2, "Gun", 4);
        all_items_objects[5] = new Weapon(3, 40, 3, 3, "Gun", 5);

        all_items_objects[6] = new Weapon(1, 20, 1, 1, "Bomb", 6);
        all_items_objects[7] = new Weapon(2, 30, 2, 2, "Bomb", 7);
        all_items_objects[8] = new Weapon(3, 40, 3, 3, "Bomb", 8);
        
    }

    private void unlock_item(int index){

        Weapon item = all_items_objects[index];

        item.locked = false;

        int item_level = item.level;
        int item_damage = item.damage;
        string item_name = item.get_full_weapon_type();
        int item_index = item.index;

        inventoryMenu.GetComponentsInChildren<Transform>()[(item_index + 1) * 5].GetComponent<Text>().text = item_name;
        inventoryMenu.GetComponentsInChildren<Transform>()[(item_index + 1) * 5 + 1].GetComponent<Text>().text = "Damage: " + item_damage.ToString();
        inventoryMenu.GetComponentsInChildren<Transform>()[(item_index + 1) * 5 + 2].GetComponent<Text>().text = "Level: " + item_level.ToString();
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

            if(Input.GetKey(KeyCode.Escape))
            {
                inventory.SetActive(false);
                animation_controller.SetBool("inMenu", false);
            }
            
        }
        else
        {
            inventoryMenu.SetActive(false);
        }

        if(Input.GetKey(KeyCode.G)){   
            toggle_gun_sword(true);
        }

        if(Input.GetKey(KeyCode.S)){   
            toggle_gun_sword(false);
        }
    }

    private void toggle_gun_sword(bool toggle){

        if(toggle){
            basicSword.SetActive(false);
            basicGun.SetActive(true);
        }else{
            basicSword.SetActive(true);
            basicGun.SetActive(false);
        }
        
    }


}



class Weapon : MonoBehaviour
{
    public string[] weapon_types = {"Basic", "Advanced", "Master"};
    public int level; // 1-3
    public int damage; // 0 - 100
    public int ammo; // 0 - 100
    public int maxAmmo; // 100
    public string type; // bomb, sword, gun
    public bool locked = true;
    public int index;

    public Weapon(int level, int damage, int ammo, int maxAmmo, string type, int index)
    {
        this.level = level;
        this.damage = damage;
        this.ammo = ammo;
        this.maxAmmo = maxAmmo;
        this.type = type;
        this.index = index;
    }


    public string get_weapon_type(){
        return weapon_types[level - 1];
    }

    public string get_full_weapon_type(){
        return get_weapon_type() + " " + type;
    }
}
