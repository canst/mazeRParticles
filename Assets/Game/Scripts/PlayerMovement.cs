using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public ParticleSystem colorChangeParticlePrefab;
    public ParticleSystem collisionParticlePrefab;
    private Renderer playerRenderer;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
    }

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
        if (collision.gameObject.CompareTag("Cube"))
        {
            // Play collision particle effect
            ParticleSystem collisionParticle = Instantiate(collisionParticlePrefab, collision.contacts[0].point, Quaternion.identity);
            Destroy(collisionParticle.gameObject, 2f);
        }
        else if (collision.gameObject.CompareTag("Capsule") || collision.gameObject.CompareTag("Sphere"))
        {
            // Randomly change cube's color
            playerRenderer.material.color = Random.ColorHSV();

            // Play color change particle effect
            ParticleSystem colorChangeParticle = Instantiate(colorChangeParticlePrefab, collision.contacts[0].point, Quaternion.identity);
            Destroy(colorChangeParticle.gameObject, 2f);

            // Destroy the capsule or sphere
            Destroy(collision.gameObject);
        }
    }
}
