using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;



public class PlayerController : MonoBehaviour
{
    public float speed;
    private float currentSpeed;
    public float xRange = 10;
    public GameObject projectilePrefab;


   
    public int maxBulletCount = 10;
    public float bulletRegenerateCooldown = 1f;
     private Coroutine speedBoostRoutine;
    

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        currentSpeed = speed;
    }
    public void ApplySpeedBoost(float multiplier, float duration)
    {
        // หยุด Coroutine ที่กำลังทำงานอยู่ (ถ้ามี)
        if (speedBoostRoutine != null)
        {
            StopCoroutine(speedBoostRoutine);
        }

        // เริ่ม Coroutine ใหม่
        speedBoostRoutine = StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        currentSpeed = speed * multiplier;
        yield return new WaitForSeconds(duration);
        currentSpeed = speed;
        speedBoostRoutine = null;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
    }
}
