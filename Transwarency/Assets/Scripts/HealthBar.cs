using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public GameObject[] hearts;

    public void RefreshHealth(int health)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
                hearts[i].SetActive(true);
            else
                hearts[i].SetActive(false);
        }
    }
}
