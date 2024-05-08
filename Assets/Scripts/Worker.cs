using System;
using UnityEngine;

[RequireComponent(typeof(Getter))]
[RequireComponent(typeof(Mover))]
public class Worker : MonoBehaviour
{
    private Getter _getter;
    private Mover _mover;

    private bool _isWork = false;

    public event Action<Transform> TargetReceived;
    public bool IsWork => _isWork;

    private void Start()
    {
        _getter = GetComponent<Getter>();
        _mover = GetComponent<Mover>();
    }

    public void GetTarget(Transform target)
    {
        TargetReceived?.Invoke(target);
        _isWork = true;
    }

    public void Reset()
    {
        _isWork = false;
        _getter.Reset();
        _mover.Reset();
    }
}
