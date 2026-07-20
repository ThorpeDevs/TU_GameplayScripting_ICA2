// using System;
// using UnityEngine;
// using UnityEngine.Events;
//
// public class KeyHandler : MonoBehaviour
// {
//     [SerializeField] private CameraBehaviour cameraBehaviour;
//     [SerializeField] private GameObject doorCameraHolder;
//     [SerializeField] private GameObject door;
//     
//     private void OnCollisionEnter2D(Collision2D colRef)
//     {
//         if (colRef.gameObject.GetComponent<PlayerMovement>())
//         {
//             cameraBehaviour.CallOpenDoor(gameObject, doorCameraHolder, door);
//         }
//         else
//         {
//             Debug.Log(colRef.gameObject.name);
//         }
//     }
// }
