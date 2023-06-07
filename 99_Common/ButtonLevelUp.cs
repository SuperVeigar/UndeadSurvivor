using UnityEngine;
using UnityEngine.UI;
using System;

namespace SuperVeigar
{
    public enum UpgradeImageType
    {
        Magnet = 0,
        Aid,
        MaxHP,
        Shovel,
        Fork,
        Sickle,
        DoubleBarrel,
        Rifle,
        Shotgun,
        MoveSpeed,
    }
    public class ButtonLevelUp : MonoBehaviour
    {
        [SerializeField]
        private Image[] images;
        private Action OnUpgrade;
        [SerializeField]
        private Text description;

        private void Start()
        {
            GetComponent<Button>().onClick.AddListener(() => UIService.Instance.SetActivePopupBack(PopupType.PopupLevelUp, false));

            GetComponent<Button>().onClick.AddListener(() => OnUpgrade?.Invoke());
        }

        public void SetUpgrade(UpgradeType type, Action OnUpgrade, string description)
        {
            this.OnUpgrade = OnUpgrade;
            this.description.text = description;

            for (int i = 0; i < images.Length; i++)
            {
                SetActiveImage((UpgradeImageType)i, false);
            }

            switch (type)
            {
                case UpgradeType.Magnet:
                    SetActiveImage(UpgradeImageType.Magnet, true);
                    break;
                case UpgradeType.Aid:
                    SetActiveImage(UpgradeImageType.Aid, true);
                    break;
                case UpgradeType.MaxHP:
                    SetActiveImage(UpgradeImageType.MaxHP, true);
                    break;
                case UpgradeType.SecondAttack:
                case UpgradeType.SecondAttackSpeed:
                    if (GameDataService.Instance.secondWeaponType == SecondWeaponType.Shovel)
                    {
                        SetActiveImage(UpgradeImageType.Shovel, true);
                    }
                    else if (GameDataService.Instance.secondWeaponType == SecondWeaponType.Fork)
                    {
                        SetActiveImage(UpgradeImageType.Fork, true);
                    }
                    else
                    {
                        SetActiveImage(UpgradeImageType.Sickle, true);
                    }
                    break;
                case UpgradeType.MoveSpeed:
                    SetActiveImage(UpgradeImageType.MoveSpeed, true);
                    break;
                case UpgradeType.WeaponAttack:
                case UpgradeType.WeaponAttackSpeed:
                case UpgradeType.WeaponAttackRange:
                    if (GameDataService.Instance.weaponType == WeaponType.DoubleBarrel)
                    {
                        SetActiveImage(UpgradeImageType.DoubleBarrel, true);
                    }
                    else if (GameDataService.Instance.weaponType == WeaponType.Rifle)
                    {
                        SetActiveImage(UpgradeImageType.Rifle, true);
                    }
                    else
                    {
                        SetActiveImage(UpgradeImageType.Shotgun, true);
                    }
                    break;
            }
        }

        private void SetActiveImage(UpgradeImageType type, bool isActive)
        {
            images[(int)type].gameObject.SetActive(isActive);
        }
    }
}

