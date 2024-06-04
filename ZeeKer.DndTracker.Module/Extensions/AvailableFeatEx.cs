﻿using DevExpress.XtraRichEdit.Layout.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeeKer.DndTracker.Module.BusinessObjects;

namespace ZeeKer.DndTracker.Module.Extensions
{
    public static class AvailableFeatEx
    {

        public static void Rollback(this AvailableFeat feat)
        {
            if (feat.SelectedBonuses?.StatBonus is not null)
            {
                feat.Character.Stats.Wisdom -= feat.SelectedBonuses.StatBonus.Wisdom;
                feat.Character.Stats.Intelegence -= feat.SelectedBonuses.StatBonus.Intelligence;
                feat.Character.Stats.Strength -= feat.SelectedBonuses.StatBonus.Strength;
                feat.Character.Stats.Dexterity -= feat.SelectedBonuses.StatBonus.Dexterity;
                feat.Character.Stats.Charisma -= feat.SelectedBonuses.StatBonus.Charisma;
                feat.Character.Stats.Constitution -= feat.SelectedBonuses.StatBonus.Constitution;
            }



            feat.Character = null;
            feat.Delete();
        }
    }
}
