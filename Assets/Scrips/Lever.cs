using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public GameObject txtToDisplay;
    private bool playerInZone;

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
            //Play lever animation and quit game
            gameObject.GetComponent<Animator>().Play("lever");
            StartCoroutine(QuitGame());
        }
    }

    //Coroutine for quitting game
    IEnumerator QuitGame()
    {
        //Wait for lever animation to play before quitting
        yield return new WaitForSeconds(0.8f);

        print("GameQuit");
        Application.Quit();
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