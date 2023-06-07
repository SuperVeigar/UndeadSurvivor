using UnityEngine;
using System;
using System.Collections.Generic;

namespace SuperVeigar
{
    public enum UpgradeType
    {
        Magnet = 0,
        Aid,
        MaxHP,
        SecondAttack,
        SecondAttackSpeed,
        MoveSpeed,
        WeaponAttack,
        WeaponAttackSpeed,
        WeaponAttackRange,
        End
    }

    public class PopupLevelUp : MonoBehaviour
    {
        [SerializeField]
        private ButtonLevelUp[] buttons;
        private List<Action> upgrades;
        private List<string> descriptions;
        private bool isInit = false;

        private void InitUpgrades()
        {
            upgrades = new List<Action>();
            upgrades.Add(UpgradeMagnet);
            upgrades.Add(UseAid);
            upgrades.Add(UpgradeMaxHP);
            upgrades.Add(UpgradeSecondAttack);
            upgrades.Add(UpgradeSecondAttackSpeed);
            upgrades.Add(UpgradeMoveSpeed);
            upgrades.Add(UpgradeWeaponAttack);
            upgrades.Add(UpgradeWeaponAttackSpeed);
            upgrades.Add(UpgradeWeaponAttackRange);
        }

        private void InitDesciptions()
        {
            descriptions = new List<string>();
            descriptions.Add("자석 범위 증가");
            descriptions.Add("치료");
            descriptions.Add("최대 체력 증가");
            descriptions.Add("공격력 증가");
            descriptions.Add("공격속도 증가");
            descriptions.Add("이동속도 증가");
            descriptions.Add("공격력 증가");
            descriptions.Add("공격속도 증가");
            descriptions.Add("사정거리 증가");
        }

        private void OnEnable()
        {
            if (isInit == false)
            {
                isInit = true;

                InitUpgrades();
                InitDesciptions();
            }
            
            SetUpgrade();
        }

        private void SetUpgrade()
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                int type = UnityEngine.Random.Range(0, (int)UpgradeType.End);

                buttons[i].SetUpgrade((UpgradeType)type, upgrades[type], descriptions[type]);
            }
        }

        private void UpgradeMagnet()
        {

        }

        private void UseAid()
        {
            GameDataService.Instance.playerData.ResetCurrentHP();
        }

        private void UpgradeMaxHP()
        {
            GameDataService.Instance.playerData.AddMaxHP(5);
            GameDataService.Instance.playerData.AddCurrentHP(5);
        }

        private void UpgradeSecondAttack()
        {
            GameDataService.Instance.playerData.AddSecondAttack(1);
        }

        private void UpgradeSecondAttackSpeed()
        {
            GameDataService.Instance.playerData.AddSecondAttackSpeed(1);
        }

        private void UpgradeMoveSpeed()
        {
            GameDataService.Instance.playerData.AddMoveSpeed(1);
        }

        private void UpgradeWeaponAttack()
        {
            GameDataService.Instance.weaponData.AddAttack(1);
        }

        private void UpgradeWeaponAttackSpeed()
        {
            GameDataService.Instance.weaponData.AddAttackSpeed(1);
        }

        private void UpgradeWeaponAttackRange()
        {
            GameDataService.Instance.weaponData.AddAttackRange(1);
        }
    }
}

