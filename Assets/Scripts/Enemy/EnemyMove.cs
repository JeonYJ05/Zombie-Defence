using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using YJ.Zombie.Enemy;

namespace YJ.Zombie.Enemy
{
    public class EnemyMove : MonoBehaviour
    {
        private Transform _player;
        private NavMeshAgent _nav;
        private void Awake()
        {
            _player = GameObject.FindGameObjectWithTag("Player").transform;
            _nav = GetComponent<NavMeshAgent>();
        }
        private void Start()
        {
            GetComponent<EnemyAnimation>().PlayAnimation("Walk");
        }

       // private void Update()
       // {
       //     _nav.SetDestination(_player.position);
       // }
    }
}