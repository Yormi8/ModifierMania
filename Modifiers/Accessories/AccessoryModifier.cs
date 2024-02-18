using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.WorldBuilding;

namespace ModifierMania.Modifiers.Accessories
{
    [Autoload(false)]
    internal class AccessoryModifier : CommonModifier
    {
        class AccessoryModifierLoader : ILoadable
        {
            public void Load(Mod mod)
            {
                AccessoryModifier[] accessoryModifiers =
                [
                    // Bad modifiers
                    new("Vulnerable",   -1, -1, 0, 0, 0, [], [], []),
                    new("Delicate",     -2, -2, 0, 0, 0, [], [], []),
                    new("Degenerative", -6, -4, 0, 0, 0, [], [], []),

                    new("Cursed",    -1, 0, 0, 0, 0, [(DamageClass.Generic, -1)], [], []),
                    new("Hapless",   -2, 0, 0, 0, 0, [(DamageClass.Generic, -2)], [], []),
                    new("Ill-Fated", -6, 0, 0, 0, 0, [(DamageClass.Generic, -4)], [], []),

                    new("Weakened", -1, 0, 0, 0, 0, [], [(DamageClass.Generic, -1)], []),
                    new("Soft",     -2, 0, 0, 0, 0, [], [(DamageClass.Generic, -2)], []),
                    new("Yielding", -6, 0, 0, 0, 0, [], [(DamageClass.Generic, -4)], []),

                    new("Hefty",      -1, 0, -1, 0, 0, [], [], []),
                    new("Weighty",    -2, 0, -2, 0, 0, [], [], []),
                    new("Overweight", -6, 0, -4, 0, 0, [], [], []),

                    new("Tame",   -1, 0, 0, 0, 0, [], [], [(DamageClass.Melee, -1)]),
                    new("Docile", -2, 0, 0, 0, 0, [], [], [(DamageClass.Melee, -2)]),

                    new("Drowsy",     -1, 0, 0, 0, 0, [], [], [(DamageClass.Ranged, -1)]),
                    new("Motionless", -2, 0, 0, 0, 0, [], [], [(DamageClass.Ranged, -2)]),

                    new("Lame",  -1, 0, 0, 0, 0, [], [], [(DamageClass.Magic, -1)]),
                    new("Lousy", -2, 0, 0, 0, 0, [], [], [(DamageClass.Magic, -2)]),

                    new("Hexed",      -3, 0, 0, -20, 0, [], [], []),
                    new("Brain-Dead", -6, 0, 0, -40, 0, [], [], []),

                    // Single modifiers
                    new("Antique", 4, 0, 0, 0, 10, [], [], []),

                    new("Promising", 1, 0, 0, 0, 0, [(DamageClass.Generic, 1)], [], []),
                    new("Fortunate", 3, 0, 0, 0, 0, [(DamageClass.Generic, 3)], [], []),

                    new("Occult", 6, 0, 0, 40, 0, [], [], []),

                    // Combination modifiers
                    new("Primordial", 6, 0, 2, 0, 10, [], [], []),

                    new("Brave",      3, 0, 0, 0, 0, [(DamageClass.Melee, 2)], [(DamageClass.Melee, 3)], []),
                    new("Infallible", 3, 0, 0, 0, 0, [(DamageClass.Ranged, 2)], [(DamageClass.Ranged, 3)], []),
                    new("Mystical",   3, 0, 0, 0, 0, [(DamageClass.Magic, 2)], [(DamageClass.Magic, 3)], []),

                    new("Conscious", 3, 0, 0, 20, 0, [], [(DamageClass.Magic, 3)], []),

                    new("Rushing", 2, 0, 1, 0, 0, [], [(DamageClass.Generic, 1)], []),
                    new("Swift",   4, 0, 2, 0, 0, [], [(DamageClass.Generic, 2)], []),

                    new("Scurvy",    2, 0, 0, 0, 0, [], [(DamageClass.Melee, 3), (DamageClass.Ranged, 3)], []),
                    new("Clercial",  2, 0, 0, 0, 0, [], [(DamageClass.Melee, 3), (DamageClass.Magic, 3)], []),
                    new("Stalking",  2, 0, 0, 0, 0, [], [(DamageClass.Melee, 3), (DamageClass.Summon, 3)], []),
                    new("Aberrant",  2, 0, 0, 0, 0, [], [(DamageClass.Ranged, 3), (DamageClass.Magic, 3)], []),
                    new("Ambushing", 2, 0, 0, 0, 0, [], [(DamageClass.Ranged, 3), (DamageClass.Summon, 3)], []),
                    new("Bizarre",   2, 0, 0, 0, 0, [], [(DamageClass.Magic, 3), (DamageClass.Summon, 3)], []),

                    new("Hot",     3, 0, 1, 0, 0, [], [], [(DamageClass.Melee, 2)]),
                    new("Burning", 5, 0, 2, 0, 0, [], [], [(DamageClass.Melee, 3)]),

                    new("Smart",    4, 0, 0, 20, 0, [(DamageClass.Magic, 2)], [], []),
                    new("Nerdy",    4, 0, 0, 20, 0, [], [(DamageClass.Magic, 2)], []),
                    new("Studious", 4, 0, 0, 20, 0, [], [], [(DamageClass.Magic, 2)]),

                    new("Thriving", 3, 0, 0, 0, 0, [(DamageClass.Melee, 1)], [(DamageClass.Melee, 1)], [(DamageClass.Melee, 1)]),
                    new("Vigorous", 3, 0, 0, 0, 0, [(DamageClass.Ranged, 1)], [(DamageClass.Ranged, 1)], [(DamageClass.Ranged, 1)]),
                    new("Educated", 3, 0, 0, 0, 0, [(DamageClass.Magic, 1)], [(DamageClass.Magic, 1)], [(DamageClass.Magic, 1)]),
                    new("Friendly", 3, 1, 0, 0, 0, [], [(DamageClass.Summon, 2)], []),

                    // Tradeoff modifiers
                    new("Secure",      5, 5, 0, 0, 0, [], [(DamageClass.Generic, -2)], []),
                    new("Reinforced",  6, 6, 0, 0, 0, [], [(DamageClass.Generic, -4)], []),
                    new("Unshakeable", 7, 7, 0, 0, 0, [], [(DamageClass.Generic, -6)], []),

                    new("Consistent", 5, 5, 0, 0, 0, [(DamageClass.Generic, -2)], [], []),
                    new("Concordant", 6, 6, 0, 0, 0, [(DamageClass.Generic, -4)], [], []),

                    new("Inconsistent", 5, 0, 0, 0, 0, [(DamageClass.Generic, 5)], [(DamageClass.Generic, -2)], []),
                    new("Discordant",   6, 0, 0, 0, 0, [(DamageClass.Generic, 6)], [(DamageClass.Generic, -4)], []),

                    new("Berserking", 5, -1, 0, 0, 0, [], [(DamageClass.Generic, 5)], []),
                    new("Enraged",    6, -2, 0, 0, 0, [], [(DamageClass.Generic, 6)], []),
                    new("Maddened",   7, -3, 0, 0, 0, [], [(DamageClass.Generic, 7)], []),

                    new("Bloodthirsty", 2, 0, 0, 0, 0, [], [(DamageClass.Melee, 4), (DamageClass.Ranged, -4), (DamageClass.Magic, -4), (DamageClass.Summon, -4)], []),
                    new("Calculated",   2, 0, 0, 0, 0, [], [(DamageClass.Melee, -4), (DamageClass.Ranged, 4), (DamageClass.Magic, -4), (DamageClass.Summon, -4)], []),
                    new("Spellbound",   2, 0, 0, 0, 0, [], [(DamageClass.Melee, -4), (DamageClass.Ranged, -4), (DamageClass.Magic, 4), (DamageClass.Summon, -4)], []),
                    new("Entrusting",   2, 0, 0, 0, 0, [], [(DamageClass.Melee, -4), (DamageClass.Ranged, -4), (DamageClass.Magic, -4), (DamageClass.Summon, 4)], []),

                    new("Solitary",   4, 0,  0, 0, 0, [(DamageClass.Magic, 3)], [(DamageClass.Magic, 3), (DamageClass.Summon, -10)], []),
                    new("Watchful",   4, 0, 0, 0, 0, [(DamageClass.Ranged, 3), (DamageClass.Magic, -6)], [(DamageClass.Ranged, 3), (DamageClass.Magic, -6)], []),
                    new("Airtight",   4, 0, 0, 0, 0, [(DamageClass.Melee, 3), (DamageClass.Ranged, -6)], [(DamageClass.Melee, 3), (DamageClass.Ranged, -6)], []),
                    new("Neighborly", 4, 3, 0, 0, 0, [(DamageClass.Magic, -6)], [(DamageClass.Summon, 3), (DamageClass.Magic, -6)], []),

                    new("Peaceable",  2, 4, 0, 0, 0, [(DamageClass.Melee, -2)], [(DamageClass.Melee, -2)], []),
                    new("Oncoming",   2, 4, 0, 0, 0, [(DamageClass.Ranged, -2)], [(DamageClass.Ranged, -2)], []),
                    new("Scientific", 2, 4, 0, 0, 0, [(DamageClass.Magic, -2)], [(DamageClass.Magic, -2)], []),
                    new("Individual", 2, 4, 0, 0, 0, [], [(DamageClass.Summon, -4)], []),

                    new("Heavy-Duty", 3, 0, 0, 0, 0, [], [(DamageClass.Melee, 6)], [(DamageClass.Melee, -4)]),
                    new("Weighted",   3, 0, 0, 0, 0, [], [(DamageClass.Ranged, 6)], [(DamageClass.Ranged, -4)]),
                    new("Tricky",     3, 0, 0, 0, 0, [], [(DamageClass.Magic, 6)], [(DamageClass.Magic, -4)]),

                    new("Guessable", 5, 0, 0, 0, 0, [(DamageClass.Generic, -12)], [(DamageClass.Generic, 8)], []),
                    new("Gambling",  5, 0, 0, 0, 0, [(DamageClass.Generic, 8)], [(DamageClass.Generic, -12)], []),

                    // Super modifiers
                    new("Golden", 5, 1, 1, 0, 1, [(DamageClass.Generic, 1)], [(DamageClass.Generic, 1)], []),
                ];

                foreach (var modifier in accessoryModifiers)
                {
                    mod.AddContent(modifier);
                }
            }

