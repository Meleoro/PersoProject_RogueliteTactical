using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private RectTransform _mainParent;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private Image _blackFadeImage;


    public void DisplayPopUp(CampLevelData campLevelData)
    {
        _nameText.text = campLevelData.unlockName;
        _descriptionText.text = campLevelData.unlockDescription;

        _mainParent.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutBack);

        _blackFadeImage.DOFade(0.6f, 0.25f);
        _blackFadeImage.raycastTarget = true;
    }

    public void HidePopUp()
    {
        _mainParent.DOScale(Vector3.zero, 0.25f).SetEase(Ease.InBack);

        _blackFadeImage.DOFade(0f, 0.25f);
        _blackFadeImage.raycastTarget = false;
    }
}
