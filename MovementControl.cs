using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    [SerializeField]
    private float Speed = 0.5f;

    [SerializeField]
    private GameObject sparks;

    [SerializeField]
    private GameObject text;

    private Transform thisTransform;
    private int count;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        thisTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var horizontalAxis = Input.GetAxis("Horizontal");
        var verticalAxis = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(
            horizontalAxis * Speed * Time.deltaTime,
            0.0f,
            verticalAxis * Speed * Time.deltaTime);

        thisTransform.Translate(move);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            if (count == 3)
            {
                sparks.SetActive(true);
                text.SetActive(true);
            }
        }
    }


}