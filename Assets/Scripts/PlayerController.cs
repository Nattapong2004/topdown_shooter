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

    private float horizontalInput;
    private InputAction moveAction;
    private InputAction shootAction;

    private Coroutine speedBoostCoroutine;
    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(horizontalInput * currentSpeed * Time.deltaTime * Vector3.right);

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
    public void ApplySpeedBoost(float multiplier, float duration)
    {
        if (speedBoostCoroutine != null)
        {
            StopCoroutine(speedBoostCoroutine);
        }
        speedBoostCoroutine = StartCoroutine(SpeedBoostRoutine(multiplier, duration));
    }

    private IEnumerator SpeedBoostRoutine(float multiplier, float duration)
    {
        currentSpeed = speed * multiplier;
        yield return new WaitForSeconds(duration);
        currentSpeed = speed;
        speedBoostCoroutine = null;
    }
}
