using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private AsteroidData data;
    [Tooltip("Взрыв астероида")]
    [SerializeField]private GameObject explosions;

    public void Init(AsteroidData _data)
    {
        data = _data;
        GetComponent<SpriteRenderer>().sprite = data.mainSprite;
    }
    public float Speed
    {
        get { return data.speed; }
        protected set { }
    }
    public float Rotation
    {
        get { return data.rotation; }
        protected set { }
    }

    public static Action<GameObject> onAsteroidOverFly;

    private void FixedUpdate()
    {
        transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0, - data.speed);
        transform.Rotate(Vector3.back * data.rotation);
        if (transform.position.y < -10f && onAsteroidOverFly != null)
            onAsteroidOverFly(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        GameController.asteroidsCount++;
        Instantiate(explosions, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
