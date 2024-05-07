using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;
    private float _delay = 0.5f;
    private int _currentValue = 0;
    private bool _isCounting = false;

    private void Start()
    {
        _counter.text = ($"—четчик: {_currentValue}");
        StartCoroutine(nameof(ChangeCounter));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isCounting = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _isCounting = false;
        }
    }


    private IEnumerator ChangeCounter()
    {
        while (true)
        {
            if (_isCounting)
            {
                _counter.text = ($"—четчик: {++_currentValue}");
            }

            yield return new WaitForSeconds(_delay);
        }
    }
}