            public void Unload()
            {
            }
        }
        public override string LocalizationCategory => "Modifiers.Accessories";
        private static readonly string PrefixLocalizationKey = "Mods.ModifierMania.Modifiers.Accessories.Tooltips";

        public override PrefixCategory Category => PrefixCategory.Accessory;
        public override string Name => _name;

        protected readonly string _name;
        protected int _tier;
        protected int _defense = 0;
        protected int _movementSpeed = 0;
        protected int _mana = 0;
        protected int _miningSpeed = 0;
        protected IEnumerable<(DamageClass, int)> _crits = [];
        protected IEnumerable<(DamageClass, int)> _damages = [];
        protected IEnumerable<(DamageClass, float)> _speeds = [];

        public AccessoryModifier(string name, int tier, int defense, int movementSpeed, int mana, int miningSpeed, IEnumerable<(DamageClass, int)> crits, IEnumerable<(DamageClass, int)> damages, IEnumerable<(DamageClass, float)> speeds)
        {
            _name = name;
            _tier = tier;
            _defense = defense;
            _movementSpeed = movementSpeed;
            _mana = mana;
            _miningSpeed = miningSpeed;
            _crits = crits;
            _damages = damages;
            _speeds = speeds;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1f + (_tier * 0.05f);
        }

        public override void ApplyAccessoryEffects(Player player)
        {
            foreach (var c in _crits)
            {
                player.GetCritChance(c.Item1) += c.Item2;
            }
            foreach (var d in _damages)
            {
                player.GetDamage(d.Item1) += (d.Item2 / 100f);
            }
            foreach (var s in _speeds)
            {
                player.GetAttackSpeed(s.Item1) += (s.Item2 / 100f);
            }
            player.statDefense += _defense;
            player.statManaMax2 += _mana;
            player.moveSpeed += _movementSpeed;
            player.pickSpeed -= (_miningSpeed / 100f);
        }

