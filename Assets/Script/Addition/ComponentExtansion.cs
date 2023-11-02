using System.Collections.Generic;
using System.Linq;
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
        if (gameObjects.Length == 0)
            return;

        for (int i = 0; i < gameObjects.Length; i++)
            gameObjects[i].SetActive(true);
    }

    public static void ActivateArraySelf(this IReadOnlyList<GameObject> gameObjects)
    {
        if (gameObjects.Count == 0)
            return;

        for (int i = 0; i < gameObjects.Count; i++)
            gameObjects[i].SetActive(true);
    }

    public static void DisctivateArraySelf(this GameObject[] gameObjects)
    {
        if (gameObjects.Length == 0)
            return;

        for (int i = 0; i < gameObjects.Length; i++)
            gameObjects[i].SetActive(false);
    }

    public static void DestroyArrayGameobjectsSelf(this GameObject[] gameObjects)
    {
        if (gameObjects.Length == 0)
            return;

        for (int i = 0; i < gameObjects.Length; i++)
            UnityEngine.Object.Destroy(gameObjects[i]);
    }

    public static void DestroyArrayGameobjectsSelf<T>(this IReadOnlyList<T> monoBehaviours)
        where T : MonoBehaviour
    {
        for (int i = 0; i < monoBehaviours.Count; i++)
            UnityEngine.Object.Destroy(monoBehaviours[i].gameObject);
    }
}