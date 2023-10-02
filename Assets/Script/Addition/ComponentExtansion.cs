using UnityEngine;

public static class ComponentExtansion
{
    public static void ActivateSelf(this Component component)
    {
        component.gameObject.SetActive(true);
    }

    public static void ActivateSelf(this GameObject component)
    {
        component.SetActive(true);
    }

    public static void DisactivateSelf(this GameObject component)
    {
        component.SetActive(false);
    }

    public static void DisactivateSelf(this Component component)
    {
        component.gameObject.SetActive(false);
    }

    public static void ActivateArraySelf(this GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
            gameObjects[i].SetActive(true);
    }

    public static void DisctivateArraySelf(this GameObject[] gameObjects)
    {
        for (int i = 0; i < gameObjects.Length; i++)
            gameObjects[i].SetActive(false);
    }
}