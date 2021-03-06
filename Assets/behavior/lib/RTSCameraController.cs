﻿using UnityEngine;

[RequireComponent(typeof(Camera))]

public class RTSCameraController : MonoBehaviour {

    public float ScreenEdgeBorderThickness = 5.0f; // distance from screen edge. Used for mouse movement

    [Header("Camera Mode")]
    [Space]
    public bool RTSMode = true;
    public bool FlyCameraMode = false;

    [Header("Movement Speeds")]
    [Space]
    public float minPanSpeed;
    public float maxPanSpeed;
    public float secToMaxSpeed; //seconds taken to reach max speed;
    public float zoomSpeed;

    [Header("Movement Limits")]
    [Space]
    public bool enableMovementLimits;
    public Vector2 heightLimit;
    public Vector2 lenghtLimit;
    public Vector2 widthLimit;

    private float panSpeed;
    private Vector3 initialPos;
    private Vector3 panMovement;
    private Vector3 pos;
    private Quaternion rot;
    private Vector3 lastMousePosition;
    private Quaternion initialRot;
    private float panIncrease = 0.0f;



    // Use this for initialization
    void Start () {
        initialPos = transform.position;
        initialRot = transform.rotation;
	}
	
	
	void Update () {

        # region Camera Mode

        //check that ony one mode is choosen
        if (RTSMode == true) FlyCameraMode = false;
        if (FlyCameraMode == true) RTSMode = false;

        # endregion

        #region Movement

            panMovement = Vector3.zero;

            if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - ScreenEdgeBorderThickness)
            {
                panMovement += Vector3.forward * panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= ScreenEdgeBorderThickness)
            {
                panMovement -= Vector3.forward * panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= ScreenEdgeBorderThickness)
            {
                panMovement += Vector3.left * panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - ScreenEdgeBorderThickness)
            {
                panMovement += Vector3.right * panSpeed * Time.deltaTime;
                //pos.x += panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.Q))
            {
                panMovement += Vector3.up * panSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.E))
            {
                panMovement += Vector3.down * panSpeed * Time.deltaTime;
            }

            if(RTSMode) transform.Translate(panMovement, Space.World);
            else if(FlyCameraMode) transform.Translate(panMovement, Space.Self);


        //increase pan speed
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) 
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.E) || Input.GetKey(KeyCode.Q)
            || Input.mousePosition.y >= Screen.height - ScreenEdgeBorderThickness
            || Input.mousePosition.y <= ScreenEdgeBorderThickness
            || Input.mousePosition.x <= ScreenEdgeBorderThickness
            || Input.mousePosition.x >= Screen.width - ScreenEdgeBorderThickness)
        {
            panIncrease += Time.deltaTime / secToMaxSpeed;
            panSpeed = Mathf.Lerp(minPanSpeed, maxPanSpeed, panIncrease);
        }
        else
        {
            panIncrease = 0;
            panSpeed = minPanSpeed;
        }

        #endregion

        #region Zoom

//        Camera.main.fieldOfView -= Input.mouseScrollDelta.y * zoomSpeed;
//        Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView,zoomLimit.x,zoomLimit.y);

        #endregion


        #region boundaries

        if (enableMovementLimits)
        {
            //movement limits
            pos = transform.position;
            pos.y = Mathf.Clamp(pos.y, heightLimit.x, heightLimit.y);
            pos.z = Mathf.Clamp(pos.z, lenghtLimit.x, lenghtLimit.y);
            pos.x = Mathf.Clamp(pos.x, widthLimit.x, widthLimit.y);
            transform.position = pos;
        }
        


        #endregion

    }

}




