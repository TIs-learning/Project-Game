using System.Collections;
using UnityEngine;

public class CardAnimator : MonoBehaviour
{
    public IEnumerator MoveTo(Transform target, float duration)
    {
        Vector3 start = transform.position;
        Vector3 end = target.position;
        Vector3 startScale = transform.localScale;
        Vector3 endScale = startScale * 0.75f;
        Quaternion startRot = transform.rotation;
        Quaternion endRot = Quaternion.Euler(0,0,8);

        float timer = 0f;

        while (timer < duration)
        {
            float t = timer / duration;
            t = t * t * (3f - 2f * t);   // SmoothStep

            transform.position = Vector3.Lerp(start, end, t);
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            transform.rotation = Quaternion.Lerp(startRot, endRot, t);

            timer += Time.deltaTime;

            yield return null;
        }

        transform.position = end;
    }
}