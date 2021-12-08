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
        if (GameObject.FindWithTag("sword") || GameObject.FindWithTag("bomb") )
            return 0;
        return 1;
    }
}
