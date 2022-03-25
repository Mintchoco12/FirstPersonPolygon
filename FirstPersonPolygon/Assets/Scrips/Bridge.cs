using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public GameObject txtToDisplay;   
    private bool playerInZone;                  
    public GameObject bridge;

    private void Start()
    {
        playerInZone = false;            
        txtToDisplay.SetActive(false);
    }

    private void Update()
    {
        //If player is in zone and "E" is pressed
        if (playerInZone && Input.GetKeyDown(KeyCode.E))          
        {
            //Play button animation and sound
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Animator>().Play("switch");
            //Start Coroutine for spawning bridge
            StartCoroutine(SpawnBridge());
        }
    }

    IEnumerator SpawnBridge()
    {
        yield return new WaitForSeconds(0.5f);
        //Activate bridge
        bridge.SetActive(!bridge.activeSelf);
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player is in zone
        if (other.gameObject.tag == "Player")     
        {
            //Show text
            txtToDisplay.SetActive(true);
            playerInZone = true;
        }
    }


    private void OnTriggerExit(Collider other)    
    {
        //If player exits zone
        if (other.gameObject.tag == "Player")
        {
            //Disable text
            playerInZone = false;
            txtToDisplay.SetActive(false);
        }
    }
}