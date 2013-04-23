using System;

class RefactorIfStatements
{
    static void Main(string[] args)
    {
        //if statement one
        Potato potato = new Patato();
        bool isPatatoGoodForCook = !potato.HasNotBeenPeeled && !potato.IsRotten;
        if (potato != null && isPatatoGoodForCook)
        {
            Cook(potato);
        }
        
        //if statement two
        bool isXInTheRange = x >= MIN_X && x =< MAX_X;
        bool isYInTheRange = y >= MIN_Y && y =< MAX_Y;
        bool isCellGoodForVisit = !shouldNotVisitCell;
        if (isXInTheRange && isYInTheRange && isCellGoodForVisit)
        {
            VisitCell();
        }

    }
}

