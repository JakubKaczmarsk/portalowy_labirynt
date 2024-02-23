using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamers : MonoBehaviour
{
    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    private void Update()
    {
        PortalCameraController();
    }

    private void PortalCameraController()
    {
        Vector3 playerOffFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffFromPortal;

        float angularDiffrenceBetweenPortalRotations = Quaternion.Angle(portal.rotation, otherPortal.rotation);

        Quaternion portalRotationDiffrence = Quaternion.AngleAxis(angularDiffrenceBetweenPortalRotations, Vector3.up);

        Vector3 newCameraDirection = portalRotationDiffrence * playerCamera.forward;

        newCameraDirection = new Vector3(newCameraDirection.x * -1, newCameraDirection.y, newCameraDirection.z * -1);

        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
