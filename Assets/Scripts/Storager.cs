using UnityEngine;
using System;

public class Storager : MonoBehaviour
{
    [SerializeField] private ObjectPool _pool;

    private int _countBoxes;

    public event Action<int> CountBoxesChanged;

    private void Start()
    {
        _countBoxes = 0;
    }

    private void AddBox()
    {
        _countBoxes++;
        CountBoxesChanged?.Invoke(_countBoxes);
    }

    public void PutUp(Worker worker, Box box)
    {
        worker.Reset();
        box.Reset();
        _pool.PutObject(box);
        AddBox();
    }  
}
