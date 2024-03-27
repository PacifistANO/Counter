using System.Collections;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text _counterText;

    private int _counterValue;
    private float _delayBetweenIncrease = 0.5f;
    private bool _isCounterStarted;
    private WaitForSeconds _waitingTime;

    private void Start()
    {
        _counterValue = 0;
        _isCounterStarted = false;
        _waitingTime = new WaitForSeconds(_delayBetweenIncrease);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (_isCounterStarted == false)
            {
                _isCounterStarted = true;
                StartCoroutine(IncreaseCounter());
            }
            else
            {
                _isCounterStarted = false;
            }
        }
    }

    private IEnumerator IncreaseCounter()
    {
        while (_isCounterStarted == true)
        {
            _counterValue++;
            _counterText.text = _counterValue.ToString();
            yield return _waitingTime;
        }
    }
}