        public override IEnumerable<TooltipLine> GetTooltipLines(Item item)
        {
            foreach (var d in _damages)
            {
                if (d.Item1 == DamageClass.Generic)
                {
                    yield return new TooltipLine(Mod, "PrefixAccDamage", d.Item2.ToString("+0;-#") + Language.GetTextValue("LegacyTooltip.39"))
                    {
                        IsModifier = true,
                        IsModifierBad = d.Item2 < 0,
                    };
                }
                else if (d.Item1 == DamageClass.Melee)
                {
                    yield return new TooltipLine(Mod, "PrefixAccMeleeDamage", Language.GetTextValue($"{PrefixLocalizationKey}.MeleeDamage", d.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = d.Item2 < 0,
                    };
                }
                else if (d.Item1 == DamageClass.Ranged)
                {
                    yield return new TooltipLine(Mod, "PrefixAccRangedDamage", Language.GetTextValue($"{PrefixLocalizationKey}.RangedDamage", d.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = d.Item2 < 0,
                    };
                }
                else if (d.Item1 == DamageClass.Magic)
                {
                    yield return new TooltipLine(Mod, "PrefixAccMagicDamage", Language.GetTextValue($"{PrefixLocalizationKey}.MagicDamage", d.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = d.Item2 < 0,
                    };
                }
                else if (d.Item1 == DamageClass.Summon)
                {
                    yield return new TooltipLine(Mod, "PrefixAccSummonDamage", Language.GetTextValue($"{PrefixLocalizationKey}.SummonDamage", d.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = d.Item2 < 0,
                    };
                }
            }

            foreach (var c in _crits)
            {
                if (c.Item1 == DamageClass.Generic)
                {
                    yield return new TooltipLine(Mod, "PrefixAccCritChance", c.Item2.ToString("+0;-#") + Language.GetTextValue("LegacyTooltip.41"))
                    {
                        IsModifier = true,
                        IsModifierBad = c.Item2 < 0,
                    };
                }
                else if (c.Item1 == DamageClass.Melee)
                {
                    yield return new TooltipLine(Mod, "PrefixAccMeleeCritChance", Language.GetTextValue($"{PrefixLocalizationKey}.MeleeCritChance", c.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = c.Item2 < 0,
                    };
                }
                else if (c.Item1 == DamageClass.Ranged)
                {
                    yield return new TooltipLine(Mod, "PrefixAccRangedCritChance", Language.GetTextValue($"{PrefixLocalizationKey}.RangedCritChance", c.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = c.Item2 < 0,
                    };
                }
                else if (c.Item1 == DamageClass.Magic)
                {
                    yield return new TooltipLine(Mod, "PrefixAccMagicCritChance", Language.GetTextValue($"{PrefixLocalizationKey}.MagicCritChance", c.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = c.Item2 < 0,
                    };
                }
            }

            if (_defense != 0)
                yield return new TooltipLine(Mod, "PrefixAccDefense", _defense.ToString("+0;-#") + Language.GetTextValue("LegacyTooltip.25"))
                {
                    IsModifier = true,
                    IsModifierBad = _defense < 0,
                };

            foreach (var s in _speeds)
            {
                if (s.Item1 == DamageClass.Melee)
                {
                    yield return new TooltipLine(Mod, "PrefixAccMeleeSpeed", s.Item2.ToString("+0;-#") + Language.GetTextValue("LegacyTooltip.47"))
                    {
                        IsModifier = true,
                        IsModifierBad = s.Item2 < 0,
                    };
                }
                else if (s.Item1 == DamageClass.Ranged)
                {
                    yield return new TooltipLine(Mod, "PrefixAccRangedSpeed", Language.GetTextValue($"{PrefixLocalizationKey}.RangedUseSpeed", s.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = s.Item2 < 0,
                    };
                }
                else if (s.Item1 == DamageClass.Magic)
                {
                    yield return new TooltipLine(Mod, "PrefixAccMagicSpeed", Language.GetTextValue($"{PrefixLocalizationKey}.MagicUseSpeed", s.Item2.ToString("+0;-#")))
                    {
                        IsModifier = true,
                        IsModifierBad = s.Item2 < 0,
                    };
                }
            }

            if (_mana != 0)
                yield return new TooltipLine(Mod, "PrefixAccMoveSpeed", _movementSpeed.ToString("+0;-#") + Language.GetTextValue("LegacyTooltip.46"))
                {
                    IsModifier = true,
                    IsModifierBad = _mana < 0,
                };

            if (_mana != 0)
                yield return new TooltipLine(Mod, "PrefixAccMaxMana", _mana.ToString("+0;-#") + " " + Language.GetTextValue("LegacyTooltip.31"))
                {
                    IsModifier = true,
                    IsModifierBad = _mana < 0,
                };

            if (_miningSpeed != 0)
                yield return new TooltipLine(Mod, "PrefixAccMiningSpeed", Language.GetTextValue($"{PrefixLocalizationKey}.MiningSpeed", _miningSpeed.ToString("+0;-#")))
                {
                    IsModifier = true,
                    IsModifierBad = _miningSpeed < 0,
                };
        }
    }
}
