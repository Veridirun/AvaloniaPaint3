using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Avalonia;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using AvaloniaPaint.Models;
using Color = Avalonia.Media.Color;
using Point = Avalonia.Point;

namespace AvaloniaPaint.Models.Serializer
{
    public class XMLLoader : IShapeLoader
    {
        public ObservableCollection<PaintBaseFigure> Load(ObservableCollection<PaintBaseFigure> figureListTemp, string path)
        {
            XElement xelement = XElement.Load(path);

            IEnumerable<XElement> figures = xelement.Elements();

            ObservableCollection<PaintBaseFigure> figureList = new ObservableCollection<PaintBaseFigure>();

            foreach (var figure in figures)
            {
                if (figure.Name == "Line")
                {
                    PaintLine newfigure= new PaintLine();
                    IEnumerable<XElement> figureProperties = figure.Elements();

                    newfigure.Name = ParseName(figureProperties);

                    newfigure.StrokeThickness = ParseStrokeThickness(figureProperties);

                    newfigure.Stroke = ParseStroke(figureProperties);

                    newfigure.StartLinePoint = ParseStartLinePoint(figureProperties);

                    newfigure.StartPoint = ParseStartPoint(figureProperties);

                    newfigure.EndPoint = ParseEndPoint(figureProperties);

                    newfigure.RotateAngle = ParseRotateAngle(figureProperties);

                    newfigure.RotateCenter = ParseRotateCenter(figureProperties);

                    newfigure.Scale = ParseScale(figureProperties);

                    newfigure.Skew = ParseSkew(figureProperties);

                    figureList.Add(newfigure);
                }
                if (figure.Name == "Polyline")
                {
                    PaintPolyline newfigure = new PaintPolyline();
                    IEnumerable<XElement> figureProperties = figure.Elements();

                    newfigure.Name = ParseName(figureProperties);

                    newfigure.StrokeThickness = ParseStrokeThickness(figureProperties);

                    newfigure.Stroke = ParseStroke(figureProperties);

                    newfigure.Points = ParsePoints(figureProperties);

                    newfigure.StartPoint = ParseStartPoint(figureProperties);

                    newfigure.RotateAngle = ParseRotateAngle(figureProperties);

                    newfigure.RotateCenter = ParseRotateCenter(figureProperties);

                    newfigure.Scale = ParseScale(figureProperties);

                    newfigure.Skew = ParseSkew(figureProperties);

                    figureList.Add(newfigure);
                }
                if (figure.Name == "Polygon")
                {
                    PaintPolygon newfigure = new PaintPolygon();
                    IEnumerable<XElement> figureProperties = figure.Elements();

                    newfigure.Name = ParseName(figureProperties);

                    newfigure.StrokeThickness = ParseStrokeThickness(figureProperties);

                    newfigure.Stroke = ParseStroke(figureProperties);

                    newfigure.Points = ParsePoints(figureProperties);

                    newfigure.FillColor = ParseFillColor(figureProperties);

                    newfigure.StartPoint = ParseStartPoint(figureProperties);

                    newfigure.RotateAngle = ParseRotateAngle(figureProperties);

                    newfigure.RotateCenter = ParseRotateCenter(figureProperties);

                    newfigure.Scale = ParseScale(figureProperties);

                    newfigure.Skew = ParseSkew(figureProperties);

                    figureList.Add(newfigure);
                }
                if (figure.Name == "Rectangle")
                {
                    PaintRectangle newfigure = new PaintRectangle();
                    IEnumerable<XElement> figureProperties = figure.Elements();

                    newfigure.Name = ParseName(figureProperties);

                    newfigure.StrokeThickness = ParseStrokeThickness(figureProperties);

                    newfigure.Stroke = ParseStroke(figureProperties);

                    newfigure.Height = ParseHeight(figureProperties);

                    newfigure.Width = ParseWidth(figureProperties);

                    newfigure.StartPoint = ParseStartPoint(figureProperties);

                    newfigure.FillColor = ParseFillColor(figureProperties);

                    newfigure.RotateAngle = ParseRotateAngle(figureProperties);

                    newfigure.RotateCenter = ParseRotateCenter(figureProperties);

                    newfigure.Scale = ParseScale(figureProperties);

                    newfigure.Skew = ParseSkew(figureProperties);

                    figureList.Add(newfigure);
                }
                if (figure.Name == "Ellipse")
                {
                    PaintEllipse newfigure = new PaintEllipse();
                    IEnumerable<XElement> figureProperties = figure.Elements();

                    newfigure.Name = ParseName(figureProperties);

                    newfigure.StrokeThickness = ParseStrokeThickness(figureProperties);

                    newfigure.Stroke = ParseStroke(figureProperties);

                    newfigure.Height = ParseHeight(figureProperties);

                    newfigure.Width = ParseWidth(figureProperties);

                    newfigure.StartPoint = ParseStartPoint(figureProperties);

                    newfigure.FillColor = ParseFillColor(figureProperties);

                    newfigure.RotateAngle = ParseRotateAngle(figureProperties);

                    newfigure.RotateCenter = ParseRotateCenter(figureProperties);

                    newfigure.Scale = ParseScale(figureProperties);

                    newfigure.Skew = ParseSkew(figureProperties);

                    figureList.Add(newfigure);
                }
                if (figure.Name == "Path")
                {
                    PaintPath newfigure = new PaintPath();
                    IEnumerable<XElement> figureProperties = figure.Elements();

                    newfigure.Name = ParseName(figureProperties);

                    newfigure.StrokeThickness = ParseStrokeThickness(figureProperties);

                    newfigure.Stroke = ParseStroke(figureProperties);

                    newfigure.Data = ParseData(figureProperties);

                    newfigure.FillColor = ParseFillColor(figureProperties);

                    newfigure.StartPoint = ParseStartPoint(figureProperties);

                    newfigure.RotateAngle = ParseRotateAngle(figureProperties);

                    newfigure.RotateCenter = ParseRotateCenter(figureProperties);

                    newfigure.Scale = ParseScale(figureProperties);

                    newfigure.Skew = ParseSkew(figureProperties);

                    figureList.Add(newfigure);
                }
            }
            return figureList;
        }
        static string ParseName(IEnumerable<XElement> figureProperties)
        {
            return (from property in figureProperties
                    where property.Name == "Name"
                    select property.Value).First();
        }
        static int ParseStrokeThickness(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                       where property.Name == "StrokeThickness"
                       select property.Value).First());
        }

        static Color ParseStroke(IEnumerable<XElement> figureProperties)
        {
            return Color.Parse((from property in figureProperties
                                where property.Name == "Stroke"
                                select property.Value).First());
        }
        static int ParseHeight(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                       where property.Name == "Height"
                       select property.Value).First());
        }

        static int ParseWidth(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                              where property.Name == "Width"
                              select property.Value).First());
        }

        static Point ParseStartPoint(IEnumerable<XElement> figureProperties)
        {
            string[] substrings;
            string pointString;

            pointString = (from property in figureProperties
                           where property.Name == "StartPoint"
                           select property.Value).First();
            substrings = pointString.Split(' ');
            substrings[0].TrimEnd(',');
            return new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
        }
        static Point ParseStartLinePoint(IEnumerable<XElement> figureProperties)
        {
            string[] substrings;
            string pointString;

            pointString = (from property in figureProperties
                           where property.Name == "StartLinePoint"
                           select property.Value).First();
            substrings = pointString.Split(' ');
            substrings[0].TrimEnd(',');
            return new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
        }
        static Point ParseEndPoint(IEnumerable<XElement> figureProperties)
        {
            string[] substrings;
            string pointString;

            pointString = (from property in figureProperties
                           where property.Name == "EndPoint"
                           select property.Value).First();
            substrings = pointString.Split(' ');
            substrings[0].TrimEnd(',');
            return new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
        }
        static Color ParseFillColor(IEnumerable<XElement> figureProperties)
        {
            return Color.Parse((from property in figureProperties
                         where property.Name == "FillColor"
                         select property.Value).First());
        }

        static int ParseRotateAngle(IEnumerable<XElement> figureProperties)
        {
            return int.Parse((from property in figureProperties
                       where property.Name == "RotateAngle"
                       select property.Value).First());
        }
        static Point ParseRotateCenter(IEnumerable<XElement> figureProperties)
        {
            string[] substrings;
            string pointString;

            pointString = (from property in figureProperties
                           where property.Name == "RotateCenter"
                           select property.Value).First();
            substrings = pointString.Split(' ');
            substrings[0].TrimEnd(',');
            return new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
        }
        static Point ParseScale(IEnumerable<XElement> figureProperties)
        {
            string[] substrings;
            string pointString;

            pointString = (from property in figureProperties
                           where property.Name == "Scale"
                           select property.Value).First();
            substrings = pointString.Split(' ');
            substrings[0].TrimEnd(',');
            return new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
        }
        static Point ParseSkew(IEnumerable<XElement> figureProperties)
        {
            string[] substrings;
            string pointString;

            pointString = (from property in figureProperties
                           where property.Name == "Skew"
                           select property.Value).First();
            substrings = pointString.Split(' ');
            substrings[0].TrimEnd(',');
            return new Point(double.Parse(substrings[0]), double.Parse(substrings[1]));
        }
        static string ParseData(IEnumerable<XElement> figureProperties)
        {
            return (from property in figureProperties
                    where property.Name == "Data"
                    select property.Value).First();
        }
        static List<Point> ParsePoints(IEnumerable<XElement> figureProperties)
        {
            string[] substrings;
            string pointString;
            XElement pointsElementTree = (from property in figureProperties
                                          where property.Name == "Points"
                                          select property).First();
            IEnumerable<XElement> pointsElement = from el in pointsElementTree.Elements()
                                                  where el.Name == "Point"
                                                  select el;
            List<Point> points = new List<Point>();
            foreach (XElement pointElement in pointsElement)
            {
                pointString = pointElement.Value;
                substrings = pointString.Split(' ');
                substrings[0].TrimEnd(',');
                points.Add(new Point(double.Parse(substrings[0]), double.Parse(substrings[1])));
            }
            return points;
        }
    }
}
