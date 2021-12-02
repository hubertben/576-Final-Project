using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class close_inventory_menu : MonoBehaviour
{
    public Animator player_animcon;

    // Update is called once per frame
    public void closeMenu()
    {
        player_animcon.SetBool("inMenu", false);
    }
}
