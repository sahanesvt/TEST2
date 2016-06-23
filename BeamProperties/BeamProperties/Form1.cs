using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BeamProperties
{
    //public class Property
    //{
    //    public static double bft;
    //    public static double tft;
    //    public static double D;
    //    public static double tw;
    //    public static double bfb;
    //    public static double tfb;
    //    public static double Atf;
    //    public static double Aweb;
    //    public static double Abf;
    //    public static double Ytf;
    //    public static double Yweb;
    //    public static double Ybf;
    //    public static double Itf;
    //    public static double Iweb;
    //    public static double Ibf;
    //    public static double Area;
    //    public static double I;
    //    public static double CG;
    //    public static double NA;
    //    public static double Stop;
    //    public static double Sbot;
    //    public static double PNA;
    //    public static double PCGtop;
    //    public static double PCGbot;
    //    public static double Z;


    //    public static double PartArea(double width, double height)
    //    {
    //        Area = width * height;
    //        return Area;
    //    }
    //    public static double PartCG(double first, double second, double last)
    //    {
    //        CG = first + second + last / 2;
    //        return CG;
    //    }

    //    public static double BeamArea(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        Atf = Property.PartArea(bft, tft);
    //        Aweb = Property.PartArea(D, tw);
    //        Abf = Property.PartArea(bfb, tfb);
    //        Area = Atf + Aweb + Abf;
    //        return Area;
    //    }
    //    public static double NeutralAxis(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        Atf = Property.PartArea(bft, tft);
    //        Aweb = Property.PartArea(D, tw);
    //        Abf = Property.PartArea(bfb, tfb);
    //        Ytf = Property.PartCG(tfb, D, tft);
    //        Yweb = Property.PartCG(tfb, 0, D);
    //        Ybf = Property.PartCG(0, 0, tfb);
    //        NA = (Atf * Ytf + Aweb * Yweb + Abf * Ybf) / (Atf + Aweb + Abf);
    //        return NA;
    //    }
    //    public static double PartMomOfInert(double width, double height)
    //    {
    //        I = width * Math.Pow(height, 3) / 12;
    //        return I;
    //    }

    //    public static double MomentOfIneria(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        Atf = Property.PartArea(bft, tft);
    //        Aweb = Property.PartArea(D, tw);
    //        Abf = Property.PartArea(bfb, tfb);
    //        Ytf = Property.PartCG(tfb, D, tft);
    //        Yweb = Property.PartCG(tfb, 0, D);
    //        Ybf = Property.PartCG(0, 0, tfb);
    //        NA = Property.NeutralAxis(bft, tft, D, tw, bfb, tfb);
    //        Itf = Property.PartMomOfInert(bft, tft);
    //        Iweb = Property.PartMomOfInert(tw, D);
    //        Ibf = Property.PartMomOfInert(bfb, tfb);
    //        I = Itf + Atf * Math.Pow(Ytf - NA, 2) + Iweb + Aweb * Math.Pow(Yweb - NA, 2) + Ibf + Abf * Math.Pow(Ybf - NA, 2);
    //        return I;
    //    }
    //    public static double ElastSectModTop(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        Ytf = Property.PartCG(tfb, D, tft);
    //        NA = Property.NeutralAxis(bft, tft, D, tw, bfb, tfb);
    //        I = Property.MomentOfIneria(bft, tft, D, tw, bfb, tfb);
    //        Stop = I / (Ytf - NA + tft / 2);
    //        return Stop;
    //    }
    //    public static double ElastSectModBot(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        Ybf = Property.PartCG(0, 0, tfb);
    //        NA = Property.NeutralAxis(bft, tft, D, tw, bfb, tfb);
    //        I = Property.MomentOfIneria(bft, tft, D, tw, bfb, tfb);
    //        Sbot = I / (NA - Ybf + tfb / 2);
    //        return Sbot;
    //    }
    //    public static double PlastNeutralAxis(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        PNA = tfb + (D + (bft * tft - bfb * tfb) / tw) / 2;
    //        return PNA;
    //    }
    //    public static double PNAtoTopCG(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        Area = Property.BeamArea(bft, tft, D, tw, bfb, tfb);
    //        PNA = Property.PlastNeutralAxis(bft, tft, D, tw, bfb, tfb);
    //        PCGtop = (bft * tft * (tft / 2 + D + tfb - PNA) + tw * Math.Pow(D - PNA + tfb, 2) / 2) * 2 / Area;
    //        return PCGtop;
    //    }
    //    public static double PNAtoBotCG(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        Area = Property.BeamArea(bft, tft, D, tw, bfb, tfb);
    //        PNA = Property.PlastNeutralAxis(bft, tft, D, tw, bfb, tfb);
    //        PCGbot = (bfb * tfb * (PNA - tfb / 2) + tw * Math.Pow(PNA - tfb, 2) / 2) * 2 / Area;
    //        return PCGbot;
    //    }
    //    public static double PlastSectMod(double bft, double tft, double D, double tw, double bfb, double tfb)
    //    {
    //        Area = Property.BeamArea(bft, tft, D, tw, bfb, tfb);
    //        PNA = Property.PlastNeutralAxis(bft, tft, D, tw, bfb, tfb);
    //        PCGtop = Property.PNAtoTopCG(bft, tft, D, tw, bfb, tfb);
    //        PCGbot = Property.PNAtoBotCG(bft, tft, D, tw, bfb, tfb);
    //        Z = Area / 2 * (PCGtop + PCGbot);
    //        return Z;
    //    }
    //}
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //declare variables
        // top flange thickness
        Double tft;
        // top flange width
        Double bft;
        // web depth
        Double D;
        // web thickness
        Double tw;
        // bottom flange thickness
        Double tfb;
        // bottom flange width
        Double bfb;
        // top flange area
        Double Atf;
        // web area
        Double Aweb;
        // bottom flange area
        Double Abf;
        // total area
        Double Area;
        // distance of top flange centroid to bottom of beam
        Double Ytf;
        // distance of web centroid to bottom of beam
        Double Yweb;
        // distance of bottom flange centroid to bottom of beam
        Double Ybf;
        // distance of elastic neutral axis to bottom of beam
        Double NA;
        // moment of inertia of top flange
        Double Itf;
        // moment of inertia of web
        Double Iweb;
        // moment of inertia of bottom flange
        Double Ibf;
        // moment of inertia of beam
        Double I;
        // elastic section modulus of top flange
        Double Stop;
        // elastic section modulus of bottom flange
        Double Sbot;
        // distance of plastic neutral axis to bottom of beam
        Double PNA;
        // distance of centroid of top half area to PNA
        Double PCGtop;
        // distance of centroid of bottom half area to PNA
        Double PCGbot;
        // plastic section modulus of beam
        Double Z;
        

        private void Calculate_Click(object sender, EventArgs e)
        {
                //try
                //{

                    //define input values
                     //bft = Convert.ToDouble(textbft.Text);
                     //tft = Convert.ToDouble(texttft.Text); 
                     //D = Convert.ToDouble(textD.Text);
                     //tw = Convert.ToDouble(texttw.Text);
                     //bfb = Convert.ToDouble(textbfb.Text);
                     //tfb = Convert.ToDouble(texttfb.Text);
                    //double Area = Property.BeamArea(bft, tft, D, tw, bfb, tfb);
                    //double NA = Property.NeutralAxis(bft, tft, D, tw, bfb, tfb);
                    //double I = Property.MomentOfIneria(bft, tft, D, tw, bfb, tfb);
                    //double Stop = Property.ElastSectModTop(bft, tft, D, tw, bfb, tfb);
                    //double Sbot = Property.ElastSectModBot(bft, tft, D, tw, bfb, tfb);
                    //double PNA = Property.PlastNeutralAxis(bft, tft, D, tw, bfb, tfb);
                    //double Z = Property.PlastSectMod(bft, tft, D, tw, bfb, tfb);

                    //calculate area
                    Atf = bft * tft;
                    Aweb = D * tw;
                    Abf = bfb * tfb;
                    Area = Atf + Aweb + Abf;
                    txtArea.Text = Convert.ToString(Math.Round(Area, 2));

                    //calculate neutral axis
                    Ytf = tfb + D + tft / 2;
                    Yweb = tfb + D / 2;
                    Ybf = tfb / 2;
                    NA = (Atf * Ytf + Aweb * Yweb + Abf * Ybf) / Area;
                    txtNA.Text = Convert.ToString(Math.Round(NA, 2));

                    //calculate elastic section properties
                    Itf = bft * Math.Pow(tft, 3) / 12;
                    Iweb = tw * Math.Pow(D, 3) / 12;
                    Ibf = bfb * Math.Pow(tfb, 3) / 12;
                    I = Itf + Atf * Math.Pow(Ytf - NA, 2) + Iweb + Aweb * Math.Pow(Yweb - NA, 2) + Ibf + Abf * Math.Pow(Ybf - NA, 2);
                    Stop = I / (Ytf - NA + tft / 2);
                    Sbot = I / (NA - Ybf + tfb / 2);
                    txtI.Text = Convert.ToString(Math.Round(I, 2));
                    txtStop.Text = Convert.ToString(Math.Round(Stop, 2));
                    txtSbot.Text = Convert.ToString(Math.Round(Sbot, 2));

                    //calculate plastic section properties
                    PNA = tfb + (D + (bft * tft - bfb * tfb) / tw) / 2;
                    PCGtop = (bft * tft * (tft / 2 + D + tfb - PNA) + tw * Math.Pow(D - PNA + tfb, 2) / 2) * 2 / Area;
                    PCGbot = (bfb * tfb * (PNA - tfb / 2) + tw * Math.Pow(PNA - tfb, 2) / 2) * 2 / Area;
                    Z = Area / 2 * (PCGtop + PCGbot);
                    txtPNA.Text = Convert.ToString(Math.Round(PNA, 2));
                    txtZ.Text = Convert.ToString(Math.Round(Z, 2));    
                
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            // exit the program
            Application.Exit(); 
        }
    }
}
