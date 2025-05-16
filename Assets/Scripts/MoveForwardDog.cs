using System.Net.NetworkInformation;
using UnityEngine;
using System.Collections;

public class MoveForwardDog : MonoBehaviour
{
    public float speed = 2f;
    public float currentSpeed;

    private Coroutine slowCoroutine;

    private void Start()
    {
        currentSpeed = speed;
    }

    void Update()
    {
        transform.Translate(currentSpeed * Time.deltaTime * Vector3.forward);
    }

    public void ApplySlow(float multiplier, float duration)
    {
        if (slowCoroutine != null)
        {
            StopCoroutine(slowCoroutine);
        }
        slowCoroutine = StartCoroutine(SlowRoutine(multiplier, duration));
    }

    private IEnumerator SlowRoutine(float multiplier, float duration)
    {
        currentSpeed = speed * multiplier;
        yield return new WaitForSeconds(duration);
        currentSpeed = speed;
        slowCoroutine = null;
    }
}
