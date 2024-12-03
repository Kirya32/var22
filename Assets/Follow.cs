using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float MoveSpeed;
    public Transform Player;
    void Aweke()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float step = MoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Player.position, step);
    }

    public void OnMouseDown()
    {
        
    }
}
