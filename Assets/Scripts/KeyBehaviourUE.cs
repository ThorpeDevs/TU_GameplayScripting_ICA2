using System;
using UnityEngine;
using UnityEngine.Events;

public class KeyHandlerUE : MonoBehaviour
{
    [SerializeField] private UnityEvent<DoorInfo> _onOpenDoor;
    [SerializeField] private DoorInfo _doorInfo;
    
    private void OnCollisionEnter2D(Collision2D colRef)
    {
        if (colRef.gameObject.TryGetComponent(out  SimplePlayerMovement _))
        {
            _onOpenDoor?.Invoke(_doorInfo);
        }
        else
        {
            Debug.Log(colRef.gameObject.name);
        }
    }
}

[Serializable]
public struct DoorInfo
{
    public GameObject key;
    public GameObject doorCameraHolder;
    public GameObject door;
}