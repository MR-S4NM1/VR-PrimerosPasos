using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform m_playerTransform;
    NavMeshAgent m_agent;

    private void Start() {
        m_agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        m_agent.SetDestination(m_playerTransform.position);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Sword")) {
            gameObject.SetActive(false);
        }
    }
}
