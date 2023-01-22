using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcalcul : MonoBehaviour
{

    public GameObject txtToDisplay;             //display the UI text

    private bool PlayerInZone;                  //check if the player is in trigger
    private bool COCLInZone;

    public GameObject cOcL;
    public GameObject uIobjA;
    public GameObject uIobjD;

    private void Start()
    {
        PlayerInZone = false;                   //player not in zone       
        txtToDisplay.SetActive(false);
        COCLInZone = false;
    }

    private void Update()
    {
        if (PlayerInZone && Input.GetKeyDown(KeyCode.F) && COCLInZone)           //if in zone and press F key
        {
            MoveGameObject();
        }
    }

    private void MoveGameObject()
    {
        cOcL.transform.position = new Vector3(-3.66f, 2.249f, -0.108f);
    }

    private void OnBoalEnter(Collider other)
    {
        if (other.gameObject.tag == "COCL")     //if cocl in zone
        {
            txtToDisplay.SetActive(true);
            COCLInZone = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")     //if player in zone
        {
            txtToDisplay.SetActive(true);
            PlayerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)     //if player exit zone
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }
}