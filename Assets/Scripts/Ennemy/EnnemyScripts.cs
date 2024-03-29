﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyScripts : MonoBehaviour {

    //// Use this for initialization
    //void Start () {

    //}

    //// Update is called once per frame
    //void Update () {

    //}
    public float speed = 4;
    public float healt = 100;
    private Transform player;
    Animator anim;

    public GameObject prefab;

    public void TakeDamage(int amount = 30)
    {
        healt -= amount;
        if (healt <= 0)
        {
            GameObject.Destroy(gameObject);
            //Instantiate(prefab, transform.position, transform.rotation, GameObject.Find("WorldMap").transform);
            Instantiate(prefab, transform.position, transform.rotation);//, GameObject.Find("WorldMap").transform
        }
       
    }

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position)< 3)//player.transform.position <= 
        {
            anim.SetTrigger("Attack");
        }
    }
    void FixedUpdate()
    {
        float z = Mathf.Atan2((player.transform.position.y - transform.position.y), (player.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
        transform.eulerAngles = new Vector3(0, 0, z);
        //rigidbody2D.angularVelocity = 0;
        Rigidbody2D rigibdy = gameObject.GetComponent("Rigidbody2D") as Rigidbody2D;
        rigibdy.AddForce(gameObject.transform.up * speed);
    }

}
