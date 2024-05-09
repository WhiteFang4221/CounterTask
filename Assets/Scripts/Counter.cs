using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    private int _currentValue = 0;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private bool _isCounting = false;

    private void Start()
    {
        _counter.text = ($"—четчик: {_currentValue}");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeCounterState();
        }
    }

    private void ChangeCounterState()
    {
        if (_isCounting == false)
        {
            _isCounting = true;
            StartCoroutine(nameof(IncreaseCounter));
        }
        else if (_isCounting == true)
        {
            _isCounting = false;
            StopCoroutine(nameof(IncreaseCounter));
        }
    }

    private IEnumerator IncreaseCounter()
    {
        while (true)
        {
            _counter.text = ($"—четчик: {++_currentValue}");

            yield return _delay;
        }
    }
}
