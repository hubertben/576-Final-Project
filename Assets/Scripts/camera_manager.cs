using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_manager : MonoBehaviour
{
    public GameObject Player;

    //cameras
    public GameObject BackCam;
    public GameObject FPSCam;

    //weapons
    public GameObject BasicSword;
    public GameObject AdvancedSword;
    public GameObject MasterSword;

    public GameObject BasicGun;
    public GameObject AdvancedGun;
    public GameObject MasterGun;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        switch(getPlayerCameraMode())
        {
            case 0:
                BackCam.SetActive(true);
                FPSCam.SetActive(false);
                break;
            case 1:
                BackCam.SetActive(false);
                FPSCam.SetActive(true);
                break;
        }
    }

    int getPlayerCameraMode()
    {
        if (BasicSword.activeInHierarchy) //expand if-statement to include other tiers of same weapon
            return 0;
        else if (BasicGun.activeInHierarchy || AdvancedGun.activeInHierarchy || MasterGun.activeInHierarchy)
            return 1;
        else //expand this to include different types of weapons
            return 2;
    }
}
