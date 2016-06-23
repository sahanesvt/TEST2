using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BeamProperties
{
    public class Properties
    {
        public static double bft;
        public static double tft;
        public static double D;
        public static double tw;
        public static double bfb;
        public static double tfb;
        public static double Atf;
        public static double Aweb;
        public static double Abf;
        public static double Ytf;
        public static double Yweb;
        public static double Ybf;
        public static double Itf;
        public static double Iweb;
        public static double Ibf;      
        public static double area;
        public static double I;
        public static double CG;
        public static double NA;
        public static double Stop;
        public static double Sbot;
        public static double PNA;
        public static double PCGtop;
        public static double PCGbot;
        public static double Z;
        
        
        public static double PartArea(double width, double height)
        {
            area = width*height;
            return area;
        }
        public static double PartCG(double first, double second, double last)
        {
            CG = first+second+last/2;
            return CG;
        }       
        
        public static double BeamArea(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            Atf = Properties.PartArea(bft, tft);
            Aweb = Properties.PartArea(D, tw);
            Abf = Properties.PartArea(bfb, tfb);
            area = Atf + Aweb + Abf;
            return area;
        }
        public static double NeutralAxis(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            Atf = Properties.PartArea(bft, tft);
            Aweb = Properties.PartArea(D, tw);
            Abf = Properties.PartArea(bfb, tfb);
            Ytf = Properties.PartCG(tfb, D, tft);
            Yweb = Properties.PartCG(tfb, 0, D);
            Ybf = Properties.PartCG(0, 0, tfb);
            NA = (Atf * Ytf + Aweb * Yweb + Abf * Ybf) / (Atf + Aweb + Abf);
            return NA; 
        }
        public static double PartMomOfInert(double width, double height)
        {
            I = width * Math.Pow(height,3)/12;
            return I;
        }        
        
        public static double MomentOfIneria(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            Atf = Properties.PartArea(bft, tft);
            Aweb = Properties.PartArea(D, tw);
            Abf = Properties.PartArea(bfb, tfb);
            Ytf = Properties.PartCG(tfb, D, tft);
            Yweb = Properties.PartCG(tfb, 0, D);
            Ybf = Properties.PartCG(0, 0, tfb);
            NA = Properties.NeutralAxis(bft, tft, D, tw, bfb, tfb);
            Itf = Properties.PartMomOfInert(bft, tft);
            Iweb = Properties.PartMomOfInert(tw, D);
            Ibf = Properties.PartMomOfInert(bfb, tfb);
            I = Itf + Atf * Math.Pow(Ytf - NA, 2) + Iweb + Aweb * Math.Pow(Yweb - NA, 2) + Ibf + Abf * Math.Pow(Ybf - NA, 2);
            return I;
        }
        public static double ElastSectModTop(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            Ytf = Properties.PartCG(tfb, D, tft);
            NA = Properties.NeutralAxis(bft, tft, D, tw, bfb, tfb);
            I = Properties.MomentOfIneria(bft, tft, D, tw, bfb, tfb);
            Stop = I / (Ytf - NA + tft / 2);
            return Stop;
        }
        public static double ElastSectModBot(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            Ybf = Properties.PartCG(0, 0, tfb);
            NA = Properties.NeutralAxis(bft, tft, D, tw, bfb, tfb);
            I = Properties.MomentOfIneria(bft, tft, D, tw, bfb, tfb);            
            Sbot = I / (NA - Ybf + tfb / 2);
            return Sbot;
        }
        public static double PlastNeutralAxis(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            PNA = tfb + (D + (bft * tft - bfb * tfb) / tw) / 2;
            return PNA;
        }
        public static double PNAtoTopCG(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            area = Properties.BeamArea(bft, tft, D, tw, bfb, tfb);
            PNA = Properties.PlastNeutralAxis(bft, tft, D, tw, bfb, tfb);
            PCGtop = (bft * tft * (tft / 2 + D + tfb - PNA) + tw * Math.Pow(D - PNA + tfb, 2) / 2) * 2 / area;
            return PCGtop;
        }
        public static double PNAtoBotCG(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            area = Properties.BeamArea(bft, tft, D, tw, bfb, tfb);
            PNA = Properties.PlastNeutralAxis(bft, tft, D, tw, bfb, tfb);
            PCGbot = (bfb * tfb * (PNA - tfb / 2) + tw * Math.Pow(PNA - tfb, 2) / 2) * 2 / area;
            return PCGbot;
        }        
        public static double PlastSectMod(double bft, double tft, double D, double tw, double bfb, double tfb)
        {
            area = Properties.BeamArea(bft, tft, D, tw, bfb, tfb);
            PNA = Properties.PlastNeutralAxis(bft, tft, D, tw, bfb, tfb);
            PCGtop = Properties.PNAtoTopCG(bft, tft, D, tw, bfb, tfb);
            PCGbot = Properties.PNAtoBotCG(bft, tft, D, tw, bfb, tfb);
            Z = area / 2 * (PCGtop + PCGbot);
            return Z;
        }
    }

    public class Beams
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Number of Beams : ");
            int NoBeams = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < NoBeams; i++)
            {
                Console.WriteLine("Enter Beam {0} top flange width, bft (in) : ",i+1);
                double bft = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Beam {0} top flange thickness, tft (in) : ", i + 1);
                double tft = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Beam {0} web depth, D (in) : ", i + 1);
                double D = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Beam {0} web thickness, tw (in) : ", i + 1);
                double tw = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Beam {0} bottom flange width, bfb (in) : ", i + 1);
                double bfb = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter Beam {0} bottom flange thickness, tfb (in) : ", i + 1);
                double tfb = Convert.ToDouble(Console.ReadLine());
                double area = Properties.BeamArea(bft, tft, D, tw, bfb, tfb);
                double NA = Properties.NeutralAxis(bft, tft, D, tw, bfb, tfb);
                double I = Properties.MomentOfIneria(bft, tft, D, tw, bfb, tfb);
                double Stop = Properties.ElastSectModTop(bft, tft, D, tw, bfb, tfb);
                double Sbot = Properties.ElastSectModBot(bft, tft, D, tw, bfb, tfb);
                double PNA = Properties.PlastNeutralAxis(bft, tft, D, tw, bfb, tfb);
                double Z = Properties.PlastSectMod(bft, tft, D, tw, bfb, tfb);
                Console.WriteLine("*********** BEAM {0} SECTION PROPERTIES***********", i + 1);
                Console.WriteLine("Area of beam is {0} in^2", Math.Round(area, 2));
                Console.WriteLine("Elastic Neutral Axis is {0} in", Math.Round(NA, 2));
                Console.WriteLine("Elastic Moment of Inertia is {0} in^4", Math.Round(I, 2));
                Console.WriteLine("Elastic Section Modulus of Top Flange is {0} in^3", Math.Round(Stop, 2));
                Console.WriteLine("Elastic Section Modulus of Bottom Flange is {0} in^3", Math.Round(Sbot, 2));
                Console.WriteLine("Plastic Neutral Axis is {0} in", Math.Round(PNA, 2));
                Console.WriteLine("Plastic Section Modulus is {0} in^3", Math.Round(Z, 2));
                Console.WriteLine("");
            }
            Console.Read();
        }
    }
}

