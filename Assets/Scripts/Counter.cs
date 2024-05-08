using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counter;

    private int _currentValue = 0;
    private WaitForSeconds _delay = new WaitForSeconds (0.5f);
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
            _isCounting = !_isCounting;
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

            yield return _delay;
        }
    }
}
