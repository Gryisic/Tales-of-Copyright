using Infrastructure.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UI.Battle
{
    public class PartyMemberStatus : UIElement
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private Image _energyBar;

        private float _maxHealth;
        private float _maxEnergy;

        private RectTransform _rectTransform => transform as RectTransform;
        
        public Enums.PartyMemberType PartyMemberType { get; private set; }
        
        public override void Activate()
        {
            gameObject.SetActive(true);
        }

        public override void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void SetInitialData(Enums.PartyMemberType partyMember, int maxHealth, int currentHealth, int maxEnergy, int currentEnergy)
        {
            PartyMemberType = partyMember;
            _maxHealth = maxHealth;
            _maxEnergy = maxEnergy;
            
            UpdateHealth(currentHealth);
            UpdateEnergy(currentEnergy);
        }
        
        public void UpdateHealth(int currentHealth) => _healthBar.fillAmount = (float)currentHealth / (float)_maxHealth;
        
        public void UpdateEnergy(int currentEnergy) => _energyBar.fillAmount = (float)currentEnergy / (float)_maxEnergy;

        public void Shake() => animator.Shake(_rectTransform, 0.5f);
    }
}