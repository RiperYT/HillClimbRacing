using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pedal : MonoBehaviour
{
    [SerializeField] private Image _thisImage;
    [SerializeField] private Sprite _firstSprite;
    [SerializeField] private Sprite _secondSprite;

    public void Down()
    {
        _thisImage.sprite = _secondSprite;
    }

    public void Up()
    {
        _thisImage.sprite = _firstSprite;
    }

}
