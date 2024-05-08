using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Scanner))]
public class WorkersController : MonoBehaviour
{
    private Scanner _scanner;

    private List<Worker> _workers;
    private int _workersCount;

    private void Start()
    {
        _scanner = GetComponent<Scanner>();
        _workersCount = transform.childCount;
        _workers = new List<Worker>(_workersCount);

        for (int i = 0; i < _workersCount; i++)
        {
            _workers.Add(transform.GetChild(i).GetComponent<Worker>());
        }
    }

    private Worker GetFreeWorker()
    {
        foreach (Worker worker in _workers)
        {
            if(!worker.IsWork)
                return worker;
        }

        return null;
    }

    private void Update()
    {
        if (_scanner.BoxCountDetected == 0)
            return;

        if (GetFreeWorker() == null)
            return;

        Worker worker = GetFreeWorker();
        worker.GetTarget(_scanner.GetObject());
    }
}
