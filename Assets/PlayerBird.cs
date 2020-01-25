using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBird : MonoBehaviour
{
    [SerializeField] private float force;
    private Rigidbody rigidbody;
    [SerializeField] private Vector3 startPosition;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    

    public void AddForce()
    {
        rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = -Vector3.up * 1000;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<FloppyAvianGameLoop>().GameEnd();
    }

    internal void Reset()
    {
        rigidbody.velocity = Vector3.zero;
        transform.position = startPosition;
    }
}
