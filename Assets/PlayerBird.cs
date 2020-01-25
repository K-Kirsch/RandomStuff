using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBird : MonoBehaviour
{
    [SerializeField] private float force;
    [SerializeField] private Vector3 startPosition;

    public void AddForce()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position = -Vector3.up * 1000;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<FloppyAvianGameLoop>().GameEnd();
    }

    internal void Reset()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = startPosition;
    }
}
