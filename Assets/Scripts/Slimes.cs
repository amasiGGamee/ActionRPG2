using UnityEngine;

public class Slimes : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip slash1; // เปลี่ยนให้เป็น AudioClip แทน AudioSource

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword"))
        {
            print("hit");
            audioSource.PlayOneShot(slash1); // ใช้ AudioClip แทน AudioSource
        }
    }
}
