﻿using CoI.Mod.Better.Extensions;
using CoI.Mod.Better.Utilities;
using Mafi;
using Mafi.Base;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Mods;
using Mafi.Core.Population.Edicts;
using Mafi.Core.Prototypes;
using Mafi.Core.Research;
using Mafi.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace CoI.Mod.Better.Edicts
{
    internal partial class GenerellEdicts : IModData
    {
        private void AddRecyclingRatioDiff(ProtoRegistrator registrator)
        {
            if (!BetterMod.Config.Systems.Cheats) return;

            EdictUtility.GenerateEdict2(registrator, MyIDs.Eticts.Generell.RecyclingRatioDiffT1_CHEAT, categoryCheats, "recycling_ratio_t1", CheatUpkeepEdicts, IdsCore.PropertyIds.RecyclingRatioDiff, 20, null, Mafi.Base.Assets.Base.Icons.Edicts.RecyclingIncrease2_svg);
            EdictUtility.GenerateEdict2(registrator, MyIDs.Eticts.Generell.RecyclingRatioDiffT2_CHEAT, categoryCheats, "recycling_ratio_t2", CheatUpkeepEdicts, IdsCore.PropertyIds.RecyclingRatioDiff, 40, MyIDs.Eticts.Generell.RecyclingRatioDiffT1_CHEAT, Mafi.Base.Assets.Base.Icons.Edicts.RecyclingIncrease2_svg);
            EdictUtility.GenerateEdict2(registrator, MyIDs.Eticts.Generell.RecyclingRatioDiffT3_CHEAT, categoryCheats, "recycling_ratio_t3", CheatUpkeepEdicts, IdsCore.PropertyIds.RecyclingRatioDiff, 60, MyIDs.Eticts.Generell.RecyclingRatioDiffT2_CHEAT, Mafi.Base.Assets.Base.Icons.Edicts.RecyclingIncrease2_svg);
            EdictUtility.GenerateEdict2(registrator, MyIDs.Eticts.Generell.RecyclingRatioDiffT4_CHEAT, categoryCheats, "recycling_ratio_t4", CheatUpkeepEdicts, IdsCore.PropertyIds.RecyclingRatioDiff, 80, MyIDs.Eticts.Generell.RecyclingRatioDiffT3_CHEAT, Mafi.Base.Assets.Base.Icons.Edicts.RecyclingIncrease2_svg);
            EdictUtility.GenerateEdict2(registrator, MyIDs.Eticts.Generell.RecyclingRatioDiffT5_CHEAT, categoryCheats, "recycling_ratio_t5", CheatUpkeepEdicts, IdsCore.PropertyIds.RecyclingRatioDiff, 100, MyIDs.Eticts.Generell.RecyclingRatioDiffT4_CHEAT, Mafi.Base.Assets.Base.Icons.Edicts.RecyclingIncrease2_svg);
        }
    }
}
