using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlingManager : MonoBehaviour
{
    public static BowlingManager instance;

    [Header("Pines Info")]
    [SerializeField] protected List<Transform> _pinesPositions;
    [SerializeField] protected List<Transform> _pinesOriginalPositions;

    [Header("Ball Infor")]
    [SerializeField] protected GameObject _ball;
    [SerializeField] protected Transform _ballInitialPosition;

    [SerializeField] protected KeyCode _reorderKeyCode = KeyCode.P;

    [SerializeField] protected float _timerTime;

    protected Coroutine _timerCoroutine;

    private void Start()
    {
        Debug.Log("<color='cyan'>Colored message.</color>");
        Debug.Log("<color='cyan'>Ahhhhhhhhhhh.</color>");
    }

    private void Awake()
    {
        if (instance == null) {
            instance = this;
        }
        else{
            Destroy(instance);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(_reorderKeyCode))
        {
            ResetAllBowlingObjPositions();
        }
    }

    public void ResetAllBowlingObjPositions()
    {
        _timerCoroutine = StartCoroutine(TimerToReset());
    }

    protected void ReorderPines()
    {
        int i = 0;
        foreach (Transform pine in _pinesPositions)
        {
            if (pine.position != _pinesOriginalPositions[i].position)
            {
                pine.position =  _pinesOriginalPositions[i].position;
                pine.rotation = _pinesOriginalPositions[i].rotation;
                pine.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                pine.gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                Debug.Log("<color = red/color> Ahhhh");
            }
            i++;
        }
    }

    protected void ResetBallPosition()
    {
        _ball.transform.position = _ballInitialPosition.position;
        _ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    protected IEnumerator TimerToReset()
    {
        yield return new WaitForSeconds(_timerTime);
        ReorderPines();
        ResetBallPosition();
    }
}
