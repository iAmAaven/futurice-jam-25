using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectOfFour : MonoBehaviour
{
    public GameObject[] objects = new GameObject[4];
    public List<Transform> spawnPoints = new List<Transform>();
    private GameObject fadingObject;
    private LevelLength levelLength;

    void Start()
    {
        int fadingIndex = Random.Range(0, objects.Length);
        for (int i = 0; i < objects.Length; i++)
        {
            int randomPos = Random.Range(0, spawnPoints.Count);
            GameObject newObject = Instantiate(objects[i], spawnPoints[randomPos].position, Quaternion.identity);

            spawnPoints.RemoveAt(randomPos);

            if (i == fadingIndex)
                fadingObject = newObject;
        }

        fadingObject.GetComponent<TransObject>().isFading = true;
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(5f);
        levelLength = FindFirstObjectByType<LevelLength>();
        SpriteRenderer spriteRenderer = fadingObject.GetComponentInChildren<SpriteRenderer>();

        float duration = levelLength.lengthOfLevel;
        float elapsedTime = 0f;
        Color color = spriteRenderer.color;

        while (elapsedTime < duration)
        {
            if (spriteRenderer == null)
                break;

            elapsedTime += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, elapsedTime / duration);
            spriteRenderer.color = color;
            yield return null;
        }

        if (spriteRenderer == null)
            yield break;
        color.a = 0f;
        spriteRenderer.color = color;
    }
}
