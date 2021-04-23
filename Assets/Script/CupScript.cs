using UnityEngine;

public class CupScript : MonoBehaviour
{
    private SphereCollider sphere;

    private bool isColliding;

    GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        sphere = GetComponent<SphereCollider>();
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        isColliding = false;
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(sphere.bounds.center, sphere.radius);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.name.Contains("Sphere").Equals(true))
            {
                if (isColliding == false)
                {
                    print(hitColliders.Length);
                    isColliding = true;
                    gameController.AddPoint();
                    gameController.RemoveCup(this.transform.parent.name);
                }
            }
        }

        if (gameController.pingPongBall == null)
        {
            isColliding = false;
        }
    }
}
