﻿using CoI.Mod.Better.Extensions;
using Mafi;
using Mafi.Base;
using Mafi.Base.Prototypes.Machines.PowerGenerators;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core;
using Mafi.Core.Entities;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.MechanicalPower;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;
using Mafi.Core.Research;
using UnityEngine;

namespace CoI.Mod.Better.Buildings
{
    internal class PowerGenerators : IModData
    {
        public void RegisterData(ProtoRegistrator registrator)
        {
            if (BetterMod.Config.DisablePowerGeneators || BetterMod.Config.DisableCheats) return;

            GeneratePowerMachine(registrator, MyIDs.Machines.VoidPowerEnergyT1Cheat, BetterMod.Config.VoidPowerEnergyT1InputMechPower, BetterMod.Config.VoidPowerEnergyT1OutputPower);
            GeneratePowerMachine(registrator, MyIDs.Machines.VoidPowerEnergyT2Cheat, BetterMod.Config.VoidPowerEnergyT2InputMechPower, BetterMod.Config.VoidPowerEnergyT2OutputPower);
            GeneratePowerMachine(registrator, MyIDs.Machines.VoidPowerEnergyT3Cheat, BetterMod.Config.VoidPowerEnergyT3InputMechPower, BetterMod.Config.VoidPowerEnergyT3OutputPower);
            GeneratePowerMachine(registrator, MyIDs.Machines.VoidPowerEnergyT4Cheat, BetterMod.Config.VoidPowerEnergyT4InputMechPower, BetterMod.Config.VoidPowerEnergyT4OutputPower);
            GeneratePowerMachine(registrator, MyIDs.Machines.VoidPowerEnergyT5Cheat, BetterMod.Config.VoidPowerEnergyT5InputMechPower, BetterMod.Config.VoidPowerEnergyT5OutputPower);

            // Generate Research
            ResearchNodeProtoBuilder.State research_state_t1 = registrator.ResearchNodeProtoBuilder
                .Start("Void Power Energy CHEAT", MyIDs.Research.VoidPowerEnergyCheat)
                .SetCostsOne()
                .AddLayoutEntityToUnlock(MyIDs.Machines.VoidPowerEnergyT1Cheat)
                .AddLayoutEntityToUnlock(MyIDs.Machines.VoidPowerEnergyT2Cheat)
                .AddLayoutEntityToUnlock(MyIDs.Machines.VoidPowerEnergyT3Cheat)
                .AddLayoutEntityToUnlock(MyIDs.Machines.VoidPowerEnergyT4Cheat)
                .AddLayoutEntityToUnlock(MyIDs.Machines.VoidPowerEnergyT5Cheat);

            ResearchNodeProto research_t1 = research_state_t1.BuildAndAdd();

            // Add parent to my research CHEAT
            ResearchNodeProto master_cheat_research = registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(MyIDs.Research.VoidDieselEnergyCheat);
            research_t1.AddGridPos(master_cheat_research, -BetterMod.UI_StepSize, 0);
        }

        private static void GeneratePowerMachine(ProtoRegistrator registrator, StaticEntityProto.ID protoID, int inputKwMech, int outputKW)
        {
            MechPower kwMech_amount = inputKwMech.KwMech();
            Electricity kw_amount = outputKW.Kw().ScaledBy(registrator.DifficultyConfig.PowerProductionMult);

            ElectricityGeneratorFromMechPowerProto generator = registrator.PrototypesDb.Add
            (
                new ElectricityGeneratorFromMechPowerProto(
                    protoID,
                    Proto.CreateStr(protoID, "Power generator " + kw_amount.Format().ToString(), "Converts mechanical power to electricity. The slower it spins the lower its efficiency is."),
                    registrator.LayoutParser.ParseLayoutOrThrow("   [2][2]   ", "   [3][3]   ", " | >3PQ3> | ", "   [3][3]   ", "   [2][2]   "),
                    Costs.Machines.PowerGeneratorT1.MapToEntityCosts(registrator),
                    registrator.PrototypesDb.GetOrThrow<ProductProto>(IdsCore.Products.MechanicalPower),
                    kwMech_amount,
                    registrator.PrototypesDb.GetOrThrow<ProductProto>(IdsCore.Products.Electricity),
                    kw_amount,
                    5,
                    25.Percent(),
                    ImmutableArray.Create((AnimationParams)AnimationParams.Loop(80.Percent())),
                    new ElectricityGeneratorFromMechPowerProto.Gfx
                    (
                        "Assets/Base/Machines/PowerPlant/Generator.prefab",
                        "Assets/Base/Machines/PowerPlant/Generator/GeneratorSound.prefab",
                        registrator.GetCategoriesProtos(MyIDs.ToolbarCategories.MachinesElectricity),
                        BetterMod.GetIconPath<ElectricityGeneratorFromMechPowerProto>(registrator, Ids.Machines.PowerGeneratorT1)
                    )
                )
            );
            generator.AddParam(new ShaftInertiaProtoParam(generator.InputMechPower, 2.Seconds()));

            Debug.Log("PowerGenerators >> GeneratePowerMachine (name: " + "Power generator " + kw_amount.Format().ToString() + " | input: " + kwMech_amount.Format().ToString() + " | output: " + kw_amount.Format().ToString() + ") >> created!");
        }


    }
}
