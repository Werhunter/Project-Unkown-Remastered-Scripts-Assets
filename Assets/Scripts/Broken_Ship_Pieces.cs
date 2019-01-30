using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken_Ship_Pieces : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    private Rigidbody2D rigid2D;

    void Start()
    {
      rigid2D = this.gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        speed = Random.Range(1 , 3);

        rigid2D.AddForce(Random.insideUnitCircle * speed);
    }
}
