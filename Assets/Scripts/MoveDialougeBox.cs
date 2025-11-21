using UnityEngine;
using System.Collections;

public class MoveDialogueBox : MonoBehaviour
{
    public Vector3 offset = new Vector3(0f, 2f, 0f);
    public float duration = 0.25f;

    private Coroutine routine;

    public void MoveDialoguePosition(Transform target)
    {
        if (routine != null)
            StopCoroutine(routine);

        routine = StartCoroutine(AnimateMoveAndScale(target));
    }

    private IEnumerator AnimateMoveAndScale(Transform target)
    {
        Vector3 startPos = target.position;
        Vector3 endPos = target.position + offset;

        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one;

        transform.localScale = Vector3.zero;

        float t = 0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float lerp = Mathf.SmoothStep(0, 1, t / duration);

            transform.position = Vector3.Lerp(startPos, endPos, lerp);
            transform.localScale = Vector3.Lerp(startScale, endScale, lerp);

            yield return null;
        }

        // Snap to position
        transform.position = endPos;
        transform.localScale = Vector3.one;

        routine = null;
    }
}
