using System;
using Components;
using Installers;
using UI.View;
using UnityEngine;
using Zenject;

namespace UI
{
    public sealed class HUDMediator :  IInitializable, IDisposable
    {
        private readonly CharacterInstaller _characterInstaller;
        private readonly HealthBarView _healthBarView;
        private HealthComponent _healthComponent;

        public HUDMediator(CharacterInstaller characterInstaller, HealthBarView healthBarView)
        {
            _characterInstaller = characterInstaller;
            _healthBarView = healthBarView;
        }

        public void Initialize()
        {
            _healthComponent = _characterInstaller.GetComponent<HealthComponent>();
            _healthBarView.SetHealthLabel(_healthComponent.GetCurrentHitPoints());
            _healthBarView.SetFillImage(_healthComponent.GetCurrentHitPoints());

            _healthComponent.OnChangeHealth += _healthBarView.SetHealthLabel;
            _healthComponent.OnChangeHealth += _healthBarView.SetFillImage;
        }

        public void Dispose()
        {
            _healthComponent.OnChangeHealth -= _healthBarView.SetHealthLabel;
            _healthComponent.OnChangeHealth -= _healthBarView.SetFillImage;
        }
    }
}