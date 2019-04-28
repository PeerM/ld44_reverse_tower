using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace behavior.Player
{
    public class MoveAlongWaypoints : MonoBehaviour
    {
        public Transform trackParent;
        public IList<Transform> children = new List<Transform>();
        public Transform target;
        public float speed = 1;
        public float close_enough = 0.5f;
        private Rigidbody2D body;
        public Vector3 direction => target.position - transform.position;

        // Start is called before the first frame update
        void Start()
        {
        }

        void Awake()
        {
            body = GetComponent<Rigidbody2D>();
            foreach (Transform child in trackParent)
            {
                children.Add(child);
                // do whatever you want with child transform object here
            }

            target = children.First();
            children.RemoveAt(0);
        }

        private void updateTarget()
        {
            if ((target.position - transform.position).magnitude < close_enough)
            {
                if (children.Count > 0)
                {
                    target = children.First();
                    children.RemoveAt(0);
                }
                else
                {
                    //this.enabled = false;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            var limited_direction = direction;
            if (limited_direction.z != 0)
                Debug.LogError("object is moving out of plane");
            if (limited_direction.magnitude > 1)
            {
                limited_direction = direction.normalized;
            }

            
            body.MovePosition( transform.position + limited_direction * speed * Time.deltaTime); //TODO move to nice physics
//            transform.Translate(direction * speed * Time.deltaTime, Space.World);
            updateTarget();
        }
    }
}