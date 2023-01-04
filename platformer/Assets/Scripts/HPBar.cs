using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    [SerializeField] private float _maxHP = 100;
    [SerializeField] private float _hp = 50;
    [SerializeField] private float _changeSpeed = 15;
    [SerializeField] private Slider _slider;

    private float _initialValue;
    private float _normalizedValue;

    private void Start()
    {
        _slider.value = _hp / _maxHP;
    }

    public void AddHP(int value)
    {
        StartCoroutine(AddHealth(value));
    }

    public IEnumerator AddHealth(int value)
    {
        _initialValue = _hp;
        _hp = _initialValue + value;

        if (_hp > _maxHP)
            _hp = _maxHP;
        else if (_hp < 0)
            _hp = 0;

        _normalizedValue = _initialValue / _maxHP;

        while (_normalizedValue != _hp / _maxHP)
        {
            if (_normalizedValue < _hp / _maxHP)
            {
                _initialValue += Time.deltaTime * _changeSpeed;

                if (_initialValue > _hp)
                    _initialValue = _hp;
            }
            else if (_normalizedValue > _hp / _maxHP)
            {
                _initialValue -= Time.deltaTime * _changeSpeed;

                if (_initialValue < _hp)
                    _initialValue = _hp;
            }

            _normalizedValue = _initialValue / _maxHP;

            _slider.value = _normalizedValue;
            yield return null;
        }
    }
}
