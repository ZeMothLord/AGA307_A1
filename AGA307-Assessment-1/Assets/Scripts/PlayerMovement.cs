using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 5f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    public bool isGrounded;

    [Header("--- Projectile Settings ---")]
    public Transform projectileSpawn;
    public GameObject[] projectilePrefabs;
    public float projectileSpeed = 100f;
    public int projectileLifeTime = 2;
    public int currentWeapon = 0;

    [Header("--- Ray Casting ---")]
    public int rayDistance = 10;
    Ray ray = new Ray();
    RaycastHit rayHit;

    public GameObject sphere;

    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        // Projectile

        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        ChangeWeapon();
    }

    void Shoot()
    {
        GameObject proj = Instantiate(projectilePrefabs[currentWeapon], projectileSpawn.position, projectileSpawn.rotation);
        //porj velocity
        proj.GetComponent<Rigidbody>().velocity = projectileSpawn.forward * projectileSpeed;
        Destroy(proj, projectileLifeTime);
    }

    void ChangeWeapon()
    {
        if (Input.GetKeyDown("1"))
        {
            currentWeapon = 0;
            projectileSpeed = 100f;
        }
        else if (Input.GetKeyDown("2"))
        {
            currentWeapon = 1;
            projectileSpeed = 50f;
        }
        else if (Input.GetKeyDown("3"))
        {
            currentWeapon = 2;
            projectileSpeed = 30f;
        }
    }


    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Trigger"))
        {
            //Increas the spheres scale by 0.01 on all axis
            CastRay();
        }
    }



    public void CastRay()
    {
        ray.origin = transform.position;
        ray.direction = transform.forward;

        if (Physics.Raycast(ray, out rayHit, rayDistance))
        {
            Debug.Log($"raycast is hitting {rayHit.collider.name}");
            //Depending on the tag turn it 
            if (rayHit.collider.tag == "Target")
            {
                Debug.Log("raycast is target");
                rayHit.collider.GetComponent<MeshRenderer>().material.color = Color.red;

                if (Input.GetKey(KeyCode.E))
                {
                    Debug.Log("E detected");
                    sphere.transform.localScale += Vector3.one * 0.01f;
                }
            }
        }


    }




}
