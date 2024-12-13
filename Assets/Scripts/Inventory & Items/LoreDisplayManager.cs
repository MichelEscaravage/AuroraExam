using System.Collections;
using TMPro;
using UnityEngine;

public class LoreDisplayManager : MonoBehaviour
{
    public static LoreDisplayManager Instance; // Singleton instance

    private void Awake()
    {
        // Ensure only one instance of the manager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowLorePopup(TMP_Text loreDisplayText, LoreItem loreItem, float displayTime)
    {
        // Start the fade-in and fade-out coroutine
        StartCoroutine(FadeLorePopup(loreDisplayText, loreItem, displayTime));
    }

    private IEnumerator FadeLorePopup(TMP_Text loreDisplayText, LoreItem loreItem, float displayTime)
    {
        // Set the text to only show "Picked up" and the title
        loreDisplayText.text = $"Picked up: {loreItem.loreTitle}";

        // Ensure text is visible
        Color originalColor = loreDisplayText.color;
        originalColor.a = 0; // Start fully transparent
        loreDisplayText.color = originalColor;

        // Fade in
        float fadeInDuration = 0.5f; // Duration for fade-in
        for (float t = 0; t < fadeInDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(0, 1, t / fadeInDuration);
            loreDisplayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        loreDisplayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 1);

        // Wait for display time
        yield return new WaitForSeconds(displayTime);

        // Fade out
        float fadeOutDuration = 0.5f; // Duration for fade-out
        for (float t = 0; t < fadeOutDuration; t += Time.deltaTime)
        {
            float alpha = Mathf.Lerp(1, 0, t / fadeOutDuration);
            loreDisplayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }
        loreDisplayText.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0);

        // Clear the text
        loreDisplayText.text = "";
    }
}
