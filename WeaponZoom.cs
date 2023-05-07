using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;



public class WeaponZoom : MonoBehaviour
{
    
    [SerializeField] GameObject cinemachineCamera;
    [SerializeField] float zoomedOutFOV = 40f;
    [SerializeField] float zoomedInFOV = 20f;

    


    CinemachineVirtualCamera Cinemachine;
    
    
    
    bool zoomedInToggle = false;


    private void OnDisable() //wylacza zoom podczas zmiany broni
    {
        ZoomOut();
    }

    private void Start()
    {
        
        Cinemachine = cinemachineCamera.GetComponent<CinemachineVirtualCamera>();
       
        
    }

    private void Update()
    {


        if (Input.GetMouseButtonDown(1))
        {
            if (zoomedInToggle == false)
            {
                ZoomIn();

            }
            else
            {
                ZoomOut();

            }
        }
    }

    private void ZoomOut()
    {
        zoomedInToggle = false;
        Cinemachine.m_Lens.FieldOfView = zoomedOutFOV;
    }

    private void ZoomIn()
    {
        zoomedInToggle = true;
        Cinemachine.m_Lens.FieldOfView = zoomedInFOV;
    }
}
