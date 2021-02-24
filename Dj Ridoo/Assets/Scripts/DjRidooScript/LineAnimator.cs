using UnityEngine;
using System.Collections;

public class LineAnimator : MonoBehaviour
{
    [SerializeField] private float animationDuration = 10f;

    public GameObject lineObject;

    private LineRenderer lineRenderer;
    private Vector3[] linePoints;
    private int pointsCount;
    private bool check = false;
    private bool started = false;

    private int i = 0;

    private Coroutine particleMov;

    private void Update()
    {
        if (lineObject == null)
        {
            Destroy(this.gameObject);
        }

        if (check == false)
        {
            lineRenderer = lineObject.GetComponent<LineRenderer>();
            if (lineRenderer != null)
                check = true;
        }
        else if (!started)
        {
            started = true;
            if (lineRenderer != null)
            {
                pointsCount = lineRenderer.positionCount;
                linePoints = new Vector3[pointsCount];
                for (int j = 0; j < pointsCount; j++)
                {
                    linePoints[j] = lineRenderer.GetPosition(j);
                }
                if (particleMov != null)
                {
                    Debug.Log("started!");
                    StopCoroutine(particleMov);
                }
                particleMov = StartCoroutine(AnimateLine());
            }
        }
    }

    private IEnumerator AnimateLine()
    {
        float segmentDuration = animationDuration / pointsCount;

        for (int i = pointsCount - 1; i > 0 ; i--)
        {
            if (lineObject != null && lineRenderer != null)
            {
                pointsCount = lineRenderer.positionCount;
                linePoints = new Vector3[pointsCount];
                for (int j = 0; j < pointsCount; j++)
                {
                    linePoints[j] = lineRenderer.GetPosition(j);
                }
                float startTime = Time.time;

                if (linePoints[i] != null)
                {
                    Debug.Log("running");

                    Vector3 startPosition = linePoints[i];
                    Vector3 endPosition = linePoints[i - 1];
                    Vector3 pos = startPosition;
                    while (pos != endPosition)
                    {
                        float t = (Time.time - startTime) / segmentDuration;
                        pos = Vector3.Lerp(startPosition, endPosition, t);

                        // animate all other points except point at index i
                        for (int j = i + 1; j < pointsCount; j++)
                            transform.position = Vector3.MoveTowards(transform.position, pos, t);

                        yield return null;
                    }

                }

                if (i == 1)
                {
                    i = pointsCount - 1;
                }
            } 
            else
            {
                //Destroy(lineObject);
                Destroy(this.gameObject);
            }
        }
    }
}