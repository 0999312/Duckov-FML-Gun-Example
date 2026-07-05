using FastModdingLib.Audio;

namespace DuckovWeaponExample
{
    public static class AudioDatas
    {
        public static AudioData mk23_shoot = new AudioData
        {
            Path = "assets/sounds/shoot_mk23.ogg",
            Eventname = "SFX/Combat/Gun/Shoot/shoot_mk23",
            MinDistance = 1.0F,
            MaxDistance = 50.0F,
        };
        public static AudioData mk23_shoot_mute = new AudioData
        {
            Path = "assets/sounds/shoot_mk23_mute.ogg",
            Eventname = "SFX/Combat/Gun/Shoot/shoot_mk23_mute",
            MinDistance = 1.0F,
            MaxDistance = 50.0F,
        };

        public static AudioData mk23_reload = new AudioData
        {
            Path = "assets/sounds/mag_mk23_start.ogg",
            Eventname = "SFX/Combat/Gun/Reload/mag_mk23_start",
            MinDistance = 1.0F,
            MaxDistance = 20.0F,
        };
        public static AudioData mk23_reload_end = new AudioData
        {
            Path = "assets/sounds/mag_mk23_end.ogg",
            Eventname = "SFX/Combat/Gun/Reload/mag_mk23_end",
            MinDistance = 1.0F,
            MaxDistance = 20.0F,
        };
    }
}
