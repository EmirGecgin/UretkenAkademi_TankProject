using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private RaycastHit hit;
    [SerializeField] private GameObject _sniper;
    void Update()
    {
        Movement();
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
    void Movement()
    {
        float horizontalMovement = Input.GetAxis("Horizontal")*_speed*Time.deltaTime;
        float verticalMovement = Input.GetAxis("Vertical") * _speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(horizontalMovement,0,verticalMovement);
        }    
    }

    void Fire()
    { 
        if (Physics.Raycast(_sniper.transform.position, transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
