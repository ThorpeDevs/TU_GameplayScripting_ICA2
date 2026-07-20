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
        StartCoroutine(OpenDoor(doorInfo.key, doorInfo.doorCameraHolder, doorInfo.door));
    }
    
    private void Start()
    {
        cinemachineCamera = gameObject.GetComponent<CinemachineCamera>();
    }

    IEnumerator OpenDoor(GameObject key, GameObject doorCameraHolder, GameObject door)
    {
        TilemapRenderer _tilemapRenderer = door.GetComponent<TilemapRenderer>();
        
        key.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        cinemachineCamera.Follow = doorCameraHolder.transform;
        yield return new WaitForSeconds(0.5f);
        _tilemapRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        cinemachineCamera.Follow = playerFocusPoint.transform;
        door.SetActive(false);
    }
}
