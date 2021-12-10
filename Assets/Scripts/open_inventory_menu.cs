using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class open_inventory_menu : MonoBehaviour
{

   
    public int[] unlocks = {0, 0, 0, 0, 0, 0, 0, 0, 0};
    public Button basicSword_button;
    public Button basicGun_button;
    public Button basicBomb_button;
    public Button advancedSword_button;
    public Button advancedGun_button;
    public Button advancedBomb_button;
    public Button masterSword_button;
    public Button masterGun_button;
    public Button masterBomb_button;

    private int temp_index = 0;

    public Canvas canvas;
    public GameObject inventoryMenu;
    public GameObject interactionInstructions;
    public GameObject inventory;
    public GameObject chooseMenu;
    public GameObject inventorySpot;
    private Animator animation_controller;
    private string[] all_items = {"BasicSword", "AdvancedSword", "MasterSword", "BasicGun", "AdvancedGun", "MasterGun", "BasicBomb", "AdvancedBomb", "MasterBomb"};
    private Weapon[] all_items_objects;
    private string[] selected_items = new string[9];
    private Weapon selected_item;
    private int selected_item_index = 0;
    private Weapon current_item;

    public int player_level = 1;

    public GameObject basicSword;
    public GameObject basicGun;
    public GameObject basicBomb;   

    public GameObject advancedSword;
    public GameObject advancedGun;
    public GameObject advancedBomb;

    public GameObject masterSword;
    public GameObject masterGun;
    public GameObject masterBomb;



    public GameObject BP_health_spawn_rate;
    public GameObject BP_health_inc;
    public GameObject BP_speed_inc;
    public GameObject BP_damage_inc;

    public Weapon currentWeapon;
    

    public bool gLOCK = false;

    private void Start()
    {   
        if(!gLOCK){
            inventoryMenu = GameObject.Find("InventoryMenu");
            animation_controller = GetComponent<Animator>();
            init_canvas();
            init_weapons();
            init_buttons();
            gLOCK = true;
        }

        currentWeapon = all_items_objects[0];
    }

    private void init_buttons(){
        Button btn = basicSword_button.GetComponent<Button>();
	    btn.onClick.AddListener(() => {
            activate_weapon(basicSword);
        });

        btn = basicGun_button.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            activate_weapon(basicGun);
        });

        btn = basicBomb_button.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            activate_weapon(basicBomb);
        });

        btn = advancedSword_button.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            activate_weapon(advancedSword);
        });

        btn = advancedGun_button.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            activate_weapon(advancedGun);
        });

        btn = advancedBomb_button.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            activate_weapon(advancedBomb);
        });

        btn = masterSword_button.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            activate_weapon(masterSword);
        });
 
        btn = masterGun_button.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            activate_weapon(masterGun);
        });

        btn = masterBomb_button.GetComponent<Button>();
        btn.onClick.AddListener(() => {
            activate_weapon(masterBomb);
        });
    }

    


    private void init_canvas(){

        int[] name_indicies = {5, 10, 15, 20, 25, 30, 35, 40, 45};
        int[] damage_indicies = {6, 11, 16, 21, 26, 31, 36, 41, 46};
        int[] level_indicies = {7, 12, 17, 22, 27, 32, 37, 42, 47};
        int[] unlock_indicies = {8, 13, 18, 23, 28, 33, 38, 43, 48};

        for(int i = 0; i < 9; i++){
            inventoryMenu.GetComponentsInChildren<Transform>()[name_indicies[i]].GetComponent<Text>().text = "Locked";
            inventoryMenu.GetComponentsInChildren<Transform>()[damage_indicies[i]].GetComponent<Text>().text = "???";
            inventoryMenu.GetComponentsInChildren<Transform>()[level_indicies[i]].GetComponent<Text>().text = "???";
        }
    }


    public float current_health_spawn_rate = 0.5f;
    public float current_health_spawn_rate_increase = 0.5f;
    public float damage = 0.5f;
    public float player_movement_inc = 0f;
    public float player_movement_base = 5f;
    public float player_movement_total = 5f;

    public void update_return_values(){

        damage = currentWeapon.damage;
        player_movement_total = player_movement_base + player_movement_inc;


    }
    public float[] get_player_stats(){
        update_return_values();
        float[] stats = {0, 0, 0, 0};
        stats[0] = current_health_spawn_rate; //  1-7
        stats[1] = damage;
        stats[2] = current_health_spawn_rate_increase;
        stats[3] = player_movement_total;
        return stats;
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

    public List<Weapon> get_shop_weapons(){
        List<Weapon> shop_weapons = new List<Weapon>();
        for(int i = 0; i < all_items_objects.Length; i++){
            if(all_items_objects[i].level == player_level && all_items_objects[i].locked == true){
                shop_weapons.Add(all_items_objects[i]);
            }
        }
        return shop_weapons;
    }



    public void unlock_item(int index){

        if(!gLOCK){
            inventoryMenu = GameObject.Find("InventoryMenu");
            animation_controller = GetComponent<Animator>();
            init_canvas();
            init_weapons();
            init_buttons();
            gLOCK = true;
        }

        Weapon item = all_items_objects[index];
        Debug.Log("unlocking item: " + item.get_full_weapon_type() + " at index: " + index);
        item.locked = false;

        int item_level = item.level;
        int item_damage = item.damage;
        string item_name = item.get_full_weapon_type();
        int item_index = item.index;

        Debug.Log((item_index + 1) * 5);
        Debug.Log((item_index + 1) * 5 + 1);
        Debug.Log((item_index + 1) * 5 + 2);
        Debug.Log((item_index + 1) * 5 + 3);

        inventoryMenu.GetComponentsInChildren<Transform>()[(item_index + 1) * 5].GetComponent<Text>().text = "Unlocked";
        inventoryMenu.GetComponentsInChildren<Transform>()[(item_index + 1) * 5 + 1].GetComponent<Text>().text = "Damage: " + item_damage.ToString();
        inventoryMenu.GetComponentsInChildren<Transform>()[(item_index + 1) * 5 + 2].GetComponent<Text>().text = "Level: " + item_level.ToString();
        inventoryMenu.GetComponentsInChildren<Transform>()[(item_index + 1) * 5 + 3].GetComponent<Text>().text = item_name;
    }

    public void unlock_item_by_string(string s){

        Debug.Log("unlocking item: " + s);

        for(int i = 0; i < all_items_objects.Length; i++){
            if(all_items_objects[i].get_full_weapon_type() == s){
                unlock_item(i);
                break;
            }
        }
    }

    public void writeToFile(){
        string path = "Assets/unlocks.txt";

        // write new lines for every weapon in all_items_objects
        // if the item is locked, write false
        // if the item is unlocked, write true

        string[] lines = new string[9];
        for(int i = 0; i < all_items_objects.Length; i++){
            if(all_items_objects[i].locked == true){
                lines[i] = "false";
            }
            else{
                lines[i] = "true";
            }
        }

        System.IO.File.WriteAllLines(path, lines);

    }

    public void unlock_armor(int index){

    }

    public void update_choose_menu(){
        // updates the choose menu to reflect the current weapon
        chooseMenu = GameObject.Find("ChooseMenu");
        chooseMenu.GetComponent<Text>().text = currentWeapon.get_full_weapon_type();
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

        writeToFile();

    }

    public void change_weapon(){
        Debug.Log("change_weapon");
    }

    private void disable_weapons(){
        basicSword.SetActive(false);
        basicGun.SetActive(false);
        basicBomb.SetActive(false);

        advancedSword.SetActive(false);
        advancedGun.SetActive(false);
        advancedBomb.SetActive(false);

        masterSword.SetActive(false);
        masterGun.SetActive(false);
        masterBomb.SetActive(false);
    }

    private void activate_weapon(GameObject weapon){

        if(weapon.name == "BasicSword" && !all_items_objects[0].locked){
            disable_weapons();
            basicSword.SetActive(true);
            currentWeapon = all_items_objects[0];
        }
        else if(weapon.name == "BasicGun" && !all_items_objects[3].locked){
            disable_weapons();
            basicGun.SetActive(true);
            currentWeapon = all_items_objects[3];
        }
        else if(weapon.name == "BasicBomb" && !all_items_objects[6].locked){
            disable_weapons();
            basicBomb.SetActive(true);
            currentWeapon = all_items_objects[6];
        }
        else if(weapon.name == "AdvancedSword" && !all_items_objects[1].locked){
            disable_weapons();
            advancedSword.SetActive(true);
            currentWeapon = all_items_objects[1];
        }
        else if(weapon.name == "AdvancedGun" && !all_items_objects[4].locked){
            disable_weapons();
            advancedGun.SetActive(true);
            currentWeapon = all_items_objects[4];
        }
        else if(weapon.name == "AdvancedBomb" && !all_items_objects[7].locked){
            disable_weapons();
            advancedBomb.SetActive(true);
            currentWeapon = all_items_objects[7];
        }
        else if(weapon.name == "MasterSword" && !all_items_objects[2].locked){
            disable_weapons();
            masterSword.SetActive(true);
            currentWeapon = all_items_objects[2];
        }
        else if(weapon.name == "MasterGun" && !all_items_objects[5].locked){
            disable_weapons();
            masterGun.SetActive(true);
            currentWeapon = all_items_objects[5];
        }
        else if(weapon.name == "MasterBomb" && !all_items_objects[8].locked){
            disable_weapons();
            masterBomb.SetActive(true);
            currentWeapon = all_items_objects[8];
        }
    }
}

public class Weapon
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
