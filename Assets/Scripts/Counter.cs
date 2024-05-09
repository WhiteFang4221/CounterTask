using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    private int _currentValue = 0;
    private WaitForSeconds _delay = new WaitForSeconds(0.5f);
    private bool _isCounting = false;
    private Coroutine _counterCoroutine;

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
            _counterCoroutine = 
            _counterCoroutine = StartCoroutine(IncreaseCounter());
        }
        else
        {
            _isCounting = false;

            if (_counterCoroutine != null)
            {
                StopCoroutine(_counterCoroutine);
                _counterCoroutine = null;
            }
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
