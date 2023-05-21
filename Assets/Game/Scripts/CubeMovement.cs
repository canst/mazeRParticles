using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float speed = 5f;
    public ParticleSystem cloneParticlePrefab;

    private void Update()
    {
        // Player movement logic
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Clone creation logic
        if (collision.gameObject.CompareTag("Cube"))
        {
            GameObject clone = Instantiate(gameObject, collision.gameObject.transform.position + Random.insideUnitSphere * 2f, Quaternion.identity);
            clone.GetComponent<Renderer>().material.color = Random.ColorHSV();

            // Play particle effect
            ParticleSystem cloneParticle = Instantiate(cloneParticlePrefab, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(cloneParticle.gameObject, 2f);
        }
    }
}

