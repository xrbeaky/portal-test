using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform thisPortal;
    [SerializeField] Transform otherPortal;
    
    void LateUpdate()
    {
        Vector3 playerOffset = playerCamera.position - otherPortal.position;
        transform.position = thisPortal.position + playerOffset;

        float angleDiff = Quaternion.Angle(thisPortal.rotation, otherPortal.rotation);
        
        Quaternion portalRotDiff = Quaternion.AngleAxis(angleDiff, Vector3.up);
        Vector3 newDirection = portalRotDiff * new Vector3(-playerCamera.forward.x, playerCamera.forward.y, -playerCamera.forward.z);

        transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
    }
}
