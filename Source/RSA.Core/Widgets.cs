﻿namespace RSA.Core
{
    using UnityEngine;

    using Verse;
    using Verse.Sound;

    [StaticConstructorOnStartup]
    public static class ExtraWidgets
    {
        public static Texture2D ButtonBGAtlas;

        public static Texture2D ButtonBGAtlasClick;

        public static Texture2D ButtonBGAtlasMouseover;

        static ExtraWidgets()
        {
            ButtonBGAtlas = ContentFinder<Texture2D>.Get("UI/Widgets/ButtonBG", true);
            ButtonBGAtlasMouseover = ContentFinder<Texture2D>.Get("UI/Widgets/ButtonBGMouseover", true);
            ButtonBGAtlasClick = ContentFinder<Texture2D>.Get("UI/Widgets/ButtonBGClick", true);
        }

        public static bool ButtonImage(
            Rect butRect,
            Texture2D tex,
            bool doMouseoverSound = false,
            TipSignal? tipSignal = null,
            Rect? texRect = null)
        {
            Texture2D atlas = ButtonBGAtlas;
            if (Mouse.IsOver(butRect))
            {
                atlas = ButtonBGAtlasMouseover;
                if (Input.GetMouseButton(0))
                {
                    atlas = ButtonBGAtlasClick;
                }
            }

            bool result = Widgets.ButtonImage(butRect, atlas);
            if (doMouseoverSound)
            {
                MouseoverSounds.DoRegion(butRect);
            }

            GUI.DrawTexture(texRect ?? butRect, tex);

            if (tipSignal != null)
            {
                TooltipHandler.TipRegion(butRect, tipSignal.Value);
            }

            return result;
        }
    }
}