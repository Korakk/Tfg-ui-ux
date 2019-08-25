using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderFollower : MonoBehaviour
{
    [SerializeField] Transform target;

    Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidbody.MovePosition(target.position);
        rigidbody.MoveRotation(target.rotation);
    }
}
