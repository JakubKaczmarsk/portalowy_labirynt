using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal otherPortal;
    public Material material;

    private Transform portalCollider;
    private Transform renderSurface;
    private Camera myCamera;

    private GameObject player;
    private PortalTeleport portalTeleport;
    private PortalCamers portalCamera;

    private void Awake()
    {
        myCamera = gameObject.transform.Find("PortalCamera").GetComponent<Camera>();
        renderSurface = gameObject.transform.Find("RenderSurface");
        portalCollider = gameObject.transform.Find("Colider");

        player = GameObject.FindGameObjectWithTag("Player");

        portalTeleport = portalCollider.GetComponent<PortalTeleport>();
        portalTeleport.player = player.transform;
        portalTeleport.receiver = otherPortal.portalCollider;

        portalCamera = myCamera.GetComponent<PortalCamers>();
        portalCamera.playerCamera = player.GetComponentInChildren<Camera>().transform;
        portalCamera.portal = transform;
        portalCamera.otherPortal = otherPortal.transform;

        renderSurface.GetComponent<Renderer>().material = Instantiate(material);
        if (myCamera.targetTexture != null)
        {
            myCamera.targetTexture.Release();
        }
        myCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);

    }
    private void Start()
    {
        renderSurface.GetComponent<Renderer>().material.mainTexture = otherPortal.GetComponent<Portal>().myCamera.targetTexture;
    }
}