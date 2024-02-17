using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace ModifierMania.Modifiers.Accessories
{
    [Autoload(false)]
    internal class AccessoryModifier : CommonModifier
    {
        class AccessoryModifierLoader : ILoadable
        {
            public void Load(Mod mod)
            {
                // Bad modifiers
                mod.AddContent(new AccessoryModifier("Cursed", -1, 0, 0, 0, 0, [(DamageClass.Generic, -1)], [], []));
                mod.AddContent(new AccessoryModifier("Hapless", -2, 0, 0, 0, 0, [(DamageClass.Generic, -2)], [], []));
                mod.AddContent(new AccessoryModifier("Weakened", -1, 0, 0, 0, 0, [], [(DamageClass.Generic, -1)], []));
                mod.AddContent(new AccessoryModifier("Soft", -2, 0, 0, 0, 0, [], [(DamageClass.Generic, -2)], []));
                mod.AddContent(new AccessoryModifier("Vulnerable", -1, -1, 0, 0, 0, [], [], []));
                mod.AddContent(new AccessoryModifier("Delicate", -2, -2, 0, 0, 0, [], [], []));
                mod.AddContent(new AccessoryModifier("Hefty", -1, 0, -2, 0, 0, [], [], []));
                mod.AddContent(new AccessoryModifier("Weighty", -2, 0, -4, 0, 0, [], [], []));

                // Single modifiers
                mod.AddContent(new AccessoryModifier("Antique", 4, 0, 0, 0, 10, [], [], []));
                mod.AddContent(new AccessoryModifier("Promising", 1, 0, 0, 0, 0, [(DamageClass.Generic, 1)], [], []));
                mod.AddContent(new AccessoryModifier("Fortunate", 3, 0, 0, 0, 0, [(DamageClass.Generic, 3)], [], []));

                // Combination modifiers
                mod.AddContent(new AccessoryModifier("Primordial", 6, 0, 2, 0, 10, [], [], []));
                mod.AddContent(new AccessoryModifier("Brave", 3, 0, 0, 0, 0, [(DamageClass.Melee, 2)], [(DamageClass.Melee, 3)], []));
                mod.AddContent(new AccessoryModifier("Infallible", 3, 0, 0, 0, 0, [(DamageClass.Ranged, 2)], [(DamageClass.Ranged, 3)], []));
                mod.AddContent(new AccessoryModifier("Mystical", 3, 0, 0, 0, 0, [(DamageClass.Magic, 2)], [(DamageClass.Magic, 3)], []));
                mod.AddContent(new AccessoryModifier("Conscious", 3, 0, 0, 20, 0, [], [(DamageClass.Magic, 3)], []));

                // Tradeoff modifiers
                mod.AddContent(new AccessoryModifier("Secure", 5, 5, 0, 0, 0, [], [(DamageClass.Generic, -2)], []));
                mod.AddContent(new AccessoryModifier("Reinforced", 6, 6, 0, 0, 0, [], [(DamageClass.Generic, -4)], []));
                mod.AddContent(new AccessoryModifier("Unshakeable", 7, 7, 0, 0, 0, [], [(DamageClass.Generic, -6)], []));
                mod.AddContent(new AccessoryModifier("Consistent", 5, 5, 0, 0, 0, [(DamageClass.Generic, -2)], [], []));
                mod.AddContent(new AccessoryModifier("Concordant", 6, 6, 0, 0, 0, [(DamageClass.Generic, -4)], [], []));
                mod.AddContent(new AccessoryModifier("Inconsistent", 5, 0, 0, 0, 0, [(DamageClass.Generic, 5)], [(DamageClass.Generic, -2)], []));
                mod.AddContent(new AccessoryModifier("Discordant", 6, 0, 0, 0, 0, [(DamageClass.Generic, 6)], [(DamageClass.Generic, -4)], []));

                mod.AddContent(new AccessoryModifier("Berserking", 5, -1, 0, 0, 0, [], [(DamageClass.Generic, 5)], []));
                mod.AddContent(new AccessoryModifier("Enraged", 6, -2, 0, 0, 0, [], [(DamageClass.Generic, 6)], []));
                mod.AddContent(new AccessoryModifier("Maddened", 7, -3, 0, 0, 0, [], [(DamageClass.Generic, 7)], []));

                mod.AddContent(new AccessoryModifier("Bloodthirsty", 2, 0, 0, 0, 0, [], [(DamageClass.Melee,  4), (DamageClass.Ranged, -4), (DamageClass.Magic, -4), (DamageClass.Summon, -4)], []));
                mod.AddContent(new AccessoryModifier("Calculated", 2, 0, 0, 0, 0, [],   [(DamageClass.Melee, -4), (DamageClass.Ranged,  4), (DamageClass.Magic, -4), (DamageClass.Summon, -4)], []));
                mod.AddContent(new AccessoryModifier("Spellbound", 2, 0, 0, 0, 0, [],   [(DamageClass.Melee, -4), (DamageClass.Ranged, -4), (DamageClass.Magic,  4), (DamageClass.Summon, -4)], []));
                mod.AddContent(new AccessoryModifier("Entrusting", 2, 0, 0, 0, 0, [],   [(DamageClass.Melee, -4), (DamageClass.Ranged, -4), (DamageClass.Magic, -4), (DamageClass.Summon,  4)], []));

                mod.AddContent(new AccessoryModifier("Golden", 5, 1, 1, 0, 1, [(DamageClass.Generic, 1)], [(DamageClass.Generic, 1)], []));
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
