using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemies/Standart Enemy", fileName = "New Enemy")]
public class AsteroidData : ScriptableObject
{

    [Tooltip("Основной спрайт")]
    public Sprite mainSprite;

    [Tooltip("Скорость астероида ")]
    public float speed;

    [Tooltip("Скорость вращения астероида ")]
    public float rotation;

}
