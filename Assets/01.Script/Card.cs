using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private TextMeshProUGUI _titleText;
    [SerializeField] private TextMeshProUGUI _descText;

    [SerializeField] private CardDataSo _cardData;

    private void OnValidate()
    {
        if (_cardData != null)
        {
            _image.sprite = _cardData.sprite;
            _titleText.text = _cardData.title;
            _descText.text = _cardData.desc;
        }
    }
}
