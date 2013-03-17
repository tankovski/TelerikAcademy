using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            engine.AddObject(theBall);


            //Implement MetheoridBall
            //MeteoriteBall meteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            //engine.AddObject(meteoriteBall);


            //Implement UnstopableBall and UnpassableBlocks 
            //UnstoppableBall theUnstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));
            //engine.AddObject(theUnstoppableBall);

            for (int i = 0; i < WorldRows; i++)
            {
                UnpassableBlock LeftWall = new UnpassableBlock(new MatrixCoords(i, 0));
                UnpassableBlock RightWall = new UnpassableBlock(new MatrixCoords(i, WorldCols - 1));
                engine.AddObject(LeftWall);
                engine.AddObject(RightWall);
            }
            for (int i = 1; i < WorldCols - 1; i++)
            {
                UnpassableBlock UppertWall = new UnpassableBlock(new MatrixCoords(0, i));
                engine.AddObject(UppertWall);
            }

            //Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            //engine.AddObject(theRacket);

            //Add indistructuble blocks
            for (int i = 1; i < WorldRows; i++)
            {
                IndestructibleBlock LeftWall = new IndestructibleBlock(new MatrixCoords(i, 1));
                IndestructibleBlock RightWall = new IndestructibleBlock(new MatrixCoords(i, WorldCols - 2));
                engine.AddObject(LeftWall);
                engine.AddObject(RightWall);
            }
            for (int i = 2; i < WorldCols - 2; i++)
            {
                IndestructibleBlock UppertWall = new IndestructibleBlock(new MatrixCoords(1, i));
                engine.AddObject(UppertWall);
            }

            //Adding several explosion blocks
            for (int i = 7; i < WorldCols-2; i+=7)
            {
                ExplodingBlock explosion = new ExplodingBlock(new MatrixCoords(3, i));
                engine.AddObject(explosion);
            }

            //Add several gift blocks
            for (int i = 2; i < WorldCols - 2; i += 7)
            {
                GiftBlock giftBlock = new GiftBlock(new MatrixCoords(4, i));
                engine.AddObject(giftBlock);
            }
            
            //Add shooting rocket
            ShootingRacket shoot = new ShootingRacket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);
            engine.AddObject(shoot);

        }


        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            //Engine gameEngine = new Engine(renderer, keyboard, 200);
            ShootingEngine gameEngine = new ShootingEngine(renderer,keyboard,200);
           

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
               
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
                
            };
            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootPlayerRacket();
            };
            Initialize(gameEngine);
           
            

            //
            
            gameEngine.Run();

        }
    }
}
