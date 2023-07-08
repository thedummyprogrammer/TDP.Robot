/*======================================================================================
    Copyright 2021 - 2023 by TheDummyProgrammer (https://www.thedummyprogrammer.com)

    This file is part of The Dummy Programmer Robot.

    The Dummy Programmer Robot is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    The Dummy Programmer Robot is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with The Dummy Programmer Robot.  If not, see <http://www.gnu.org/licenses/>.
======================================================================================*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TDP.BaseServices.Infrastructure.DataValidation;
using TDP.Robot.Core;

namespace TDP.Robot.Plugins.Core.DateTimeEvent
{
    public partial class WndDateTimeEventConfig : WndPluginEventConfig
    {
        private bool _SelectingAllDays;
        private bool _SelectingADay;

        private Dictionary<DayOfWeek, CheckBox> _OnDays;

        private bool AreAllDaysSelected()
        {
            bool AllSelected = true;

            foreach (KeyValuePair<DayOfWeek, CheckBox> Entry in _OnDays)
            {
                if (!Entry.Value.Checked)
                {
                    AllSelected = false;
                    break;
                }
            }

            return AllSelected;
        }

        public void SetAllDaysSelection(bool selected)
        {
            foreach (KeyValuePair<DayOfWeek, CheckBox> Entry in _OnDays)
            {
                Entry.Value.Checked = selected;
            }
        }

        public void SetAllDaysEnabled(bool enabled)
        {
            foreach (KeyValuePair<DayOfWeek, CheckBox> Entry in _OnDays)
            {
                Entry.Value.Enabled = enabled;
            }
        }

        public WndDateTimeEventConfig()
        {
            InitializeComponent();
            
            _OnDays = new Dictionary<DayOfWeek, CheckBox>();
            _OnDays.Add(DayOfWeek.Monday, ChkOnMonday);
            _OnDays.Add(DayOfWeek.Tuesday, ChkOnTuesday);
            _OnDays.Add(DayOfWeek.Wednesday, ChkOnWednesday);
            _OnDays.Add(DayOfWeek.Thursday, ChkOnThursday);
            _OnDays.Add(DayOfWeek.Friday, ChkOnFriday);
            _OnDays.Add(DayOfWeek.Saturday, ChkOnSaturday);
            _OnDays.Add(DayOfWeek.Sunday, ChkOnSunday);

            foreach (KeyValuePair<DayOfWeek, CheckBox> Entry in _OnDays)
            {
                Entry.Value.CheckedChanged += ChkOnDay_CheckedChanged;
            }
        }

        private void ChkOnDay_CheckedChanged(object sender, EventArgs e)
        {
            if (_SelectingAllDays)
                return;

            _SelectingADay = true;

            ChkOnAllDays.Checked = AreAllDaysSelected();

            _SelectingADay = false;
        }

        protected override bool ValidateConfig(IPluginInstanceConfig config)
        {
            base.ValidateConfig(config);

            if (DataValidationHelper.IsEmptyString(TxtName.Text))
                SetError(TxtName, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtEveryNumDays.Text))
                SetError(TxtEveryNumDays, Resource.TxtFieldCannotBeEmpty);

            if (DataValidationHelper.IsEmptyString(TxtEveryNumDays.Text))
                TxtEveryNumDays.Text = Constants.Zero;
            else if (!DataValidationHelper.IsInteger(TxtEveryNumDays.Text, Constants.EveryNumDaysMaxLength, Constants.EveryNumDaysMin, Constants.EveryNumDaysMax))
                SetError(TxtEveryNumDays, string.Format(Resource.TxtMustBeANumberBetweenXAndY, Constants.EveryNumDaysMin, Constants.EveryNumDaysMax));

            if (DataValidationHelper.IsEmptyString(TxtEveryNumHours.Text))
                TxtEveryNumHours.Text = Constants.Zero;
            else if (!DataValidationHelper.IsInteger(TxtEveryNumHours.Text, Constants.EveryNumHoursMaxLength, Constants.EveryNumHoursMin, Constants.EveryNumHoursMax))
                SetError(TxtEveryNumHours, string.Format(Resource.TxtMustBeANumberBetweenXAndY, Constants.EveryNumHoursMin, Constants.EveryNumHoursMax));

            if (DataValidationHelper.IsEmptyString(TxtEveryNumMinutes.Text))
                TxtEveryNumMinutes.Text = Constants.Zero;
            else if (!DataValidationHelper.IsInteger(TxtEveryNumMinutes.Text, Constants.EveryNumMinutesMaxLength, Constants.EveryNumMinutesMin, Constants.EveryNumMinutesMax))
                SetError(TxtEveryNumMinutes, string.Format(Resource.TxtMustBeANumberBetweenXAndY, Constants.EveryNumMinutesMin, Constants.EveryNumMinutesMax));

            if (DataValidationHelper.IsEmptyString(TxtEveryNumSeconds.Text))
                TxtEveryNumSeconds.Text = Constants.Zero;
            else if (!DataValidationHelper.IsInteger(TxtEveryNumSeconds.Text, Constants.EveryNumSecondsMaxLength, Constants.EveryNumSecondsMin, Constants.EveryNumSecondsMax))
                SetError(TxtEveryNumSeconds, string.Format(Resource.TxtMustBeANumberBetweenXAndY, Constants.EveryNumSecondsMin, Constants.EveryNumSecondsMax));

            if (GetErrorCount() == 0)
            {
                if (OptEveryDaysHoursSecs.Checked)
                {
                    int Days = int.Parse(TxtEveryNumDays.Text);
                    int Hours = int.Parse(TxtEveryNumHours.Text);
                    int Minutes = int.Parse(TxtEveryNumMinutes.Text);

                    if (Days == 0 && Hours == 0 && Minutes == 0)
                        SetError(OptEveryDaysHoursSecs, Resource.TxtAtLeastOneFieldMustDaysHoursMinBeGreaterThan0);
                }
                else if (OptEverySeconds.Checked)
                {
                    int Seconds = int.Parse(TxtEveryNumSeconds.Text);
                    if (Seconds == 0)
                        SetError(TxtEveryNumSeconds, string.Format(Resource.TxtFieldMustBeGreaterThanX, 0));
                }
            }
            
            return GetErrorCount() == 0;
        }

        protected override void FillConfig(IPluginInstanceConfig config)
        {
            base.FillConfig(config);

            DateTimeEventConfig Config = (DateTimeEventConfig)_PluginConfig;

            DateTime AtDate = new DateTime(DtAtDate.Value.Year, DtAtDate.Value.Month, DtAtDate.Value.Day);
            AtDate = AtDate.AddHours(DtAtTime.Value.Hour);
            AtDate = AtDate.AddMinutes(DtAtTime.Value.Minute);
            Config.AtDate = AtDate;

            Config.OneTime = OptOneTime.Checked;
            Config.EveryDaysHoursSecs = OptEveryDaysHoursSecs.Checked;
            Config.EveryNumDays = int.Parse(TxtEveryNumDays.Text);
            Config.EveryNumHours = int.Parse(TxtEveryNumHours.Text);
            Config.EveryNumMinutes = int.Parse(TxtEveryNumMinutes.Text);

            Config.EverySeconds = OptEverySeconds.Checked;
            Config.EveryNumSeconds = int.Parse(TxtEveryNumSeconds.Text);

            Config.OnDays.Clear();
            foreach (KeyValuePair<DayOfWeek, CheckBox> Entry in _OnDays)
            {
                if (Entry.Value.Checked)
                {
                    Config.OnDays.Add(Entry.Key);
                }
            }

            Config.OnAllDays = ChkOnAllDays.Checked;
        }

        protected override void FillForm(IPluginInstanceConfig config)
        {
            base.FillForm(config);

            DateTimeEventConfig Config = (DateTimeEventConfig)config;

            DtAtDate.Value = Config.AtDate;
            DtAtTime.Value = Config.AtDate;

            OptOneTime.Checked = Config.OneTime;
            OptEveryDaysHoursSecs.Checked = Config.EveryDaysHoursSecs;
            TxtEveryNumDays.Text = Config.EveryNumDays.ToString();
            TxtEveryNumHours.Text = Config.EveryNumHours.ToString();
            TxtEveryNumMinutes.Text = Config.EveryNumMinutes.ToString();

            OptEverySeconds.Checked = Config.EverySeconds;
            TxtEveryNumSeconds.Text = Config.EveryNumSeconds.ToString();

            SetAllDaysSelection(false);

            foreach (DayOfWeek Day in Config.OnDays)
            {
                _OnDays[Day].Checked = true;
            }

            ChkOnAllDays.Checked = Config.OnAllDays;
        }

        private void ChkOnAllDays_CheckedChanged(object sender, EventArgs e)
        {
            if (_SelectingADay)
                return;

            _SelectingAllDays = true;

            SetAllDaysSelection(ChkOnAllDays.Checked);
            
            _SelectingAllDays = false;
        }

        private void OptOneTime_CheckedChanged(object sender, EventArgs e)
        {
            TxtEveryNumDays.Enabled = false;
            TxtEveryNumHours.Enabled = false;
            TxtEveryNumMinutes.Enabled = false;

            TxtEveryNumSeconds.Enabled = false;

            SetAllDaysSelection(true);
            SetAllDaysEnabled(false);

            ChkOnAllDays.Enabled = false;
        }

        private void OptEveryDaysHoursSecs_CheckedChanged(object sender, EventArgs e)
        {
            TxtEveryNumDays.Enabled = true;
            TxtEveryNumHours.Enabled = true;
            TxtEveryNumMinutes.Enabled = true;

            TxtEveryNumSeconds.Enabled = false;

            SetAllDaysEnabled(true);
            
            ChkOnAllDays.Enabled = true;
        }

        private void OptEverySeconds_CheckedChanged(object sender, EventArgs e)
        {
            TxtEveryNumDays.Enabled = false;
            TxtEveryNumHours.Enabled = false;
            TxtEveryNumMinutes.Enabled = false;

            TxtEveryNumSeconds.Enabled = true;

            SetAllDaysEnabled(true);

            ChkOnAllDays.Enabled = true;
        }
    }
}
