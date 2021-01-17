using System;
using System.Text.RegularExpressions;

namespace Parser
{
    public class FileEntry
    {
        public FileEntry(String line)
        {
            //var colums = line.Split(',');
            var colums = Regex.Split(line, ",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

            OznaczenieDzialkiRolnej = colums[0];
            Powierzchnia = FileEntry.ParseArea(colums[1]);
            GrupaUpraw = colums[2];
            RoslinaUprawna = colums[3];
            RoslinyWMieszance = colums[4];
            IloscNasion = colums[5];
            CzyEkologiczna = colums[6];
            NrDzialki = colums[7];
            PowierzchniaDzialkiRolnejWGranicachDzialkiEwid = FileEntry.ParseArea(colums[8]);
            ObszarONW = colums[9];
            PowierzchniaObszaruONW = FileEntry.ParseArea(colums[10]);
            NrPakietuPRSK = colums[11];
            PraktykaDodatkowa = colums[12];
            LDrzewOwocowych = colums[13];
            OdmianaDrzewOwocowych = colums[14];
            RoslinyWMiedzyplonie = colums[15];
            SposobUzytkowania = colums[16];
            OdmianaUprawy = colums[17];
            NrPakietuRE = colums[18];
            NawozZielonyRokWnioskowania = colums[19];
            NawozZielonyRokNastepny = colums[20];
            Uwagi = colums[21];
        }

        public String OznaczenieDzialkiRolnej { get; set; }
        public int Powierzchnia { get; set; } // ar
        public String GrupaUpraw { get; set; }
        public String RoslinaUprawna { get; set; }
        public String RoslinyWMieszance { get; set; }
        public String IloscNasion { get; set; }
        public String CzyEkologiczna { get; set; }
        public String NrDzialki { get; set; }
        public int PowierzchniaDzialkiRolnejWGranicachDzialkiEwid { get; set; } // ar
        public String ObszarONW { get; set; }
        public int PowierzchniaObszaruONW { get; set; } // ar
        // Platnosc PRSK
        public String NrPakietuPRSK { get; set; }
        public String PraktykaDodatkowa { get; set; }
        public String LDrzewOwocowych { get; set; }
        public String OdmianaDrzewOwocowych { get; set; }
        public String RoslinyWMiedzyplonie { get; set; }
        public String SposobUzytkowania { get; set; }
        public String OdmianaUprawy { get; set; }
        // Platnosc RE
        public String NrPakietuRE { get; set; }
        public String NawozZielonyRokWnioskowania { get; set; }
        public String NawozZielonyRokNastepny { get; set; }
        public String Uwagi { get; set; }

        public static int ParseArea(String area)
        {
            var withoutQuote = area.Replace("\"", "");
            if (withoutQuote.Equals("")) return 0;
            var convertedToDuble = Double.Parse(withoutQuote)*100;
            var convertedToInt = Convert.ToInt32(convertedToDuble);
            return convertedToInt;
        }
    }
}
