﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ThanaNita.MonoGameTnt;

namespace CP215Project
{
    internal class Room6 : Actor
    {
        ExitNotifier exitNotifier;
        CameraMan cameraMan;
        public Room6(Vector2 screenSize, ExitNotifier exitNotifier, CameraMan cameraMan)
        {
            this.exitNotifier = exitNotifier;
            this.cameraMan = cameraMan;

            var builder = new TileMapBuilder();

            var tileMap1 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room6_layer1.csv");
            var tileMap2 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room6_layer2.csv");
            var tileMap3 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room6_layer3.csv");
            var tileMap4 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room6_layer4.csv");
            var tileMap5 = builder.CreateSimple("tilemap.png", new Vector2(16, 16), 100, 100,
                                                "room6_layer5.csv");

            var visual = new Actor() { Position = new Vector2(415, 0) };
            visual.Scale = new Vector2(2.25f, 2.25f);
            visual.Add(tileMap1);
            visual.Add(tileMap2);
            visual.Add(tileMap3);
            visual.Add(tileMap4);
            visual.Add(tileMap5);

            var sorter = new TileMapSorter();
            sorter.Add(tileMap1);
            sorter.Add(tileMap2);
            sorter.Add(tileMap3);
            sorter.Add(tileMap4);
            sorter.Add(tileMap5);

            visual.Add(sorter);

            Add(visual);

            //Message Window
            var messagewindow = new Messagewindow6(new Vector2(1440, 250), Color.Black, Color.White, 10);
            messagewindow.Position = new Vector2(100, 830);
            Add(messagewindow);
        }
    }
}
