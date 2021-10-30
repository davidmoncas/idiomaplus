using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Controls the rotation of the camera with the mouse
/// </summary>
public class CameraMovement : MonoBehaviour
{

    Vector2 mouseInitialPos;
    Quaternion cameraInitialPos;

    Vector3 initialPositionRelativeToPlayer;

    [SerializeField] Transform player;
    [SerializeField] float cameraSensitivity;

    public bool windowOpened;

    void Start()
    {
        mouseInitialPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        cameraInitialPos = transform.rotation;

        //set the initial positions
        initialPositionRelativeToPlayer = player.position - transform.position;

    }


    void Update()
    {
        if (windowOpened) return;
        float mouseDeltaX = mouseInitialPos.x - Input.mousePosition.x;
        float mouseDeltaY = mouseInitialPos.y - Input.mousePosition.y;

        float yRotation = Mathf.Lerp( 20, 40 , (mouseDeltaY + Screen.height /2) / (Screen.height/2 ) );

        transform.rotation = cameraInitialPos * Quaternion.Euler(yRotation , mouseDeltaX * cameraSensitivity, 0);

        this.transform.position = player.position + initialPositionRelativeToPlayer;
    }
}
