﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int damage = 1;
    public float speed;

    private Shake shake;
    public GameObject effect;

    private void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) {
            shake.CamShake();
            Instantiate(effect, transform.position, Quaternion.identity);

            other.GetComponent<PlayerController>().health -= damage;
            Debug.Log(other.GetComponent<PlayerController>().health);
            Destroy(gameObject);
        }
    }
}
