using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    NavMeshAgent follower;
    [SerializeField] private Transform _player;
    private void Start()
    {
        follower = GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        follower.destination = _player.position;
    }
}
