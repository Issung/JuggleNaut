using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class HealthBar : MonoBehaviour
{
    private float rtMaxWidth;

    [SerializeField] private float yGap, xGap;

    [SerializeField] private int health = 100;
    private float healthBuffer;
    [SerializeField] private int maxHealth = 100;
    private float maxHealthBuffer;

    [Range(0, 1)]
    [Tooltip("Speed for tween to catch up. Higher is Faster. 1 = Instantaneous (No Ease)")]
    public float speed;

    private RectTransform outerBarRt, innerBarRt;
    private Text healthText, warningText;

    [SerializeField] private int warningThreshold = 20;
    [SerializeField] private float warningFlashTime = 1;
    private bool warningFlashing = false;

    [SerializeField] private bool displayPercentageText;
    string textHpFraction;
    string textPercentage;

    void Awake ()
    {
        healthBuffer = health;
        maxHealthBuffer = maxHealth;

        outerBarRt = GetComponent<RectTransform>();
        rtMaxWidth = outerBarRt.sizeDelta.x - (xGap * 2);
        innerBarRt = transform.Find("HealthInnerBar").gameObject.GetComponent<RectTransform>();

        innerBarRt.anchoredPosition = new Vector2(xGap, yGap);
        innerBarRt.sizeDelta = new Vector2(rtMaxWidth * ((float)health / (float)maxHealth), outerBarRt.sizeDelta.y - (yGap * 2));

        healthText = transform.Find("HealthText").gameObject.GetComponent<Text>();
        warningText = transform.Find("WarningText").gameObject.GetComponent<Text>();
        warningText.gameObject.SetActive(false);
    }
	
	void Update ()
    {
        if (health < healthBuffer)
            healthBuffer -= Mathf.Abs(health - healthBuffer) * speed * Controller.GetDtf();
        else if (health > healthBuffer)
            healthBuffer += Mathf.Abs(health - healthBuffer) * speed * Controller.GetDtf();

        if (maxHealth < maxHealthBuffer)
            maxHealthBuffer -= Mathf.Abs(maxHealth - maxHealthBuffer) * speed * Controller.GetDtf();
        else if (maxHealth > maxHealthBuffer)
            maxHealthBuffer += Mathf.Abs(maxHealth - maxHealthBuffer) * speed * Controller.GetDtf();

        if (health <= warningThreshold)
            if (!warningFlashing)
                StartCoroutine(WarningFlash());

        rtMaxWidth = outerBarRt.sizeDelta.x - (xGap * 2);
        float width = rtMaxWidth * ((float)healthBuffer / (float)maxHealthBuffer);
        innerBarRt.sizeDelta = new Vector2(Mathf.Clamp(width, 0, rtMaxWidth), outerBarRt.sizeDelta.y - (yGap * 2));
        innerBarRt.anchoredPosition = new Vector2(xGap, yGap);

        textHpFraction = Mathf.RoundToInt(Mathf.Clamp(healthBuffer, 0, maxHealthBuffer)) + "/" + Mathf.RoundToInt(maxHealthBuffer);
        textPercentage = displayPercentageText ? (" - " + Mathf.RoundToInt(((healthBuffer / maxHealthBuffer) * 100)) + "%") : "";
        healthText.text = textHpFraction + textPercentage;
    }

    IEnumerator WarningFlash()
    {
        if (warningFlashing)        //exit if already flashing.
            yield return null;

        warningFlashing = true;
        while (health <= warningThreshold || warningText.gameObject.activeSelf)
        {
            warningText.gameObject.SetActive(true);
            yield return new WaitForSeconds(warningFlashTime);
            warningText.gameObject.SetActive(false);
            yield return new WaitForSeconds(warningFlashTime);
        }
        warningText.gameObject.SetActive(false);
        warningFlashing = false;
        yield return null;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void SetMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth > 0 ? maxHealth : this.maxHealth;
    }
}
