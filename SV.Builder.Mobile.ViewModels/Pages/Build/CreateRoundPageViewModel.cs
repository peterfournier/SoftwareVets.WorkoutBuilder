﻿using SV.Builder.Domain.Factories;
using SV.Builder.Mobile.Common.MessageCenter;
using System;
using Xamarin.Forms;

namespace SV.Builder.Mobile.ViewModels.Pages
{
    public class CreateRoundPageViewModel : BaseViewModel
    {
        private int _iterations;
        public int Iterations
        {
            get => _iterations;
            set => SetProperty(ref _iterations, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _description;
        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public override void OnSaveCommand()
        {
            var roundFactory = new RoundFactory();

            var round = roundFactory.CreateRound(Name, Description, Iterations);

            MessagingCenter.Send(this, Messages.CreateRound, round);

            base.OnSaveCommand();
        }

    }
}
