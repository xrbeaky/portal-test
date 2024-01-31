using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Transform receiver;

    bool isPlayer = false;

    void LateUpdate()
    {
        if (isPlayer)
        {
            Debug.Log("Player detected");
            Vector3 portalToPlayer = player.position - transform.position;

            if(Vector3.Dot(transform.up, portalToPlayer) < 0f)
            {
                Debug.Log("teleported");
                float rotationDiff = -Quaternion.Angle(transform.rotation, receiver.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = receiver.position + positionOffset;

                isPlayer = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isPlayer = false;
        }
    }
}
