using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private Transform _targetScan;
    [SerializeField] private float _delay;

    private Queue<Transform> _boxesPosition;

    public int BoxCountDetected => _boxesPosition.Count;

    private void Start()
    {
        _boxesPosition = new Queue<Transform>();
        StartCoroutine(Scanning());
    }

    private void Scan()
    {
        int countBoxes = _targetScan.childCount;

        for (int i = 0; i < countBoxes; i++)
        {
            if (_targetScan.GetChild(i).GetComponent<Box>().IsDetected == false && _targetScan.GetChild(i).GetComponent<Box>().isActiveAndEnabled)
            {
                _targetScan.GetChild(i).GetComponent<Box>().SetDetected();
                _boxesPosition.Enqueue(_targetScan.GetChild(i));
            }
        }
    }

    public Transform GetObject()
    {
        if (BoxCountDetected == 0)
            return null;

        return _boxesPosition.Dequeue();
    }

    private IEnumerator Scanning()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Scan();
            yield return wait;
        }
    }
}
