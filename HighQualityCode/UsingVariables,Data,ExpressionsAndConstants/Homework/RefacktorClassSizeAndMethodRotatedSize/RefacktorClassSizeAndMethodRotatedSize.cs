using System;

class RefacktorClassSizeAndMethodRotatedSize
{
    public static Rectangle GetRotatedSize(
      Rectangle inputRectangle, double angleOfTheFigureThatWillBeRotaed)
    {
        double cosOfTheFigure = Math.Abs(Math.Cos(angleOfTheFigureThatWillBeRotaed));
        double sinOfTheFigure = Math.Abs(Math.Sin(angleOfTheFigureThatWillBeRotaed));

        double widthOfTheRotatedFigure = cosOfTheFigure * inputRectangle.Width + sinOfTheFigure * inputRectangle.Height;
        double heightOfTheRotatedFigure = sinOfTheFigure * inputRectangle.Width + cosOfTheFigure * inputRectangle.Height;

        Rectangle rotatedRectangle = new Rectangle(widthOfTheRotatedFigure, heightOfTheRotatedFigure);

        return rotatedRectangle;
    }

    static void Main(string[] args)
    {
    }
}