using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] Transform m_playerTransform;
    NavMeshAgent m_agent;
    Animator m_animator;
    [SerializeField] protected GameObject _enemy;

    private void Start() {
        m_agent = GetComponent<NavMeshAgent>();
        m_animator = GetComponent<Animator>();
        m_animator.enabled = true;
    }

    private void Update() {
        //if (m_agent.isActiveAndEnabled)
        //{
        //    m_agent.SetDestination(m_playerTransform.position);
        //}
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Sword")) {
            //gameObject.SetActive(false);
            m_agent.enabled = false;
            m_animator.enabled = false;
            StartCoroutine(DeactivateEnemy());
        }
    }

    protected IEnumerator DeactivateEnemy()
    {
        yield return new WaitForSeconds(2.0f);

        GameObject newEnemy = ObjectPool.instance.GetPooledEnemy();
        if (newEnemy != null)
        {
            newEnemy.SetActive(true);
        }

        _enemy.SetActive(false);
    }
}
