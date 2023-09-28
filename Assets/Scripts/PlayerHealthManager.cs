using UnityEngine;
using Random = UnityEngine.Random;


public class PlayerHealthManager : MonoBehaviour
{
    [Header("Health")] 
    public int lives = 3;
    public int maxLives = 3;

    [Header("IFrames")] 
    public bool canTakeDamage;
    public float canTakeDamageTime = 0.2f;
    public float canTakeDamageCounter;

    private AudioSource _audioSource;
    public AudioClip[] hurtClips;
    public AudioClip[] pickupClips;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.time > canTakeDamageCounter && !canTakeDamage)
        {
            canTakeDamage = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Heart"))
        {
            if (lives >= maxLives) return;
            lives += 1; // lives++;
            _audioSource.PlayOneShot(pickupClips[
                Random.Range(0,pickupClips.Length)]);
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (canTakeDamage && other.CompareTag("Enemy"))
        {
            lives -= 1;
            _audioSource.PlayOneShot(hurtClips[
                Random.Range(0,hurtClips.Length)]);
            if (lives <= 0)
            {
                // Reload Scene
            }
            canTakeDamage = false;
            canTakeDamageCounter = Time.time + canTakeDamageTime;
        }
    }
}