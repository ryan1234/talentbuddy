using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

class MyClass {
private double DotProduct(double[] pointA, double[] pointB, double[] pointC)
{
    double[] AB = new double[2];
    double[] BC = new double[2];
    AB[0] = pointB[0] - pointA[0];
    AB[1] = pointB[1] - pointA[1];
    BC[0] = pointC[0] - pointB[0];
    BC[1] = pointC[1] - pointB[1];
    double dot = AB[0] * BC[0] + AB[1] * BC[1];

    return dot;
}

//Compute the cross product AB x AC
private double CrossProduct(double[] pointA, double[] pointB, double[] pointC)
{
    double[] AB = new double[2];
    double[] AC = new double[2];
    AB[0] = pointB[0] - pointA[0];
    AB[1] = pointB[1] - pointA[1];
    AC[0] = pointC[0] - pointA[0];
    AC[1] = pointC[1] - pointA[1];
    double cross = AB[0] * AC[1] - AB[1] * AC[0];

    return cross;
}

//Compute the distance from A to B
double Distance(double[] pointA, double[] pointB)
{
    double d1 = pointA[0] - pointB[0];
    double d2 = pointA[1] - pointB[1];

    return Math.Sqrt(d1 * d1 + d2 * d2);
}

//Compute the distance from AB to C
//if isSegment is true, AB is a segment, not a line.
double LineToPointDistance2D(double[] pointA, double[] pointB, double[] pointC, 
    bool isSegment)
{
    double dist = CrossProduct(pointA, pointB, pointC) / Distance(pointA, pointB);
    if (isSegment)
    {
        double dot1 = DotProduct(pointA, pointB, pointC);
        if (dot1 > 0) 
            return Distance(pointB, pointC);

        double dot2 = DotProduct(pointB, pointA, pointC);
        if (dot2 > 0) 
            return Distance(pointA, pointC);
    }
    return Math.Abs(dist);
}       
    
    public void map_matcher(string[] segments, string[] paths) {    
        List<Segment> ss = new List<Segment>();
        
        foreach (string segment in segments.ToList())
        {
            ss.Add(new Segment(segment));
        }
        
        foreach (string path in paths.ToList())
        {
            string[] subPaths = path.Split(';');
            List<Path> ps = new List<Path>();
            
            foreach (string subPath in subPaths.ToList())
            {
                ps.Add(new Path(subPath));
            }
            
            var farthestSubPath = ps.Last();
            double minShortestLength = 1000000;
            Segment closestSegment = null;
            
            // Go through each segment with our farthest point on the path
            // and find the shortest distance to a segment.
            foreach (var s in ss)
            {
                double shortestLength = LineToPointDistance2D(s.p0, s.p1, farthestSubPath.p0, true);
                
                if (shortestLength < minShortestLength)
                {
                    minShortestLength = shortestLength;
                    closestSegment = s;
                }
            }
            
            // y = mx + b
            double? nullableSlope = closestSegment.GetSlope();            
            double finalX = 0;
            double finalY = 0;
            
            if (nullableSlope.HasValue) 
            {
                double m = nullableSlope.Value;
                double b = closestSegment.p0[1] - (m * closestSegment.p0[0]);                                
                finalX = ((m * farthestSubPath.p0[1]) + farthestSubPath.p0[0] - (m * b)) / ((m * m) + 1);
                finalY = (((m * m) * farthestSubPath.p0[1]) + (m * farthestSubPath.p0[0]) + b) / ((m * m) + 1);
            }
            else
            {    
                finalX = closestSegment.p0[0];
                finalY = farthestSubPath.p0[1];
            }
            
            finalX = finalX + 0.2;
            finalY = finalY + 0.2;
            
            System.Console.WriteLine(finalX + "," + finalY);
        }
    }
    
    private class Path
    {
        public double[] p0 { get; set; }
        public double time { get; set; }
        
        public Path(string path)
        {
            string[] tokens = path.Split(',');
            
            this.p0 = new double[2];
            this.p0[0] = double.Parse(tokens[0]);
            this.p0[1] = double.Parse(tokens[1]);
            
            this.time = double.Parse(tokens[2]);
        }
    }
    
    private class Segment
    {
        public double[] p0 { get; set; }
        public double[] p1 { get; set; }
        
        public Segment(string segment)
        {
            string[] tokens = segment.Split(',');
            
            this.p0 = new double[2];
            this.p0[0] = double.Parse(tokens[0]);
            this.p0[1] = double.Parse(tokens[1]);            
            
            this.p1 = new double[2];
            this.p1[0] = double.Parse(tokens[2]);
            this.p1[1] = double.Parse(tokens[3]);            
        }
        
        public double? GetSlope()
        {
            if (p1[0] - p0[0] == 0) 
            { 
                return null; 
            }
            else
            {
                return ((p1[1] - p0[1]) / (p1[0] - p0[0]));
            }
        }
    }
}
