using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] Transform m_playersTransform;
    NavMeshAgent m_agent;

    void Start(){
        m_agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        m_agent.Move(m_playersTransform.position);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Sword"))
        {
            gameObject.SetActive(false);
        }
    }
}
