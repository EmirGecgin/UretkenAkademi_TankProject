using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private RaycastHit hit;
    [SerializeField] private GameObject _sniper;
    [SerializeField] private TextMeshProUGUI _numberOfTanks;
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private TextMeshProUGUI _loseText;
    private int tankNumber;
    [SerializeField] private GameObject [] equipmentsOfTank;
    private void Awake()
    {
        tankNumber = 5;
        _numberOfTanks.text = "Number Of Tanks: " + tankNumber.ToString();
    }
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
        WriteTankNumber();
    }
    void Fire()
    { 
        if (Physics.Raycast(_sniper.transform.position, _sniper.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);
                tankNumber--;
                if(tankNumber<=0)
                {
                    _numberOfTanks.gameObject.SetActive(false);
                    _winText.gameObject.SetActive(true);
                    Time.timeScale = 0;
                    
                }
            }
        }
    }
    void WriteTankNumber()
    {
        _numberOfTanks.text = "Number Of Tanks: " + tankNumber.ToString();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            for (int i = 0; i < equipmentsOfTank.Length; i++)
            {
                equipmentsOfTank[i].SetActive(false);
            }
            _loseText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
