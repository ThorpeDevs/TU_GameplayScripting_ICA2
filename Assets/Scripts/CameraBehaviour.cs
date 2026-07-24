using System;
using System.Collections;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraBehaviour : MonoBehaviour
{
    [Header("Required References")]
    [SerializeField] private GameObject playerFocusPoint;
    
    private CinemachineCamera cinemachineCamera;
    
    public void CallOpenDoor(DoorInfo doorInfo)
    {
        // Start OpenDoor In a New Thread
        StartCoroutine(OpenDoor(doorInfo.key, doorInfo.doorCameraHolder, doorInfo.door, doorInfo.roomLighting));
    }
    
    private void Start()
    {
        // Get Cinemachine At Start
        cinemachineCamera = gameObject.GetComponent<CinemachineCamera>();
    }

    IEnumerator OpenDoor(GameObject key, GameObject doorCameraHolder, GameObject door, GameObject roomLighting)
    {
        TilemapRenderer _tilemapRenderer = door.GetComponent<TilemapRenderer>();
        // Hide key (Indicated Pickup)
        key.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        // Move Camera To Door
        cinemachineCamera.Follow = doorCameraHolder.transform;
        yield return new WaitForSeconds(0.5f);
        // Hide Door
        _tilemapRenderer.enabled = false;
        roomLighting.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        // Set Back To Player
        cinemachineCamera.Follow = playerFocusPoint.transform;
        // Disable Door
        door.SetActive(false);
    }
}
