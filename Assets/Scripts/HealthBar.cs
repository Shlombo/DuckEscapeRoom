using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public Image green;
    public float health = 100f;
    Vector2 oldMousePosition;

    void Start()
    {
        green = GameObject.Find("Green").GetComponent<Image>();
        oldMousePosition = Input.mousePosition;
        green.fillAmount = 1;
    }

    void Update()
    {
        Vector2 currentMousePosition = Input.mousePosition;
        if (health <= 0)
        {
            onFail();
        }
        takeDamage((Mathf.Sqrt(Mathf.Pow(currentMousePosition.x - oldMousePosition.x, 2) + Mathf.Pow(currentMousePosition.y - oldMousePosition.y, 2))) / 10f);
        // addHealth(0.01f);
        oldMousePosition = currentMousePosition;
    }

    void onFail()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float takeDamage(float damage)
    {
        health -= damage;
        green.fillAmount = health / 100f;
        return health;
    }

    public float addHealth(float healthToBeAdded)
    {
        health += healthToBeAdded;
        if (health > 100f)
        {
            health = 100f;
        }
        green.fillAmount = health / 100f;
        return health;
    }
}