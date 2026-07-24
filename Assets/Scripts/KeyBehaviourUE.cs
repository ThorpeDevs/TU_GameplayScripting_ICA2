using System;
using UnityEngine;
using UnityEngine.Events;

public class KeyHandlerUE : MonoBehaviour
{
    [Header("Door Stuff")]
    [SerializeField] private UnityEvent<DoorInfo> _onOpenDoor;
    [SerializeField] private DoorInfo _doorInfo;

    [Header("Dialouge Trext")]
    [SerializeField] private string[] nameText;
    [SerializeField] private string[] bodyText;
    
    private void OnCollisionEnter2D(Collision2D colRef) // Fires on collison with the collider on the gameObject script is attached to
    {
        if (colRef.gameObject.TryGetComponent(out  SimplePlayerMovement _)) // If the colliding object contains player movement
        {
            _onOpenDoor?.Invoke(_doorInfo); // Invoke the unity event without expecting a return
            DialougeBehaviour.instance.CallDisplayText(nameText, bodyText); // Send Dialouge Text To Dialouge Handler
        }
        else
        {
            Debug.Log(colRef.gameObject.name); // Debug print incase something else collides
        }
    }
}

[Serializable]
public struct DoorInfo //Allows for multiple object references to be sent within a unity event
{
    public GameObject key;
    public GameObject doorCameraHolder;
    public GameObject door;
    public GameObject roomLighting;
}