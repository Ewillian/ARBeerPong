using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform shotPos;
    public float shotForce = 1000f;
    public float moveSpeed = 50f;
    GameController gameController;
    Rigidbody shot;
    private bool hasChangedTurn = false;
    private GameObject imageTarget;

    void Start()
    {
        imageTarget = GameObject.FindGameObjectWithTag("ImageTarget");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        if(shot == null && !hasChangedTurn)
        {
            gameController.NextTurn();
            gameController.LoadCups();
            hasChangedTurn = true;
        }
    }

    public void Fire()
    {
        // Shoot one by one
        if (shot != null) return;

        float h = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        transform.Translate(new Vector3(h, v, 0f), Space.Self);

        if (Input.GetButtonUp("Fire1"))
        {
            shot = Instantiate(projectile, shotPos.position, shotPos.rotation) as Rigidbody;
            shot.transform.SetParent(imageTarget.transform);
            shot.AddForce(shotPos.forward * shotForce);

            gameController.pingPongBall = shot.gameObject;

            Destroy(shot.gameObject, 6f);

        }

        hasChangedTurn = false;
    }
}