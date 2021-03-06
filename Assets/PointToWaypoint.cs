﻿using System.Collections;
using System.Collections.Generic;
using behavior.Player;
using UnityEngine;

public class PointToWaypoint : MonoBehaviour
{
    public MoveAlongWaypoints waypointKnower;
    // Start is called before the first frame update
    void Start()
    {
        waypointKnower = GetComponentInParent<MoveAlongWaypoints>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.right = waypointKnower.direction;
    }
}
