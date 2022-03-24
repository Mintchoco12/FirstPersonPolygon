using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] List<GameObject> checkPoints;
    [SerializeField] Vector3 vectorPoint;
    [SerializeField] float dead;

    void Update()
    {
        if (player.transform.position.y < -dead)
        {
            player.transform.position = vectorPoint;
            Physics.SyncTransforms();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        vectorPoint = player.transform.position;
        //Destroy(other.gameObject);
    }
}