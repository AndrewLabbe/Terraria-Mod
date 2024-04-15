using Terraria;
using Terraria.ModLoader;

namespace VoyagerMod.Content.Buffs
{
    public class Suffocating : ModBuff
    {

        public override void SetStaticDefaults(){
            Main.debuff[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen -= 25;
        }

    }
}