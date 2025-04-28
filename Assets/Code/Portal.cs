using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour {
    [SerializeField] protected Transform _targetPosition;
    [SerializeField] protected HashSet<GameObject> _objectsInPortal;

    private void Start(){
        _objectsInPortal = new HashSet<GameObject>();
    }

    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player") && !_objectsInPortal.Contains(other.gameObject)){
            other.gameObject.transform.position = _targetPosition.position;
            _objectsInPortal.Add(other.gameObject);
            Debug.Log("AHHHHHHHHHHHHHHHHHHH");
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            _objectsInPortal.Remove(other.gameObject);
        }
    }
}
