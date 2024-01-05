using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Kecepatan pergerakan

    void Update()
    {
        // Mendapatkan input dari sumbu horizontal dan vertikal
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Menentukan arah pergerakan
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Menggerakkan objek
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
